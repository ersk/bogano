using Ersk43.Bogano.Mono.UI.Components;
using Ersk43.Bogano.Mono.UI.Constants;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ersk43.Bogano.Mono.UI.Entities
{
    internal static class SliderFactory
    {
        public static Entity Create(
            DisplayType displayType = null,
            Paintable paintable = null,
            Padding padding = null,
            Components.Size size = null)
        {
            // Textbox
            Entity textbox = CreateTextbox(size);

            // Slider
            Entity slider = CreateSlider(size);

            // Add children to container
            List<int> rootChildren = new List<int>() { textbox.Id, slider.Id };
            Container container = new(rootChildren);

            // Create root
            Entity root = FlexFactory.Create(
                 displayType,
                 new DisplayFlex(OrientationEnum.Column, 11),
                 paintable,
                 padding,
                 container,
                 size);

            return root;
        }

        private static Entity CreateTextbox(Components.Size size)
        {
            Entity textbox = FlexFactory.Create(size.X, 16, Color.GreenYellow);
            Entity text = FlexFactory.Create(37, 8, Colors.BrightBlue);
            Container textboxContainer = textbox.Get<Container>();
            textboxContainer.ChildEntities.Add(text.Id);
            return textbox;
        }

        private static Entity CreateSlider(Components.Size size)
        {
            int gap = 8;

            // create valueLabel
            int valueLabelX = 43;
            Entity valueLabel = FlexFactory.Create(valueLabelX, 15, Color.White);

            // create input
            int inputWidth = size.X - valueLabelX - gap;
            Entity input = CreateInput(new(inputWidth, size.Y));

            // create slider
            Container sliderContainer = new(new List<int>() { input.Id, valueLabel.Id  });
            DisplayFlex flex = new(OrientationEnum.Row, gap);
            Entity slider = FlexFactory.Create(size.X, size.Y, Color.Transparent, sliderContainer, flex);
            return slider;
        }
        private static Entity CreateInput(Components.Size size)
        {
            Entity railHandle = FlexFactory.Create(8, size.Y, Colors.BrightBlue);
            Entity rail = FlexFactory.Create(size.X, 8, Colors.Navy);

            Container inputContainer = new(new List<int>() { rail.Id, railHandle.Id });                       
            Entity input = FlexFactory.Create(size.X, size.Y, Color.Red, inputContainer);
            return input;
        }
    }
}
