using LocationMap.Definitions.Attributes;
using LocationMap.Definitions;
using LocationMap.Interactions.Activities;
using LocationMap.Logging;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities
{



    internal class PhysicalEntity_Definition : Definition
    {
        //public new bool IsValid(out CodingReport? codingReport)
        //{
        //    bool baseIsValid = base.IsValid(out codingReport);

        //    if (string.IsNullOrWhiteSpace(Id))
        //    {
        //        codingReport ??= new();
        //        codingReport.AddErrors("Invalid_Id_Missing", $"{Id} was missing/empty.");
        //    }
        //    //else
        //    //{
        //    //    bool canConvert = NeedEnum.TryConvert(Need, out _);

        //    //    if (canConvert == false) 
        //    //    {
        //    //        codingReport.AddErrors("Invalid_Need_Cast", $"Need '{Need}' could not cast to Needs enum (class)");
        //    //    }
        //    //}

        //    return codingReport == null || !codingReport.HasErrors;
        //}

        /**
         * Interactions
         * -----------
         * IsCarryable - based on size and weight - and based on strenght and size (long arms) of person - add to posessions
         * IsScalable - based on height / agility / manipulation
         * 
         * Beauty
         * Weight - Can it be pushed / knocked over
         * Toughness - can be broken? hit points?
         * Flameprroof
         * Waterproof
         * Windproof
         * Size
         *      - tree - 10 - 100% of the tile
         *      - human - 30-60% of the tile
         *      - bed - 1x2
         *      - height
         *          - can shoot over bed
         *          - can jump over bed
         *          - can climb over fence (cant jump over)
         *          - can't shoot over fence
         *          - can throw object over fence (grenade)
         * 
         * Activities
         * ---------------
         * Drink if item is in posessions
         * Eat if item is in posessions
         * Make something at a work station
         * Play a game
         * Harvest plant / wood
         * Guard location
         * Feed person
         * Carry item
         * 
         **/
    }

}
