using Ersk.Simulation.DataTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Math = Ersk.Simulation.DataTypes.Math;

namespace LocationMap.PhysicalEntities.Animals.Sentients.Mental
{
    internal class Values
    {


        public Sentience Sentience { get; }
        public Values(Sentience sentience)
        {
            Sentience = sentience;
        }


        // VALUES - computed from attributes

        // recreation / work
        public int100 recreation => Math.GetAverage(Sentience.Perceiving, Sentience.Introversion, Sentience.creativity, Sentience.concentration);

        // recover / soldier on
        int100 recovery = Math.GetAverage(Sentience.Turbulant, Sentience.Perceiving, Sentience.Feeling, Sentience.Introversion, 100 - Sentience.courage, 100 - Sentience.fortitude, Sentience.sensitivity);

        int100 beauty = Math.GetAverage(Sentience.Introversion, Sentience.Sensing, Sentience.awareness, Sentience.creativity, Sentience.light);

        int100 comfort = Math.GetAverage(Introversion, sensitivity, 100 - fortitude, touch);

        //
        //  add physical.immuneSystem
        //
        int100 hygeine = Math.GetAverage(Judging, Thinking, awareness);

        int100 spiritual = Math.GetAverage(Feeling, Judging, creativity);  //religion

        int100 drugs = Math.GetAverage(Intuition, Feeling, Turbulant, creativity, spiritual);

        int100 wealth = Math.GetAverage(Intuition, intelligence, Turbulant, charisma);

        int100 space = Math.GetAverage(Introversion, Feeling, Perceiving, Turbulant, awareness); // room

        int100 outdoors = Math.GetAverage(Extroversion, Assertive, courage, space); // nature

        int100 exploration = Math.GetAverage(Extroversion, Perceiving, Assertive, courage);

        int100 brightness = Math.GetAverage(light, awareness, Turbulant, Extroversion, Sensing); //light vs dark       

        int100 bodyPurity = Math.GetAverage(Sensing, Turbulant, 100 - courage, 100 - creativity, sensitivity);

        int100 food = Math.GetAverage(Sensing, taste, smell); // quality / variety

        int100 animals = Math.GetAverage(Introversion, Feeling, empathy, courage, touch);
        /*
         * dairy
         * 
         * mammals
         * reptiles
         * amphibians
         * birds
         * fish
         * 
         * anthropod (insects & spiders)
         * crustaceans
         * molluscs
         * jellyfish
         * 
         *   Animals - diet
        Insects - insect jelly
        Mechanoids
         */
        // sentients    Humans - cannibalism / war - empathy 
        // equality
        bool dietNoMammalMeat = Math.GetAverage(rand, food, animals, fortitude) < 30;
        //int100 insects = Math.GetAverage(Sensing, positivity, 100 - touch, exploration);


        // violence vs peace




        /* 
        Apparel / Nudity? (Wealth, comfort, beauty, quality influence?)
        Tainted apparel


        Item Quality (perfectionist? wealth)

        */
        int100 diligence = Math.GetAverage(Turbulant, Sensing, Judging);
        int100 materialism = Math.GetAverage(Turbulant, diligence, awareness);
    }
}
