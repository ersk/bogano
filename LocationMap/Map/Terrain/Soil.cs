using Ersk.Simulation.DataTypes;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Map.Terrain
{
    public class Soil
    {
        private int100 sand; // yellow
        private int100 silt; // red
        private int100 clay; // brown

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

            if(clay>40 && silt <60 && sand <20){ return SoilTypeEnum.SiltyClay; }

            if(clay>35 && clay<55 &&sand >45){return SoilTypeEnum.SandyClay;}

            if(clay > 40) return SoilTypeEnum.Clay;

            if(clay > 27 && sand <20) return SoilTypeEnum.SiltyClayLoam;

            if (clay > 27 && sand < 45) return SoilTypeEnum.ClayLoam;

            if (clay < 13 && silt > 80) return SoilTypeEnum.Silt;
            if (clay < 27 && silt > 50) return SoilTypeEnum.SiltLoam;

            if ((sand > 85 && clay < 5) || (sand > 90 && clay < 10)) return SoilTypeEnum.Sand;

            if ((clay < 20 && sand > 52) || (clay < 8 && silt < 50)) return SoilTypeEnum.SandyLoam;

            if (silt > 27) return SoilTypeEnum.SandyClayLoam;

            return SoilTypeEnum.Loam;


        }
    }
}
