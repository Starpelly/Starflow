using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public abstract class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public Color bgColor = Color.Black;
        public static readonly new ComponentList Components = new ComponentList();
        public static Scene currentScene;
        static internal Camera currentCamera;
        static internal bool debug { get; set; }
        public static GameManager Instance { get; set; }


        public virtual void Start() { }
        public virtual void GameUpdate(Scene currentScene) { }
        public virtual void Draw(SpriteBatch sb, GameTime gameTime) { }

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Instance = this;
        }

        protected override void Initialize()
        {
            Graphics.Init(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            base.Initialize();
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
            GameUpdate(currentScene);

            if (currentCamera != null)
            {
                currentCamera.UpdateCamera(GraphicsDevice.Viewport);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            DrawScene(gameTime);

            Draw(_spriteBatch, gameTime);
            base.Draw(gameTime);
        }

        private void DrawScene(GameTime gameTime)
        {
            // GraphicsDevice.Clear(new Color((float)Math.Sin(Time.time), 1, 0, 255));
            GraphicsDevice.Clear(Colors.Hex2RGB("304B76")); 

            if (currentCamera != null)
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, currentCamera.Transform);
            else
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            Components.Draw(_spriteBatch);

            _spriteBatch.End();
        }

        public static void ChangeScene(Scene newScene)
        {
            currentScene = newScene;
        }

        internal void SetCamera(Camera cam)
        {
            cam.Bounds = GraphicsDevice.Viewport.Bounds;
            currentCamera = cam;
        }
    }
}
