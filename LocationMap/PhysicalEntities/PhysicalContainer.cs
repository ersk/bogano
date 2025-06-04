using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities
{
    public class PhysicalContainer
    {
        /*
         * Tile > Humanoid > Backpack > Food
         */

        private int weightCapacity;
        private int volumeCapacity;
        private PhysicalEntity? parentContainer;

        public bool CanAddItem(PhysicalEntity item)
        {
            throw new NotImplementedException();

            // check weight capacity

            // check weight capacity of parent
        }
        public bool AddItem(PhysicalEntity item)
        {
            throw new NotImplementedException();

            // call CanAddItem()
            // throws if out of capacity
        }
        public bool TryAddItem(PhysicalEntity item)
        {
            throw new NotImplementedException();

            // call CanAddItem()
        }


    }
}
