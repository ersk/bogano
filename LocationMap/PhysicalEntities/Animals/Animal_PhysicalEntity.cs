using Ersk.Simulation.DataTypes;
using Ersk.Simulation.Generation;
using LocationMap.Map;
using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.PhysicalEntities.Animals
{
    internal class Animal_PhysicalEntity : PhysicalEntity
    {
        // genetics + environment
        // gentics => needs ?



        // learned abilities

        /*
         * World Position
         * Items - (and Clothes?)
         * 
         * Skills
         * Health (Physical)
         * Personality (Mental)
         * Thoughs / Mood
         * Activities
         * 
         * State - pos, energy, 
         */

        public Animal_Attributes currentAttributes;
        //public Animal_Attributes potentialAttributes;

        public Animal_PhysicalEntity()
        {
            currentAttributes = new Animal_Attributes();
            currentAttributes.GenerateHumanPotential();
        }
    }









}
