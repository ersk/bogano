using LocationMap.Logging;
using LocationMap.PhysicalEntities;
using LocationMap.PhysicalEntities.Animals.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Interactions.Activities.WaterActivities
{
    internal class DrinkLiquid_Activity : BaseActivity, IActivity
    {
        public PhysicalEntity PhysicalEntity { get; }  // Water_Bottle
        public DrinkLiquid_Activity_Definition Definition { get; }

        public static string? Verb_Past => "drank";
        public static string? Verb_Doing => "drinking";
        public static string? Verb_ToDo => "drink";

        public event EventHandler? ActivityCompleted;


        public DrinkLiquid_Activity(DrinkLiquid_Activity_Definition definition, PhysicalEntity physicalEntity)
        {
            Definition = definition;
            PhysicalEntity = physicalEntity;
        }

        public void DoTick()
        {
            ticksCompleted++;

            if (ticksCompleted >= ticksToComplete)
            {
                // emit activity complete
                // partial completion

                //ActivityCompleted?.Invoke(this, e);
            }
        }

        public void OnComplete()
        {
            throw new NotImplementedException();
        }

        public void OnPartialComplete()
        {
            throw new NotImplementedException();
        }
    }

    internal class DrinkLinquidCompleteEventArgs : EventArgs
    {
        public PhysicalEntity WaterSource { get; }
        public IList<ProvideNeed>? ProvidedNeeds { get; set; }

        public DrinkLinquidCompleteEventArgs(PhysicalEntity waterSource)
        {
            this.WaterSource = waterSource;
        }

    }
}
