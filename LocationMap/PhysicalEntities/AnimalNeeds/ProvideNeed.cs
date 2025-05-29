using Ersk.Simulation.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.AnimalNeeds
{
    internal class ProvideNeed
    {
        public SoilTypeEnum Need { get; }
        public int100 Amount { get; }

        public ProvideNeed(SoilTypeEnum need, int100 amount)
        {
            Need = need;
            Amount = amount;
        }
    }

}
