using LocationMap.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Map.Pathfinding
{
    internal class MapTileAStarNode : IAStarNode<MapTileAStarNode>
    {
        public float EstimatedTotal => MovementCostToHere + Heuristic;

        public float MovementCostToHere { get; }

        private float? heuristic;
        public float Heuristic
        {
            get
            {
                if (heuristic == null)
                {
                    heuristic = GetDistance(MapTile, TargetMapTile);
                }
                return heuristic.Value;
            }
        }
        public string Key => ConstructKey(MapTile.X, MapTile.Y);

        public MapTile MapTile { get; }
        public AreaMap AreaMap { get; }
        //public MapTileAStarNode? NavigatedFrom { get; set; }
        public MapTile TargetMapTile { get; }
        public IAStarNode<MapTileAStarNode>? NavigatedFrom { get; }

        public MapTileAStarNode(MapTile mapTile, AreaMap areaMap, MapTileAStarNode? navigatedFrom, MapTile targetMapTile)
        {
            MapTile = mapTile;
            AreaMap = areaMap;
            NavigatedFrom = navigatedFrom;
            TargetMapTile = targetMapTile;


            float thisMapTileMovementCost = 1f; // Get from map tile and person

            if(navigatedFrom == null) // on start tile
            {
                MovementCostToHere = 0;
            }
            else
            {
                MovementCostToHere = thisMapTileMovementCost + navigatedFrom.MovementCostToHere;
            }
           


        }

        public static string ConstructKey(int x, int y)
        {
            return $"({x}, {y})";
        }


        public static float GetDistance(MapTile mapTile1, MapTile mapTile2)
        {
            int xDiff = mapTile2.X - mapTile1.X;
            int yDiff = mapTile2.Y - mapTile1.Y;

            return Convert.ToSingle(Math.Abs(Math.Sqrt(xDiff * xDiff + yDiff * yDiff)));
        }

        public void AddNeighborNodesToOpenDictionary(Dictionary<string, IAStarNode<MapTileAStarNode>> openNodes, Dictionary<string, IAStarNode<MapTileAStarNode>> closedNodes)
        {
            // up
            if (MapTile.Y != 0)
            {
                AddNeighborIfNotInOpenOrClosedDictionaries(MapTile.X, MapTile.Y - 1, openNodes, closedNodes);
            }

            // right
            if (MapTile.X != AreaMap.SizeTiles - 1)
            {
                AddNeighborIfNotInOpenOrClosedDictionaries(MapTile.X + 1, MapTile.Y, openNodes, closedNodes);
            }

            // down
            if (MapTile.Y != AreaMap.SizeTiles - 1)
            {
                AddNeighborIfNotInOpenOrClosedDictionaries(MapTile.X, MapTile.Y + 1, openNodes, closedNodes);
            }

            // left
            if (MapTile.X != 0)
            {
                AddNeighborIfNotInOpenOrClosedDictionaries(MapTile.X - 1, MapTile.Y, openNodes, closedNodes);
            }
        }
        private void AddNeighborIfNotInOpenOrClosedDictionaries(
          int neighborX,
          int neighborY,
          Dictionary<string, IAStarNode<MapTileAStarNode>> openNodes,
          Dictionary<string, IAStarNode<MapTileAStarNode>> closedNodes)
        {
            string key = ConstructKey(neighborX, neighborY);
            if (closedNodes.ContainsKey(key) == false && openNodes.ContainsKey(key) == false)
            {
                MapTile neighborMapTile = AreaMap.MapTiles[neighborX, neighborY];
                MapTileAStarNode neighbor = new(neighborMapTile, AreaMap, this, TargetMapTile);

                openNodes.Add(neighbor.Key, neighbor);
            }
        }

    }

}
