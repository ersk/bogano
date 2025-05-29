using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationMap.PhysicalEntities.Moveables;

namespace LocationMap.PhysicalEntities
{
    internal interface IPhysicalEntityContainer
    {
        public int MaxCapacitySize { get; }
        public int CurrentCapacitySize { get; }

        public int MaxCapacityWeight { get; }
        public int CurrentCapacityWeight { get; }

        #region Add
        public bool CanAddPhysicalEntity(Moveable_PhysicalEntity physicalEntityToAdd);
        public void AddPhysicalEntity(Moveable_PhysicalEntity physicalEntityToAdd);
        public bool TryAddPhysicalEntity(Moveable_PhysicalEntity physicalEntityToAdd);
        #endregion


        #region Remove
        public bool PhysicalEntityExists(Moveable_PhysicalEntity physicalEntity);
        public Moveable_PhysicalEntity RemovePhysicalEntity(Moveable_PhysicalEntity physicalEntityToRemove);
        public bool TryRemovePhysicalEntity(Moveable_PhysicalEntity physicalEntityToRemove);
        #endregion

        public class MoveableCannotBeAddedEx : Exception
        {

        }
    }
}
