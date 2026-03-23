using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk.Simulation.DataTypes
{
    public static class Math
    {
        public static int100 GetAverage(Random random, params int100[] influentialAttributes)
        {
            // add some unpredictability
            influentialAttributes.Append(random.Next(0, 100));

            return GetAverage(influentialAttributes);
        }
        public static int100 GetAverage(params int100[] influentialAttributes)
        {
            int total = 0;
            for (int i = 0; i < influentialAttributes.Length; i++)
            {
                total += influentialAttributes[i];
            }

            int mean = (int)System.Math.Round((double)total / influentialAttributes.Length);

            return mean;
        }
    }
}
