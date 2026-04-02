using Ersk43.Bogano.Mono.UI.Components;
using Ersk43.Bogano.Mono.UI.Entities;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk43.Bogano.Mono.UI.Systems
{
    internal class UITester : UpdateSystem
    {
        bool isUICreated = false;
        bool isSliderCreated = false;
        public static Entity root = null;
        public override void Update(GameTime gameTime)
        {
            if (isUICreated == false)
            {
                root = FlexFactory.Create(600, 400, Color.DarkOrange);
                //Entity child1 = FlexFactory.Create(300, 120, Color.SeaGreen);
                //Entity child2 = FlexFactory.Create(120, 38, Color.Pink);

                Paintable paint = new(Color.Orchid);
                Components.Size size = new Components.Size(260, 44);
                Entity sliderChild = SliderFactory.Create(paintable: paint, size: size);

                Container rootContainer = root.Get<Container>();
                //rootContainer.ChildEntities.Add(child1.Id);
                //rootContainer.ChildEntities.Add(child2.Id);
                rootContainer.ChildEntities.Add(sliderChild.Id);

                isUICreated = true;
            }
            //if (isSliderCreated == false)
            //{
            //    SliderFactory.Create();
            //}
        }

       
    }
}
