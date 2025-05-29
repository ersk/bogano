using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk.Simulation.DataTypes
{

    public struct int1000
    {
        private const int minValue = 0;
        private const int maxValue = 1000;

        private int value;

        public int1000(int value)
        {
            this.value = Math.Clamp(value, minValue, maxValue);
        }

        public static int1000 operator ++(int1000 int1000)
        {
            int1000.value = Math.Clamp(int1000.value + 1, minValue, maxValue);
            return int1000;
        }
        public static int1000 operator --(int1000 int1000)
        {
            int1000.value = Math.Clamp(int1000.value - 1, minValue, maxValue);
            return int1000;
        }

        public static implicit operator int(int1000 int1000)
        {
            return int1000.value;
        }
        public static implicit operator int1000(int intValue)
        {
            return new int1000(intValue);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
