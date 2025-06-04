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

        // e.g. items place on shelf
        public PhysicalContainer? container;



        //public bool IsWaterSource { get; } = false;

        // height - can shoot over? can climb over?
        // weight? - can be moved? but thats only if its moveable? and it could be fixed into the ground
        // volume - will bullets fly by or will they more likely hit it
        // toughness - how easy it is to break - due to damage
    }


}
