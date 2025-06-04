using Ersk.Simulation.DataTypes;
using LocationMap.PhysicalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Map
{
    internal class MapTile
    {
        private PhysicalContainer container; // items that exist on this tile
        private int100 walkSpeed = 100;
        public int100 WalkSpeed => walkSpeed;

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// i.e. Impassable
        /// </summary>
        public bool IsWall { get; }

        public MapTile(int x, int y)
        {
            X = x;
            Y = y;

            int r = new Random().Next(25);


            if(r == 1)
            {
                IsWall = true;
            }

        }

        /**
         * Tarrain
         * ---------------------------
         * Rocky 
         * Flooded?
         * Soil
         *  - Clay Loam
         *  - 
         * Sand
         * 
         * 
         * Temperature
         * ---------------------------
         * Fire
         * Humidity
         * 
         * 
         * Air
         * ---------------------------
         * Breathable?
         * Pollution
         * Smell (miasma)
         * Humidity?
         * 
         * 
         * Visibility
         * ---------------------------
         * Smoke
         * Fire
         * Fog
         * 
         * 
         * Weather
         * ---------------------------
         * Rain
         * Sun - Heat / Sunburn / Skin cancer-melanin
         * Snow
         * Fog
         * Hail
         * 
         **/

        IList<PhysicalEntity> physicalEntities = new List<PhysicalEntity>();
        public IEnumerable<PhysicalEntity> PhysicalEntities => physicalEntities;


        #region Add

        public bool CanAddPhysicalEntity(PhysicalEntity physicalEntityToAdd)
        {
            return true;
        }
        public void AddPhysicalEntity(PhysicalEntity physicalEntityToAdd)
        {
            if (CanAddPhysicalEntity(physicalEntityToAdd) == false)
            {
                throw new PhysicalEntityCannotBeAddedEx();
            }

            physicalEntities.Add(physicalEntityToAdd);
        }

        public bool TryAddPhysicalEntity(PhysicalEntity physicalEntityToAdd)
        {
            if (CanAddPhysicalEntity(physicalEntityToAdd) == false)
            {
                return false;
            }

            physicalEntities.Add(physicalEntityToAdd);

            return true;
        }

        public class PhysicalEntityCannotBeAddedEx : Exception
        {

        }

        #endregion


        //public bool PhysicalEntityExists(PhysicalEntity physicalEntity)
        //{

        //}

    }
}
