using Ersk43.Bogano.Mono.UI.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;
using System;


namespace Ersk43.Bogano.Mono.UI.Systems
{
    public class UIDraw : DrawSystem
    {
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        Texture2D rectangleTexture;

        public UIDraw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
            : base()
        {
            this.graphicsDevice = graphicsDevice;
            this.spriteBatch = spriteBatch;
            
            rectangleTexture = new(graphicsDevice, 1, 1);
            rectangleTexture.SetData(new[] { Color.White });
        }

        public override void Draw(GameTime gameTime)
        {
            DrawUIEntity(0, 0, 600, 400, UITester.root);
        }

        private void DrawUIEntity(
            int offsetX, int offsetY,
            int maxSizeX, int maxSizeY, 
            Entity entity)
        {
      
            //Components.Size size = UITester.root.Get<Components.Size>();
            //Paintable paint = UITester.root.Get<Paintable>();
            Paintable paint = entity.Get<Paintable>();
            DrawRectangle(offsetX, offsetY, maxSizeX, maxSizeY, paint.FillColor);

            Container container = entity.Get<Container>();
            if (container != null && container.ChildEntities != null)
            {
                //
                // assume flex row
                //
                int childOffsetX = offsetX;
                int childOffsetY = offsetY;
                foreach (int childId in container.ChildEntities)
                {
                    Entity childEntity = BoganoGame.World.GetEntity(childId);
                    Components.Size size = childEntity.Get<Components.Size>();
                    DrawUIEntity(childOffsetX, childOffsetY, size.X, size.Y, childEntity);

                    CalculateNextOffset(entity, size, ref childOffsetX, ref childOffsetY);        
                }
            }

        }

        private void CalculateNextOffset(Entity parentEntity, Components.Size childSize, ref int childOffsetX, ref int childOffsetY)
        {
            DisplayFlex flex;
            if (parentEntity.Has<DisplayFlex>())
            {
                flex = parentEntity.Get<DisplayFlex>();
            }
            else
            {
                //default
                flex = new();
            }

            if (flex.Orientation == OrientationEnum.Column)
            {
                childOffsetY += childSize.Y + flex.Gap;
            }
            else //row
            {
                childOffsetX += childSize.X + flex.Gap;
            }
        }

        private void DrawRectangle(
            int offsetX, int offsetY,
            int sizeX, int sizeY,
            Color color)
        {
            spriteBatch.Draw(
                rectangleTexture,
                new Rectangle(offsetX, offsetY, sizeX, sizeY),
                color);
        }

    }
}
