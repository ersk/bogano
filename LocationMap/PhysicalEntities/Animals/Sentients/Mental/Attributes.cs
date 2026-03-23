using Ersk.Simulation.DataTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Math = Ersk.Simulation.DataTypes.Math;

namespace LocationMap.PhysicalEntities.Animals.Sentients.Mental
{
    internal class Attributes
    {


        //public Personality Personality { get; }
        public Attributes(int seed, Personality p)
        {
            //Personality = personality;
            Random rand = new(seed + 394351);

            Awareness = Math.GetAverage(rand, p.Extroversion, p.Intuition, p.Feeling, p.Perceiving, p.Turbulant);
            Charisma = Math.GetAverage(rand, p.Extroversion, p.Assertive);
            Coolness = Math.GetAverage(rand, p.Assertive, p.Introversion); //cold towards others
            Courage = Math.GetAverage(rand, p.Assertive, p.Intuition, p.Feeling);
            Creativity = Math.GetAverage(rand, p.Intuition, p.Perceiving);
               // music
            Empathy = Math.GetAverage(rand, p.Feeling, p.Turbulant);
            Concentration = Math.GetAverage(rand, p.Introversion, p.Assertive, p.Judging, p.Sensing);
            Fortitude = Math.GetAverage(rand, p.Assertive, p.Sensing, p.Thinking);
               // => Determination
            Intelligence = Math.GetAverage(rand, p.Introversion, p.Thinking, p.Perceiving);
            Memory = Math.GetAverage(rand, p.Thinking, p.Introversion, p.Assertive, p.Sensing, p.Judging);
               // => Short term memory
               // => Long term memory
            Positivity = Math.GetAverage(rand, p.Assertive);
            ThinkingSpeed = Math.GetAverage(rand, p.Thinking, p.Turbulant, p.Perceiving, p.Intuition);
               // => reflexes
            Sensitivity = Math.GetAverage(rand, p.Introversion, p.Turbulant, p.Sensing);

            // sensitivity
            // sound, light, touch, smell, taste
            Sound = Math.GetAverage(rand, Sensitivity, Sensitivity);
            Light = Math.GetAverage(rand, Sensitivity, Sensitivity);
            Touch = Math.GetAverage(rand, Sensitivity, Sensitivity);
            Smell = Math.GetAverage(rand, Sensitivity, Sensitivity);
            Taste = Math.GetAverage(rand, Sensitivity, Sensitivity);
            // temperature

        }

        public int100 Awareness     { get; }
        public int100 Charisma      { get; }
        public int100 Coolness      { get; }
        public int100 Courage       { get; }
        public int100 Creativity    { get; }
        public int100 Empathy       { get; }
        public int100 Concentration { get; }
        public int100 Fortitude     { get; }
        public int100 Intelligence  { get; }
        public int100 Memory        { get; }
        public int100 Positivity    { get; }
        public int100 ThinkingSpeed { get; }
        public int100 Sensitivity { get; }

        public int100 Sound { get; }
        public int100 Light { get; }
        public int100 Touch{ get; }
        public int100 Smell{ get; }
        public int100 Taste{ get; }


    }
}
