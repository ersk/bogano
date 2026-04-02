using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk43.Bogano.Mono
{

    public class BodyMorphTesterScene
    {
        private int sg;

        public BodyMorphTesterScene()
        {
            
        }

    }

 

    public class UIRendererSystem
    {

    }

    //public class Entity { };
    public class Flex
    {
        public Flex()
        {
        
        }
        public enum DirectionEnum
        {
            Vertical,
            Horizontal
        }
        public DirectionEnum direction = DirectionEnum.Vertical;

        public List<Entity> entities;
    }

    //public class SliderEntity
    //{
    //    //public Size size;
    //    //public Value value;
    //    //public Range range;
    //    public bool isSliding;
    //}


    public struct Value
    {
        public int value;
    }
    public struct Range
    {
        public int min;
        public int max;
    }

    /*
     * entity = slider
     * 
     * components
     * ---------
     * size
     * value
     * range (min,max)
     */
}
