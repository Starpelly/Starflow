using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Tickflow
{
    public abstract class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ContentManager ContentManager;

        public Color bgColor = Color.Black;

        public static readonly new ComponentList Components = new ComponentList();

        private static Scene currentScene;

        static internal Camera currentCamera;

        public static GameManager Instance { get; set; }

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ContentManager = Content;
            Instance = this;
        }

        protected override void Initialize()
        {
            Graphics.Init(this);
            base.Initialize();
            Init();
            IsFixedTimeStep = false; // VSYNC?
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
            Time.frameCount++;
            if ((DateTime.Now - Time._lastTime).TotalSeconds >= 1) // One second has elapsed
            {
                Time._fps = Time.frameCount;
                Time.frameCount = 0;
                Time._lastTime = DateTime.Now;
            }

            Components.EarlyUpdate();
            Components.Update();
            Components.LateUpdate();

            if (currentCamera != null)
            {
                currentCamera.UpdateCamera(GraphicsDevice.Viewport);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color((float)Math.Sin(Time.time), 1, 0, 255));

            if (currentCamera != null)
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, currentCamera.Transform);
            else
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            Draw(_spriteBatch, gameTime);
            Components.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void ChangeScene(Scene newScene)
        {
            currentScene = newScene;
            currentScene.Init();
        }

        internal void SetCamera(Camera cam)
        {
            cam.Bounds = GraphicsDevice.Viewport.Bounds;
            currentCamera = cam;
        }

        public abstract void Start();
        public abstract void Init();
        public abstract void Draw(SpriteBatch sb, GameTime gameTime);
    }
}
