using Ersk43.Bogano.Mono.UI.Systems;
using Ersk43.Bogano.Mono.UI.Systems.Slider;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.Graphics;

namespace Ersk43.Bogano.Mono
{
    public class BoganoGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static World World { get; private set; }

        public BoganoGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Sprite sprite = new(
            // TODO: use this.Content to load your game content here
            World = new WorldBuilder()
                //.AddSystem(new SliderUpdate())
                //.AddSystem(new SliderDraw(graphics.GraphicsDevice, spriteBatch))
                .AddSystem(new UITester())
                .AddSystem(new UIDraw(graphics.GraphicsDevice, spriteBatch))
                .Build();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            World.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // 11111111 11111111 11111111 11111111
            Color c = new(0x382F25); //(0x252F38);
            GraphicsDevice.Clear(c); //(Color.CornflowerBlue);

            spriteBatch.Begin();
            World.Draw(gameTime);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
