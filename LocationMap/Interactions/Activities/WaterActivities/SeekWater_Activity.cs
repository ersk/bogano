using LocationMap.PhysicalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Interactions.Activities.WaterActivities
{
    internal class SeekWater_Activity : IActivity
    {
        private PhysicalEntity? waterSource = null;

        public void DoActivity()
        {
            if (waterSource == null)
            {
                // locate water source

                // bottle/cup, water fountain, sink, outside fountain, river, well,
                // clenliness of water?
            }
            else
            {
                // check if water source is still available
            }
        }

        public void DoTick()
        {
            throw new NotImplementedException();
        }

        public void OnComplete()
        {
            throw new NotImplementedException();
        }
    }

}
