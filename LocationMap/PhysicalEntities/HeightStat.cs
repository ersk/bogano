using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities
{

    public struct HeightStat
    {
        // 1 = 1cm
        private const int minValue = 0;
        private const int maxValue = 999;

        private int value;

        public HeightStat(int value)
        {
            this.value = Math.Clamp(value, minValue, maxValue);
        }

        public static HeightStat operator ++(HeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value + 1, minValue, maxValue);
            return heightStat;
        }
        public static HeightStat operator --(HeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value - 1, minValue, maxValue);
            return heightStat;
        }

        public static implicit operator int(HeightStat heightStat)
        {
            return heightStat.value;
        }
        public static implicit operator HeightStat(int intValue)
        {
            return new HeightStat(intValue);
        }

        public override string ToString()
        {
            if (value < 100)
            {
                // e.g. 99cm
                return value + "cm";
            }

            // e.g. 9.9m
            return (Convert.ToDecimal(value) / 100).ToString("0.0") + "m";
        }
    }
}
