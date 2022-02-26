using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ImGuiNET;

namespace Starflow.Editor
{
    public class StarflowEditor : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public ImGuiRenderer ImGuiRenderer;
        private EditorLayer imGuiLayer;
        
        // Propreties
        internal static Scene currentEditorScene;
        private float menuBarHeight;
        
        public static StarflowEditor instance { get; set; }
        
        public StarflowEditor()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            Window.AllowUserResizing = true;
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
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            ImGuiRenderer.BeforeLayout(gameTime);
            
            imGuiLayer.SceneImGui();

            ImGuiRenderer.AfterLayout();
            
            base.Draw(gameTime);
        }
    }
}