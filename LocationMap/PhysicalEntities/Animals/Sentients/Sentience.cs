using Ersk.Simulation.DataTypes;
using LocationMap.PhysicalEntities.Animals.Sentients.Mental;
using MathNet.Numerics.Distributions;
using Math = Ersk.Simulation.DataTypes.Math;

namespace LocationMap.PhysicalEntities.Animals.Sentients
{
    internal class Sentience
    {









        private int animalId;

        public Sentience(int gameSeed, int animalId, int100 introversionExtroversion, int100 intuitionSensing, int100 feelingThinking, int100 judgingPerceiving, int100 assertiveTurbulant)
        {
            

            this.animalId = animalId;

            int baseSeed = gameSeed + animalId;
            Personality personality = new(baseSeed);

      





            // tertiary
            // allergies - sensitivity


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


    }
}
