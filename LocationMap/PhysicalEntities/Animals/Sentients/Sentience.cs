using Ersk.Simulation.DataTypes;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Animals.Sentients
{
    internal class Sentience
    {

        // mental
        private int100 introversionExtroversion;
        private int100 intuitionSensing;
        private int100 feelingThinking;
        private int100 judgingPerceiving;
        private int100 assertiveTurbulant;

        private int100 awareness;
        private int100 charisma;
        private int100 coolness;
        private int100 courage;
        private int100 creativity;
        private int100 empathy;
        private int100 concentration;
        private int100 fortitude;
        private int100 intelligence;
        private int100 memory;
        private int100 positivity;
        private int100 thinkingSpeed;


        // patience?
        


        public int100 Introversion => 100 - introversionExtroversion;
        public int100 Extroversion => introversionExtroversion;

        public int100 Intuition => 100 - intuitionSensing;
        public int100 Sensing => intuitionSensing; // observant

        public int100 Feeling => 100 - feelingThinking;
        public int100 Thinking => feelingThinking;

        public int100 Judging => 100 - judgingPerceiving;
        public int100 Perceiving => judgingPerceiving; // prospecting

        public int100 Assertive => 100 - assertiveTurbulant;
        public int100 Turbulant => assertiveTurbulant;



        private int animalId;

        public Sentience(int animalId, int100 introversionExtroversion, int100 intuitionSensing, int100 feelingThinking, int100 judgingPerceiving, int100 assertiveTurbulant)
        {
            this.introversionExtroversion = introversionExtroversion;
            this.intuitionSensing = intuitionSensing;
            this.feelingThinking = feelingThinking;
            this.judgingPerceiving = judgingPerceiving;
            this.assertiveTurbulant = assertiveTurbulant;

            this.animalId = animalId;

            ///////////////////////////////////////
            ///
            ///  Dont change the order of these properties
            ///
            ///////////////////////////////////////
            Random rand = new(animalId);
            this.awareness = GetAverage(rand, Extroversion, Intuition, Feeling, Perceiving, Turbulant);
            this.charisma = GetAverage(rand, Extroversion, Assertive);
            this.coolness = GetAverage(rand, Assertive, Introversion);
            this.courage = GetAverage(rand, Assertive, Intuition, Feeling);
            this.creativity = GetAverage(rand, Intuition, Perceiving);
            this.empathy = GetAverage(rand, Feeling, Turbulant);
            this.concentration = GetAverage(rand, Introversion, Assertive, Judging, Sensing);
            this.fortitude = GetAverage(rand, Assertive, Sensing, Thinking);
            this.intelligence = GetAverage(rand, Introversion, Thinking, Perceiving);
            this.memory = GetAverage(rand, Thinking, Introversion, Assertive, Sensing, Judging);
            this.positivity = GetAverage(rand, Assertive);
            this.thinkingSpeed = GetAverage(rand, Thinking, Turbulant, Perceiving, Intuition);

            /*
             * Creativity
             *      Musicality
             * Fortitude
             *      Determination
             * Tertiary
             *      Short term memory
             *      Long term memory
             * Thinking Speed
             *      Reflextes
             */
        }

        public static Sentience Generate(int animalId, Random rand)
        {
            Normal normal = new Normal(50, 12, rand);

            Sentience sentience = new(
                animalId,
                (int)Math.Round(normal.Sample()),
                (int)Math.Round(normal.Sample()),
                (int)Math.Round(normal.Sample()),
                (int)Math.Round(normal.Sample()),
                (int)Math.Round(normal.Sample()));

            return sentience;
        }

        public int100 GetAverage(Random random, params int100[] influentialAttributes) 
        {
            int total = 0;
            for (int i = 0; i < influentialAttributes.Length; i++)
            {
                total += influentialAttributes[i];
            }

            // add some unpredictability
            total += random.Next(0, 100);

            int mean = (int)Math.Round((double)total / influentialAttributes.Length + 1);

            return mean;
        }
    }
}
