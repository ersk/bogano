using LocationMap.PhysicalEntities;
using System.Drawing;
using System.Text;

namespace LocationMap.Map
{


    internal class AreaMap
    {

        // Width and height of map.
        private readonly int sizeTiles;
        public int SizeTiles => sizeTiles;

        private MapTile[,] mapTiles;
        public MapTile[,] MapTiles => mapTiles;


        public AreaMap(int sizeTiles)
        {
            this.sizeTiles = sizeTiles;

            mapTiles = new MapTile[this.sizeTiles, this.sizeTiles];

            GenerateTiles();
        }

        private void GenerateTiles()
        {
            for (int indexX = 0; indexX < sizeTiles; indexX++)
            {
                for (int indexY = 0; indexY < sizeTiles; indexY++)
                {
                    mapTiles[indexX, indexY] = new MapTile(indexX, indexY);
                }
            }

        }



        public void SpawnPhysicalEntity(PhysicalEntity physicalEntity, Point spawnLocation)
        {
            physicalEntities.Add(physicalEntity);

            // is spawn location within map bounds
            if (IsPointWithinAreaMapBounds(spawnLocation))
            {

            }

            // is spawn location available for that kind of object

        }





        // Physical Entities that are present on the current location map.
        private IList<PhysicalEntity> physicalEntities { get; set; } = new List<PhysicalEntity>();

        private bool IsPointWithinAreaMapBounds(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < sizeTiles && point.Y < sizeTiles;
        }

    }

    internal class PhysicalEntityOnAreaMap
    {
        /// <summary>
        /// Location on area map.
        /// </summary>
        private Point location;

        private PhysicalEntity physicalEntity;

        PhysicalEntityOnAreaMap(PhysicalEntity physicalEntity, Point location)
        {
            this.location = location;
            this.physicalEntity = physicalEntity;
        }
    }

    internal class InvalidAreaMapSpawnLocationEx : Exception
    {
        public Point SpawnLocation { get; }
        public AreaMap AreaMap { get; }


        public InvalidAreaMapSpawnLocationEx(AreaMap areaMap, Point spawnLocation)
            : base(GetMessage(areaMap, spawnLocation))
        {
            AreaMap = areaMap;
            SpawnLocation = spawnLocation;
        }
        public InvalidAreaMapSpawnLocationEx(string message, AreaMap areaMap, Point spawnLocation)
            : base(message)
        {
            AreaMap = areaMap;
            SpawnLocation = spawnLocation;
        }

        public static string GetMessage(AreaMap areaMap, Point spawnLocation)
        {
            return $"Area map spawn location '({spawnLocation.X}, {spawnLocation.Y})' was invalid.";
        }
    }
    internal class OutOfBounds_InvalidAreaMapSpawnLocation_Ex : InvalidAreaMapSpawnLocationEx
    {

        public OutOfBounds_InvalidAreaMapSpawnLocation_Ex(AreaMap areaMap, Point spawnLocation)
            : base(GetMessage(areaMap, spawnLocation), areaMap, spawnLocation)
        {

        }

        public static string GetMessage(AreaMap areaMap, Point spawnLocation)
        {
            StringBuilder sb = new($"Area map spawn location '({spawnLocation.X}, {spawnLocation.Y})' was out of bounds for area map size '{areaMap.SizeTiles}'.");

            if (spawnLocation.X < 0)
            {
                sb.Append("Spawn location X was less than 0. ");
            }
            if (spawnLocation.Y < 0)
            {
                sb.Append("Spawn location Y was less than 0. ");
            }
            if (spawnLocation.X >= areaMap.SizeTiles)
            {
                sb.Append($"Spawn location X was equal to or greater than {areaMap.SizeTiles}. ");
            }
            if (spawnLocation.Y >= areaMap.SizeTiles)
            {
                sb.Append($"Spawn location Y was equal to or greater than {areaMap.SizeTiles}. ");
            }

            return sb.ToString().Trim();
        }
    }
}