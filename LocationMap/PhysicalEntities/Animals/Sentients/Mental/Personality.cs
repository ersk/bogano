using Ersk.Simulation.DataTypes;
using Ersk.Simulation.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Animals.Sentients.Mental
{
    internal class Personality
    {
        // patience?

        // primary
        private int100 introversionExtroversion;
        private int100 intuitionSensing;
        private int100 feelingThinking;
        private int100 judgingPerceiving;
        private int100 assertiveTurbulant;

        public int100 Introversion => 100 - introversionExtroversion; // prefers solitude, low stimulaing environments
        public int100 Extroversion => introversionExtroversion; // prefers social gatherings, high stimulaing environments

        public int100 Intuition => 100 - intuitionSensing; //quick, sub conscious
        public int100 Sensing => intuitionSensing; // observant, analytical, conscious, awareness

        public int100 Feeling => 100 - feelingThinking; // emotional
        public int100 Thinking => feelingThinking; // logical

        public int100 Judging => 100 - judgingPerceiving; // black/white - organised - fixed
        public int100 Perceiving => judgingPerceiving; // prospecting - flexible - open to options

        public int100 Assertive => 100 - assertiveTurbulant; // confident, calm, resilient
        public int100 Turbulant => assertiveTurbulant; // self conscious, perfectionist, tense


        public Attributes Attributes { get;  }

        public Personality(int seed)
        {
            Random rnd = new(seed + 3463488);

            //BezierCurve.GetValue(0, 100, 0.5f, out float t);

            ///////////////////////////////////////
            ///
            ///  Dont change the order of these properties
            ///  then we can use a seed to regerate the values
            ///
            ///////////////////////////////////////
            introversionExtroversion = rnd.Next(100);
            intuitionSensing = rnd.Next(100);
            feelingThinking = rnd.Next(100);
            judgingPerceiving = rnd.Next(100);
            assertiveTurbulant = rnd.Next(100);

            Attributes = new(seed, this);
        }
    }
}
