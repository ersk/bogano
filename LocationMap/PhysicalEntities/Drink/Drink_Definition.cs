using LocationMap.Interactions.Activities;
using LocationMap.Interactions.Activities.WaterActivities;
using LocationMap.Logging;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Drink
{
    internal class Drink_PhysicalEntity_Definition : PhysicalEntity_Definition, IValidatable
    {
        public int? TotalVolume { get; set; } // 300ml

        public DrinkLiquid_Activity_Definition? DrinkLiquid_Activity { get; set; }

        public bool IsValid(ref CodingReport? codingReport)
        {
            base.IsValid(ref codingReport);

            if (TotalVolume == null)
            {
                codingReport ??= new();
                codingReport.AddErrors("Invalid_TotalVolume_Null", $"{TotalVolume} was null.");
            }
            else if (TotalVolume < 1)
            {
                codingReport ??= new();
                codingReport.AddErrors("Invalid_TotalVolume_LessThanOne", $"{TotalVolume} was less than 1.");
            }

            if(DrinkLiquid_Activity == null)
            {
                codingReport ??= new();
                codingReport.AddErrors("Invalid_Activity_Null", $"{DrinkLiquid_Activity} was null.");
            }
            else
            {
                DrinkLiquid_Activity.IsValid(ref codingReport);
                //codingReport = CodingReport.Combine(codingReport, activityReport);
            }
         

            return codingReport == null || !codingReport.HasErrors;
        }
    }
}
