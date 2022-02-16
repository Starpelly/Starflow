using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public abstract class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager ContentManager;

        public Color bgColor = Color.Black;

        public static readonly new ComponentList Components = new ComponentList();

        public static Scene currentScene;

        static internal Camera currentCamera;

        public static RenderTarget2D TestRenderTarget;

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
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            base.Initialize();
            Init();
            IsFixedTimeStep = false; // VSYNC?

            TestRenderTarget = new RenderTarget2D(
                GraphicsDevice,
                GraphicsDevice.PresentationParameters.BackBufferWidth,
                GraphicsDevice.PresentationParameters.BackBufferHeight,
                false,
                GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            GraphicsDevice.SetRenderTarget(TestRenderTarget);
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
            Update(currentScene);

            if (currentCamera != null)
            {
                currentCamera.UpdateCamera(GraphicsDevice.Viewport);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(TestRenderTarget);
            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            DrawScene(gameTime);

            GraphicsDevice.SetRenderTarget(null);

            Draw(_spriteBatch, gameTime);
            base.Draw(gameTime);

            /*_spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone);
            _spriteBatch.Draw(TestRenderTarget, new Rectangle(0, 0, 1280, 720), Color.White);
            _spriteBatch.End();*/
        }

        private void DrawScene(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color((float)Math.Sin(Time.time), 1, 0, 255));
            // GraphicsDevice.Clear(Color.Cyan);

            if (currentCamera != null)
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, currentCamera.Transform);
            else
                _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            Components.Draw();

            _spriteBatch.End();
        }

        public static void ChangeScene(Scene newScene)
        {
            currentScene = newScene;
            // currentScene.Init();
        }

        internal void SetCamera(Camera cam)
        {
            cam.Bounds = GraphicsDevice.Viewport.Bounds;
            currentCamera = cam;
        }

        public abstract void Start();
        public abstract void Update(Scene currentScene);
        public abstract void Init();
        public abstract void Draw(SpriteBatch sb, GameTime gameTime);
    }
}
