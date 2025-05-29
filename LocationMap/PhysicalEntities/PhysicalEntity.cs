using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities
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
    /// </summary>
    public class PhysicalEntity
    {
        /// <summary>
        /// Shelf -> Tile
        /// Stockpile -> Tile
        /// 
        /// Backpack (container) -> Person -> MapTile -> Map -> World -> Galaxy
        /// </summary>
        protected PhysicalEntity? location;
        public PhysicalEntity? Location => location;

        //public bool IsWaterSource { get; } = false;

    }


}
