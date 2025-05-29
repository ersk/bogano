
using LocationMap.Logging;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Drink
{
    internal class Drink_PhysicalEntity : PhysicalEntity
    {
        private int remainingVolume;
        private Drink_PhysicalEntity_Definition definition;

        public Drink_PhysicalEntity(Drink_PhysicalEntity_Definition definition)
        {
            CodingReport? codingReport = null;
            if (definition.IsValid(ref codingReport) == false)
            {
                throw new Exception($"Cannot create '{nameof(Drink_PhysicalEntity)}' from definition. Definition was invalid.");
            }

            remainingVolume = definition.TotalVolume!.Value;
            this.definition = definition;
        }


    }
}
