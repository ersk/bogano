using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk.Simulation.DataTypes
{

    public struct int10k
    {
        private const int minValue = 0;
        private const int maxValue = 10000;

        private int value;

        public int10k(int value)
        {
            this.value = Math.Clamp(value, minValue, maxValue);
        }

        public static int10k operator ++(int10k int1000)
        {
            int1000.value = Math.Clamp(int1000.value + 1, minValue, maxValue);
            return int1000;
        }
        public static int10k operator --(int10k int1000)
        {
            int1000.value = Math.Clamp(int1000.value - 1, minValue, maxValue);
            return int1000;
        }

        public static implicit operator int(int10k int1000)
        {
            return int1000.value;
        }
        public static implicit operator int10k(int intValue)
        {
            return new int10k(intValue);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
