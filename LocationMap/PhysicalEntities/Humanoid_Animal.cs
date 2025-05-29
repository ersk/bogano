using Ersk.Simulation.DataTypes;
using LocationMap.Interactions.Activities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities
{
    internal class Humanoid_Animal : Animal_PhysicalEntity
    {
        /**
         * 
         * 
         * 
         **/

        private IActivity? currentActivity;

        public void Think()
        {
            CheckVitalNeeds();

            if(currentActivity != null)
            {
                currentActivity.DoTick();
            }
            else
            {
                ChooseNextActivity();
            }
        }

        public void CheckVitalNeeds()
        {
            // check current space - can breath air in current space
            if (CanBreathe() == false)
            {
                // then seek out breathable air
            }

            //if (water < 10)
            //{
            //    if (water == 0)
            //    {
            //        // add dehyration
            //        // dehydration will stack
            //        // dehydration = 20 stacks - then person dies
            //    }

            //    // Seek water
            //}

        }

        private void ChooseNextActivity()
        {
            // set current activity
        }

        private bool CanBreathe()
        {
            // 
            return true;
        }

        private void SeekWater()
        {
            // if currentActivity == SeekWater
            //  then do nothing

            // set current activity to SeekWater
        }

        //private IAnimalActivity? currentActivity;
        //private int100 sleep = 75;
        //private int100 water = 75;
        //private int100 food = 75;



 
    }
}
