using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ImGuiNET;
using Starflow.Editor.Utils;

namespace Starflow.Editor
{
    public class StarflowEditor : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public ImGuiRenderer ImGuiRenderer;
        private EditorLayer imGuiLayer;
        public static readonly new ComponentList Components = new ComponentList();
        
        // Propreties
        internal static Scene currentEditorScene;
        private float menuBarHeight;
        public RenderTarget2D sceneRenderTarget;
        private GameObject editorCamObj;
        private EditorCameraComponent editorCamera;
        
        public static StarflowEditor instance { get; set; }
        
        public StarflowEditor()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            Window.AllowUserResizing = true;
            editorCamObj = new GameObject("");
            EditorCameraComponent ec = editorCamObj.AddComponent<EditorCameraComponent>();
            editorCamera = ec;
        }

        protected override void Initialize()
        {
            ImGuiRenderer = new ImGuiRenderer(this);
            ImGuiRenderer.RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            base.Initialize();

            graphics.PreferredBackBufferWidth = 1646;
            graphics.PreferredBackBufferHeight = 922;
            graphics.ApplyChanges();
            Window.Title = $"Starflow Software Development Kit - {EditorProperties.ProjectLocation}";
            
            imGuiLayer = new EditorLayer();
            imGuiLayer.Init();
            
            UpdateRenderTexture(GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight);

            currentEditorScene = new Scene();
            currentEditorScene.name = "te";
            System.Collections.Generic.List<GameObject> gameObjects = new System.Collections.Generic.List<GameObject>();
            for (int i = 0; i < 120; i++)
            {
                gameObjects.Add(new GameObject($"Test{i}"));
                if (i == 0)
                {
                    gameObjects[0].AddComponent<SpriteRenderer>();
                    gameObjects[0].AddComponent<AudioSource>();

                }
            }
            currentEditorScene.gameObjects = gameObjects;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Time.frameCount++;
            
            editorCamera.Update();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            StarflowEditor.instance.UpdateRenderTexture((int)SceneView.wSize.X, (int)SceneView.wSize.Y);
            
            GraphicsDevice.SetRenderTarget(sceneRenderTarget);
            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };
            
            GraphicsDevice.Clear(Colors.Hex2RGB("474747"));
            
            var viewport = GraphicsDevice.Viewport;
            var translation = editorCamera.View.Translation;
            var spriteBatchTransformation = Matrix.CreateTranslation(viewport.Width / 2 / 1, viewport.Height / 2 / 1, 0) *
                                            Matrix.CreateTranslation(translation.X, -translation.Y, 0)
                                            * Matrix.CreateScale(1);
            
            spriteBatch.Begin(transformMatrix: spriteBatchTransformation);
            SceneEditor.Draw(spriteBatch, editorCamera);
            spriteBatch.End();
            
            GraphicsDevice.SetRenderTarget(null);

            ImGuiRenderer.BeforeLayout(gameTime);
            imGuiLayer.SceneImGui();

            ImGuiRenderer.AfterLayout();
            
            base.Draw(gameTime);
        }

        public void UpdateRenderTexture(int width, int height)
        {
            if (sceneRenderTarget != null)
                sceneRenderTarget.Dispose();
            
            sceneRenderTarget = new RenderTarget2D(
                GraphicsDevice,
                width,
                height,
                false,
                GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }
    }
}