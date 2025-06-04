using Ersk.Simulation.DataTypes;
using LocationMap.Logging;
using LocationMap.Map;
using LocationMap.Map.Pathfinding;
using LocationMap.PhysicalEntities.AnimalNeeds;
using LocationMap.PhysicalEntities.Drink;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LocationMap.GameManagement
{
    public class GameManager
    {
        public enum StateEnum
        {
            Not_Started,
            Config_Loaded,
            Loading_Definitions,
            Ready_To_Run,
            Running
        }


        #region Public Static

        public static GameManager Instance 
        { 
            get
            { 
                if(instance == null)
                {
                    throw new InvalidOperationException("Instance has not been initialized.");
                }
                return instance;
            }
        }

        public static GameManager Init() 
        {
            instance = new();

            

            return instance;
        }

        #endregion



        #region Public (instance)

        public StateEnum State => state;

        public void LoadDefinitions()
        {
            state = StateEnum.Loading_Definitions;

            string definitionsFolderPath = "../../../../Definitions";

            ReadWaterBottleJson(definitionsFolderPath);

            state = StateEnum.Ready_To_Run;
        }

        #endregion



        #region Private

        private static GameManager? instance;

        private StateEnum state = StateEnum.Not_Started;

        private AreaMap areaMap;

        private GameManager(/* pass in config */ ) 
        {
            /* apply config */

            state = StateEnum.Config_Loaded;

            areaMap = new(64);
        }
 
        private void ReadWaterBottleJson(string definitionsFolderPath)
        {
            string waterBottleRelativePath = "Physical_Entities/Animal_Consumables/Water_Bottle.json";
            string waterBottlePath = Path.Combine(definitionsFolderPath, waterBottleRelativePath);

            //var serializeOptions = new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    Converters =
            //    {
            //        new DictionaryTKeyEnumTValueConverter()
            //    }
            //};


            var deserializeOptions = new JsonSerializerOptions();
            //deserializeOptions.Converters.Add(new DictionaryTKeyEnumTValueConverter());
            //weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, deserializeOptions)!;

            Drink_PhysicalEntity_Definition? drinkDefNullable;
            Drink_PhysicalEntity_Definition drinkDef;
            using (FileStream jsonStream = new FileStream(waterBottlePath, FileMode.Open, FileAccess.Read))
            {
                drinkDefNullable = JsonSerializer.Deserialize<Drink_PhysicalEntity_Definition>(jsonStream, deserializeOptions);

                if(drinkDefNullable == null )
                {
                    throw new JsonException("Deserialized to null.");
                }

                drinkDef = drinkDefNullable;

                //string jsonString = JsonSerializer.Serialize(peopleFromJsonStream, serializeOptions);
            }

            CodingReport? codingReport = null;
            if (drinkDef.IsValid(ref codingReport) == false)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine(codingReport.ToString());
                Console.WriteLine("--------------------------------------------");
            }

            Drink_PhysicalEntity drink = new(drinkDef);

        }

        public void RunNavigationTest()
        {
            Point person = new Point(3, 3);
            Point target = new Point(11, 8);

            MapTile startTile = areaMap.MapTiles[person.X, person.Y];
            MapTile targetTile = areaMap.MapTiles[target.X, target.Y];
            MapTileAStarNode startNode = new(startTile, areaMap, null, targetTile);
            MapTileAStarNode targetNode = new(targetTile, areaMap, null, targetTile);

            AStarAlgorithm<MapTileAStarNode> aStarAlgorithm = new(startNode, targetNode);

            MapTileAStarNode? path = (MapTileAStarNode?)aStarAlgorithm.FindPath();

            List<MapTile> mapTilesPath = new List<MapTile>();
            if(path == null)
            {
                throw new Exception("Could not navigate to target map tile.");
            }

            MapTileAStarNode? node = path;
            while(node != null)
            {
                mapTilesPath.Add(node.MapTile);
                node = (MapTileAStarNode?)node.NavigatedFrom;
            }

            StringBuilder sb = new();
            for (int i = mapTilesPath.Count() - 1; i >= 0; i--)
            {
                sb.Append($"{mapTilesPath[i].X},{mapTilesPath[i].Y} => ");
            }
            //foreach (MapTile mapTile in mapTilesPath)
            //{
            //    sb.Append($"{mapTile.X},{mapTile.Y} => ");
            //}

            string pathReadout = sb.ToString();
            pathReadout = pathReadout.Substring(0, pathReadout.Length - 4);
            Console.WriteLine(pathReadout);
        }

        public void RunNavigationTestOLD()
        {
            Point person = new Point(3, 3);
            Point target = new Point(11,8);
           

            Dictionary<string,AStarNode> availableNodesList = new Dictionary<string,AStarNode>();

            for (int i =0; i < areaMap.SizeTiles; i++)
            {
                for (int j = 0; j < areaMap.SizeTiles; j++)
                {
                    //if(i == target.X && j == target.Y)
                    //{
                    //    targetNodeTemp = new(i, j);
                    //    continue;
                    //}

                    AStarNode node = new(i, j);
                    availableNodesList.Add(node.Key, node);
                }
            }

            //if(targetNodeTemp == null)
            //{
            //    throw new Exception("target temp was null");
            //}
            //targetNode = targetNodeTemp;

            List<AStarNode> openList = new List<AStarNode>();

            List<AStarNode> closedList = new List<AStarNode>();

            // move start node to open list
            string startKey = AStarNode.ConstructKey(person);
            if (availableNodesList.ContainsKey(startKey) == false)
            {
                throw new Exception("missing start node");
            }
            AStarNode startNode = availableNodesList[startKey];
            availableNodesList.Remove(startKey);
            openList.Add(startNode);

            // get target node
            string targetKey = AStarNode.ConstructKey(target);
            if (availableNodesList.ContainsKey(targetKey) == false)
            {
                throw new Exception("missing target node");
            }
            AStarNode targetNode = availableNodesList[targetKey];

            while (true)
            {
                AStarNode? foundTargetNode = openList.FirstOrDefault(node => node.Key == targetNode.Key);
                if(foundTargetNode != null)
                {
                    break;
                }

                AStarNode lowest = GetLowestFValue(openList);

                openList.Remove(lowest);

                GetNeighborNodes(ref openList, lowest, availableNodesList, targetNode);
            }

            string s = "";


            // choose next node with the lowest weight
        }


        #endregion



        #region OLD A Star Code

        public AStarNode GetLowestFValue(List<AStarNode> openList)
        {
            AStarNode lowestFValue = openList[0];
            foreach (var item in openList)
            {
                if (lowestFValue.F > item.F)
                {
                    lowestFValue = item;
                }
            }

            return lowestFValue;
        }

        public void GetNeighborNodes(
            ref List<AStarNode> openList,
            AStarNode node, Dictionary<string, AStarNode> availableNodesList, AStarNode targetNode)
        {
            // up
            if (node.Point.Y != 0)
            {
                string key = AStarNode.ConstructKey(node.Point.X, node.Point.Y - 1);
                if (availableNodesList.ContainsKey(key))
                {
                    AStarNode neighbor = availableNodesList[key];
                    neighbor.G = node.G + neighbor.MovementCost;
                    neighbor.SetHeuristic(targetNode);
                    neighbor.PreceedingNode = node;
                    availableNodesList.Remove(key);
                    openList.Add(neighbor);
                }
            }

            // right
            if (node.Point.X != areaMap.SizeTiles - 1)
            {
                string key = AStarNode.ConstructKey(node.Point.X + 1, node.Point.Y);
                if (availableNodesList.ContainsKey(key))
                {
                    AStarNode neighbor = availableNodesList[key];
                    neighbor.G = node.G + neighbor.MovementCost;
                    neighbor.SetHeuristic(targetNode);
                    neighbor.PreceedingNode = node;
                    availableNodesList.Remove(key);
                    openList.Add(neighbor);
                }
            }

            // down
            if (node.Point.Y != areaMap.SizeTiles - 1)
            {
                string key = AStarNode.ConstructKey(node.Point.X, node.Point.Y + 1);
                if (availableNodesList.ContainsKey(key))
                {
                    AStarNode neighbor = availableNodesList[key];
                    neighbor.G = node.G + neighbor.MovementCost;
                    neighbor.SetHeuristic(targetNode);
                    neighbor.PreceedingNode = node;
                    availableNodesList.Remove(key);
                    openList.Add(neighbor);
                }
            }

            // left
            if (node.Point.X != 0)
            {
                string key = AStarNode.ConstructKey(node.Point.X - 1, node.Point.Y);
                if (availableNodesList.ContainsKey(key))
                {
                    AStarNode neighbor = availableNodesList[key];
                    neighbor.G = node.G + neighbor.MovementCost;
                    neighbor.SetHeuristic(targetNode);
                    neighbor.PreceedingNode = node;
                    availableNodesList.Remove(key);
                    openList.Add(neighbor);
                }
            }
        }

        public static float GetDistance(Point p1, Point p2)
        {
            int xDiff = p2.X - p1.X;
            int yDiff = p2.Y - p1.Y;

            return Convert.ToSingle(Math.Abs(Math.Sqrt(xDiff * xDiff + yDiff * yDiff)));
        }

        public class AStarNode
        {
            public string Key => ConstructKey(Point);
            public int MovementCost => 1;
            public AStarNode PreceedingNode { get; set; }
            public float F => G + H;
            // Weight - total weight/distance from starting node
            public int G { get; set; }
            // Approx Cost (Heuristic)
            public float H { get; set; }
            public Point Point { get; }
            public AStarNode(int pointX, int pointY)
            {
                Point = new Point(pointX, pointY);
            }
            public AStarNode(Point point)
            {
                Point = point;
            }

            public void SetHeuristic(AStarNode target)
            {
                H = GetDistance(Point, target.Point);
            }

            public static string ConstructKey(Point point)
            {
                return $"({point.X}, {point.Y})";
            }
            public static string ConstructKey(int x, int y)
            {
                return $"({x}, {y})";
            }
        }

        #endregion
    }

}
