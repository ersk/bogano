using Ersk.Simulation.DataTypes;
using LocationMap.Logging;
using LocationMap.PhysicalEntities;
using LocationMap.PhysicalEntities.AnimalNeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocationMap.PhysicalEntities.Humanoid_Animal;

namespace LocationMap.Interactions.Activities
{

    internal interface IActivity
    {
        public void DoTick();
        //public void OnPartialComplete();
        public void OnComplete();
    }



    internal abstract class BaseActivity
    {
       

        protected int ticksToComplete;
        protected int ticksCompleted;

        public BaseActivity()
        {
            
        }

        //public void DoTick()
        //{
        //    ticksCompleted++;

        //    if(ticksCompleted >= ticksToComplete)
        //    {
        //        // emit activity complete
        //        // partial completion

        //        ActivityCompleted?.Invoke(this, e);
        //    }
        //}

        //public void OnComplete()
        //{
        //    throw new NotImplementedException();
        //}
    }

    //internal interface IActivity_Defini
    //{
    //    public static string? Verb_Past { get; set; }  // drank from water bottle
    //    public static string? Verb_Doing { get; set; } // drinking from water bottle
    //    public static string? Verb_ToDo { get; set; } // drink from water bottle
    //}

    internal abstract class Base_Activity_Definition : IValidatable
    {
        public string? Id { get; set; } // Drink_WaterBottle


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
