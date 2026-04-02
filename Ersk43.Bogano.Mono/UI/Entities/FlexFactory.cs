using Ersk43.Bogano.Mono.UI.Components;
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
    internal class FlexFactory
    {
        public static Entity Create(
                DisplayType displayType = null,
                DisplayFlex displayFlex = null,
                Paintable paintable = null,
                Padding padding = null,
                Container container = null,
                Components.Size size = null)
        {
            if (displayType == null) displayType = new();
            if (displayFlex == null) displayFlex = new();
            if (paintable == null) paintable = new();
            if (padding == null) padding = new();
            if (container == null) container = new();
            if (size == null) size = new();

            var entity = BoganoGame.World.CreateEntity();
            entity.Attach(displayType);
            entity.Attach(displayFlex);
            entity.Attach(paintable);
            entity.Attach(padding);
            entity.Attach(container);
            entity.Attach(size);
            return entity;
        }

        public static Entity Create(int sizeX, int sizeY)
        {
            Components.Size size = new(sizeX, sizeY);
            return Create(size: size);
        }

        public static Entity Create(int sizeX, int sizeY, Color color,
            Container container = null,
            DisplayFlex displayFlex = null)
        {
            Components.Size size = new(sizeX, sizeY);
            Paintable paint = new(color);
            return Create(
                size: size,
                paintable: paint,
                container: container,
                displayFlex: displayFlex);
        }

    }
}
