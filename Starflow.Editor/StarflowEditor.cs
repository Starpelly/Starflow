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
            GameObject test = new GameObject("Ass");
            test.AddComponent<SpriteRenderer>();
            test.AddComponent<Sandbox.TestBehaviour>();
            currentEditorScene.gameObjects = new System.Collections.Generic.List<GameObject>()
            {
                test
            };
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
            PreDrawScene();

            GraphicsDevice.Clear(Color.Black);
            ImGuiRenderer.BeginLayout(gameTime);
            Dockspace();
            imGuiLayer.SceneImGui();

            ImGuiRenderer.EndLayout();
        }

        protected void PreDrawScene()
        {
            GraphicsDevice.SetRenderTarget(SceneRenderTarget);
            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            SceneEditorWindow.Instance.DrawSceneEditor(_spriteBatch, _grid, _primitiveBatch);

            GraphicsDevice.SetRenderTarget(null);
        }

        protected void Dockspace()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(0, 0));
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0f, 0f), ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0f);
            ImGuiWindowFlags dockSpaceFlags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoMove |
                ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            bool p_open = true;
            ImGui.Begin("Dockspace", ref p_open, dockSpaceFlags);
            ImGui.PopStyleVar(2);

            ImGui.DockSpace(ImGui.GetID("Dockspace"));
            ImGui.PopStyleVar();
        }
    }
}
