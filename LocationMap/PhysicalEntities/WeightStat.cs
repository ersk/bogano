using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities
{
    public struct WeightStat
    {
        // 1 = 100g
        private const int minValue = 0;
        private const int maxValue = 99999;

        private int value;

        public WeightStat(int value)
        {
            this.value = Math.Clamp(value, minValue, maxValue);
        }

        public static WeightStat operator ++(WeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value + 1, minValue, maxValue);
            return heightStat;
        }
        public static WeightStat operator --(WeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value - 1, minValue, maxValue);
            return heightStat;
        }

        public static implicit operator int(WeightStat heightStat)
        {
            return heightStat.value;
        }
        public static implicit operator WeightStat(int intValue)
        {
            return new WeightStat(intValue);
        }

        public override string ToString()
        {
            if (value < 1000)
            {
                // 99.9kg
                return (Convert.ToDecimal(value) / 10).ToString("0.0") + "kg";
            }

            // 10.0t
            return (Convert.ToDecimal(value) / 10000).ToString("0.0") + "t";
        }
    }
}
