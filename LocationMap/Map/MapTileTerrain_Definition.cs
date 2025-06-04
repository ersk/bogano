using Ersk.Simulation.DataTypes;
using LocationMap.Definitions;
using LocationMap.PhysicalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Map
{
    internal class MapTileTerrain_Definition : Definition
    {
        private float fertility;
        public float Fertility => fertility;



        /**
         * 
         * 
         * 
         * Soil - Moisture?
         * Sand
         * Rock
         * 
         * 
         * Soil has 3 variables
         * - Sand
         * - Silt
         * - CLay
         * Bet to have a mix of all 3? (loam?)
         * 
         * 
         * Mud - soil with no vegetation
         * 
         * Water - on top[ of soil or sand
         * 
         **/ 

    }
}
