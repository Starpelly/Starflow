using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tickflow
{
    public abstract class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Color bgColor = Color.Black;

        public static readonly BehaviourList Behaviours = new BehaviourList();

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Graphics.Init(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Start();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Time.time = (float)gameTime.TotalGameTime.TotalSeconds;

            Behaviours.EarlyUpdate();
            Behaviours.Update();
            Behaviours.LateUpdate();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color((float)Math.Sin(Time.time), 1, 0, 255));

            _spriteBatch.Begin();

            // draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public abstract void Start();
        // public abstract void Update();
        // public abstract void Draw(SpriteBatch sb);
    }
}
