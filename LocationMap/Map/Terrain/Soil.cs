using Ersk.Simulation.DataTypes;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Map.Terrain
{
    internal class Soil
    {
        private int100 sand;
        private int100 silt;
        private int100 clay;

        public Soil(int100 sand, int100 silt)
        {
            if (sand + silt > 100)
            {
                throw new OverflowException($"Sand and silt combined was over 100 in value. Value was {sand + silt}.");
            }

            this.sand = sand;
            this.silt = silt;
            this.clay = 100 - sand - silt;
        }

        public SoilTypeEnum GetSoilType()
        {
            if(clay > 60) { return SoilTypeEnum.Clay; }
        }
    }
}
