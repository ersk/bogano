using Ersk.Simulation.DataTypes;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Animals
{
    public class Animal_Attributes
    {
        private SexEnum sex;

        private Random rand = new Random();

        // physical
        private HeightStat height;         // Display Value 0cm - 1000cm             // 150 - 200 males (-13cm for females)  - max height when fully grown
        private WeightStat weight;         // 70 - 85kg   - divide by 2 -  actual range is 0.5kg to 500kg - 6k for elephant - each unit is 100g
        private int1000 strength;        // soldier can carry 55kg
        private int1000 athleticism;    // speed & agility
        private int1000 coordination;   // & balance / stability?
        private int1000 stamina;
        private int1000 flexibility;
        // Athleticism => jump

        //  weight carried
        /*
         * Physical stats affected by:
         *  - health/condition
         *  - weight carried
         *  - weather? (when outside)
         */

        public SexEnum Sex => sex;

        public HeightStat Height => height;
        public WeightStat Weight => weight;


        public Animal_Attributes GenerateHumanPotential()
        {
            Animal_Attributes human = new Animal_Attributes();

            // Sex
            if (rand.Next(2) == 0)
            {
                sex = SexEnum.Female;
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else
            {
                sex = SexEnum.Male;
                //Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            // Height
            //int heightRange = 50;
            int heightMin = sex == SexEnum.Female ? 135 : 150;

            double mean = sex == SexEnum.Female ? 160 : 175;

            Normal normal = new Normal(mean, 50 / 6, rand);
            height = (int)Math.Round(normal.Sample());

            //height = BezierCurve.GetValue(heightMin, heightRange, out float heightT);

            // Weight
            //int weightRange = 50;
            //int weightMin = sex == SexEnum.Female ? 700 : 850;
            double weightMean = sex == SexEnum.Female ? 690 : 840;

            // 12kg std deviation
            Normal weightNormal = new Normal(weightMean, 120, rand);
            weight = (int)Math.Round(weightNormal.Sample());

            //weight = BezierCurve.GetValue(weightMin, weightRange, heightT, out _);


            Normal physicalNormal = new Normal(50, 12, rand);
            strength = (int)Math.Round(physicalNormal.Sample());
            athleticism = (int)Math.Round(physicalNormal.Sample());
            coordination = (int)Math.Round(physicalNormal.Sample());
            stamina = (int)Math.Round(physicalNormal.Sample());
            flexibility = (int)Math.Round(physicalNormal.Sample());


            return human;
        }
    }

}
