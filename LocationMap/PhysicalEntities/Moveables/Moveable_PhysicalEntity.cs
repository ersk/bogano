using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Moveables
{
    /// <summary>
    /// e.g.
    /// MapTile
    /// Person
    /// Item
    /// Weapon
    /// Food
    /// PhysicalContainer (bin, bag, bucket)
    /// Components (cog, pipe, rod, plank)
    /// 
    /// A moveable physical entity can be placed in a container
    /// </summary>
    public class Moveable_PhysicalEntity : PhysicalEntity
    {
        public bool IsSpawnedOnMap => location != null;
    }


}
