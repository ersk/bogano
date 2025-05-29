using ISL.Firefly.DataTypes.Common.Attributes;
using LocationMap.Logging;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Definitions
{
    internal abstract class Definition : IValidatable
    {
        [Required]
        [MinLength(3)]
        public string? Id { get; set; } // Drink_WaterBottle

        /// <summary>
        /// Height of a wall is 240 cm.
        /// Anything over 200 cm is impassable (going over).
        /// </summary>
        [Required]
        [MinValue(1)]
        public int HeightCentimeters { get; set; }

        /// <summary>
        /// A tile is 100 cm x 100 cm.
        /// Anyting over 80 cm is impassable.
        /// </summary>
        [Required]
        [MinValue(1)]
        public int WidthCentimeters { get; set; }

        [Required]
        [MinValue(1)]
        public int WeightGrams { get; set; }

        /// <summary>
        /// 0 == Unfixed (default) - e.g. An item placed on the floor.
        /// 2 == Fixed - Hinges and door latch (fixed in 4 places?)
        /// 6 == Partitioning Wall - Attached to other walls. Screwed to floor and ceiling
        /// 8 == Brick Wall - Cemented in place
        /// </summary>
        public int FixtureStrength { get; set; } = 0;

        public bool IsValid(ref CodingReport? codingReport)
        {
            if (string.IsNullOrEmpty(Id))
            {
                codingReport ??= new();
                codingReport.AddErrors("Invalid_BaseActivityDefinition_Id", $"{nameof(Id)} was null or whitespace.");
            }

            return codingReport == null || !codingReport.HasErrors;
        }
    }
}
