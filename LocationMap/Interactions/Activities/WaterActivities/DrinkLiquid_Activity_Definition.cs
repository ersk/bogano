using LocationMap.Logging;
using LocationMap.PhysicalEntities;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Interactions.Activities.WaterActivities
{
    internal class DrinkLiquid_Activity_Definition : Base_Activity_Definition, IValidatable
    {
        // Populate when creating the actual item from the definition
        //public string? PhysicalEntityId { get; set; }  // Water_Bottle

        public IList<ProvideNeed_Definition>? PartialActivityProvidedNeeds { get; set; }
        public int? PartialActivityTicksToComplete { get; set; } // 200ticks
        public int? PartialActivityConsumeVolume { get; set; } // consume 20ml


        public new bool IsValid(ref CodingReport? codingReport)
        {
            base.IsValid(ref codingReport);

            //if (string.IsNullOrWhiteSpace(PhysicalEntityId))
            //{
            //    codingReport ??= new();
            //    codingReport.AddErrors("DrinkLiquidActivityDefinition_PhysicalEntityId_Empty", $"{nameof(PhysicalEntityId)} was empty.");
            //}
            if (PartialActivityTicksToComplete == null)
            {
                codingReport ??= new();
                codingReport.AddErrors("DrinkLiquidActivityDefinition_PartialActivityTicksToComplete_Null", $"{nameof(PartialActivityTicksToComplete)} was null.");
            }
            if (PartialActivityTicksToComplete == null)
            {
                codingReport ??= new();
                codingReport.AddErrors("DrinkLiquidActivityDefinition_PartialActivityConsumeVolume_Null", $"{nameof(PartialActivityConsumeVolume)} was null.");
            }
            if (PartialActivityProvidedNeeds == null || PartialActivityProvidedNeeds.Any() == false)
            {
                codingReport ??= new();
                codingReport.AddErrors("DrinkLiquidActivityDefinition_PartialActivityProvidedNeeds_Empty", $"{nameof(PartialActivityConsumeVolume)} was empty.");
            }
            else
            {
                foreach (ProvideNeed_Definition provideNeed in PartialActivityProvidedNeeds)
                {
                    provideNeed.IsValid(ref codingReport);
                }
            }

            return codingReport == null || !codingReport.HasErrors;
        }
    }

}
