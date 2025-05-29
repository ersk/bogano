using Ersk.Simulation.DataTypes;
using Ersk.Simulation.Generation;
using LocationMap.Map;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities
{
    internal class Animal_PhysicalEntity : PhysicalEntity
    {
        // genetics + environment




        // learned abilities

        public Animal_Attributes currentAttributes;
        //public Animal_Attributes potentialAttributes;

        public Animal_PhysicalEntity()
        {
            currentAttributes = new Animal_Attributes();
            currentAttributes.GenerateHumanPotential();
        }
    }

    internal class Animal_PhysicalEntity_Definition
    {

    }

    public enum SexEnum
    {
        Unknown,
        Asexual,
        Female,
        Male
    }

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

        // mental
        private int100 introversionExtroversion;
        private int100 intuitionSensing;
        private int100 feelingThinking;
        private int100 judgingPerceiving;
        private int100 assertiveTurbulant;


        public SexEnum Sex => sex;

        public HeightStat Height => height;
        public WeightStat Weight => weight;

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

            introversionExtroversion = (int)Math.Round(physicalNormal.Sample());
            intuitionSensing = (int)Math.Round(physicalNormal.Sample());
            feelingThinking = (int)Math.Round(physicalNormal.Sample());
            judgingPerceiving = (int)Math.Round(physicalNormal.Sample());
            assertiveTurbulant = (int)Math.Round(physicalNormal.Sample());

            return human;
        }
    }



    public struct HeightStat
    {
        // 1 = 1cm
        private const int minValue = 0;
        private const int maxValue = 999;

        private int value;

        public HeightStat(int value)
        {
            this.value = Math.Clamp(value, minValue, maxValue);
        }

        public static HeightStat operator ++(HeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value + 1, minValue, maxValue);
            return heightStat;
        }
        public static HeightStat operator --(HeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value - 1, minValue, maxValue);
            return heightStat;
        }

        public static implicit operator int(HeightStat heightStat)
        {
            return heightStat.value;
        }
        public static implicit operator HeightStat(int intValue)
        {
            return new HeightStat(intValue);
        }

        public override string ToString()
        {
            if (value < 100)
            {
                // 99cm
                return value + "cm";
            }

            // 9.99m
            return (Convert.ToDecimal(value) / 100).ToString("0.00") + "m";
        }
    }
    public struct WeightStat
    {
        // 1 = 100g
        private const int minValue = 0;
        private const int maxValue = 99999;

        private int value;

        public WeightStat(int value)
        {
            this.value = Math.Clamp(value, minValue, maxValue);
        }

        public static WeightStat operator ++(WeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value + 1, minValue, maxValue);
            return heightStat;
        }
        public static WeightStat operator --(WeightStat heightStat)
        {
            heightStat.value = Math.Clamp(heightStat.value - 1, minValue, maxValue);
            return heightStat;
        }

        public static implicit operator int(WeightStat heightStat)
        {
            return heightStat.value;
        }
        public static implicit operator WeightStat(int intValue)
        {
            return new WeightStat(intValue);
        }

        public override string ToString()
        {
            if(value < 1000)
            {
                // 99.9kg
                return (Convert.ToDecimal(value)/10).ToString("0.0") + "kg";
            }

            // 10.0t
            return (Convert.ToDecimal(value) / 10000).ToString("0.0") + "t"; 
        }
    }
}
