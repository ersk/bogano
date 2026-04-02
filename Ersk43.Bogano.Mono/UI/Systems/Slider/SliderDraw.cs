using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using MonoGame.Extended.Graphics;
using System;


namespace Ersk43.Bogano.Mono.UI.Systems.Slider
{
    //public class SliderDraw : EntityDrawSystem
    //{
    //    GraphicsDevice graphicsDevice;
    //    SpriteBatch spriteBatch;

    //    public SliderDraw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    //        : base(Aspect.One(typeof(SliderEntity)))
    //    {
    //        this.graphicsDevice = graphicsDevice;
    //        this.spriteBatch = spriteBatch;
    //    }

    //    public override void Draw(GameTime gameTime)
    //    {
    //        Texture2D tex2d = new(graphicsDevice, 1, 1);
    //        tex2d.SetData(new[] { Color.White });
    //        Sprite spr = new Sprite(tex2d);
    //        Transform2 trans2 = new();
    //        //spr.Color = Color.Red;//new(0x6B5945);

    //        spriteBatch.Draw(
    //            tex2d,
    //            new Rectangle(0, 0, 160, 38),
    //            Color.Red);


    //    }

    //    public override void Initialize(IComponentMapperService mapperService)
    //    {

    //    }
    //}
}
