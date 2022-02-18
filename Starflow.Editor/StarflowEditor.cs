using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.ImGui;
using ImGuiNET;
using Newtonsoft.Json;

namespace Starflow.Editor
{
    public class StarflowEditor : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        private DynamicGrid _grid;
        private PrimitiveBatch _primitiveBatch;

        public static ImGUIRenderer ImGuiRenderer;
        public static RenderTarget2D SceneRenderTarget;
        internal static readonly new ComponentList Components = new ComponentList();

        private EditorLayer imGuiLayer;
        public Scene currentEditorScene;


        public static StarflowEditor Instance { get; set; }

        public StarflowEditor()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Instance = this;
        }

        protected override void Initialize()
        {
            Instance = this;

            Window.Title = $"Starflow Editor - Sandbox";
            Window.AllowUserResizing = true;

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _primitiveBatch = new PrimitiveBatch(GraphicsDevice);

            SceneRenderTarget = new RenderTarget2D(
                GraphicsDevice,
                GraphicsDevice.PresentationParameters.BackBufferWidth,
                GraphicsDevice.PresentationParameters.BackBufferHeight,
                false,
                GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);

            ImGuiRenderer = new ImGUIRenderer(this).Initialize().RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            var font = ImGui.GetIO().Fonts.AddFontFromFileTTF(@"C:\Windows\Fonts\ARIAL.TTF", 13);


            currentEditorScene = new Scene();
            currentEditorScene.name = "te";
            System.Collections.Generic.List<GameObject> gameObjects = new System.Collections.Generic.List<GameObject>();
            for (int i = 0; i < 120; i++)
            {
                gameObjects.Add(new GameObject($"Test{i}"));
                if (i == 0)
                {
                    gameObjects[0].AddComponent<SpriteRenderer>();
                    gameObjects[0].AddComponent<Sandbox.TestBehaviour>();
                }
            }
            currentEditorScene.gameObjects = gameObjects;
            var stringJson = JsonConvert.SerializeObject(currentEditorScene);


            imGuiLayer = new EditorLayer();
            imGuiLayer.Init();

            _grid = new DynamicGrid(new DynamicGridSettings() { GridSizeInPixels = 32 });
            new SceneEditorWindow();

            EditorProperties.DefaultTheme();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            SceneEditorWindow.Instance.Update(_grid);
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneEditorWindow.Instance.DrawSceneEditor(_spriteBatch, _grid, _primitiveBatch);

            ImGuiRenderer.BeginLayout(gameTime);
            Dockspace();
            imGuiLayer.SceneImGui();

            ImGuiRenderer.EndLayout();
        }

        protected void Dockspace()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(0, 0));
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0f, 0f), ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0f);
            ImGuiWindowFlags dockSpaceFlags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoMove |
                ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus | ImGuiWindowFlags.NoBackground;

            bool p_open = true;
            ImGui.Begin("Dockspace", ref p_open, dockSpaceFlags);
            ImGui.PopStyleVar(2);


            ImGui.DockSpace(ImGui.GetID("Dockspace"), new System.Numerics.Vector2(0, 0), ImGuiDockNodeFlags.PassthruCentralNode);
            ImGui.PopStyleVar();
        }
    }
}
