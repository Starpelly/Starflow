using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Starflow;

using MonoGame.ImGui;
using ImGuiNET;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Starflow.Editor
{
    public class StarflowEditor : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        public static ImGUIRenderer ImGuiRenderer;
        public static SpriteBatch spriteBatch;
        bool p_open = true;
        public Scene currentEditorScene;
        private EditorLayer imGuiLayer;
        public static RenderTarget2D SceneRenderTarget;
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
            ImGuiRenderer = new ImGUIRenderer(this).Initialize().RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            var font = ImGui.GetIO().Fonts.AddFontFromFileTTF(@"C:\Windows\Fonts\ARIAL.TTF", 13);

            Window.Title = "Starflow Engine";
            EditorProperties.DefaultTheme();

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            SceneRenderTarget = new RenderTarget2D(
                GraphicsDevice,
                GraphicsDevice.PresentationParameters.BackBufferWidth,
                GraphicsDevice.PresentationParameters.BackBufferHeight,
                false,
                GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);

            Instance = this;
            Window.AllowUserResizing = true;

            currentEditorScene = new Scene();
            currentEditorScene.name = "te";
            GameObject test = new GameObject("Ass");
            test.AddComponent<SpriteRenderer>();
            test.AddComponent<Sandbox.TestBehaviour>();
            currentEditorScene.gameObjects = new System.Collections.Generic.List<GameObject>()
            {
                test
            };
            // ChangeScene(currentEditorScene);
            var stringJson = JsonConvert.SerializeObject(currentEditorScene);
            // Debug.Log(stringJson);

            imGuiLayer = new EditorLayer();
            imGuiLayer.Init();
            new SceneEditorWindow();
        }

        protected override void Update(GameTime gameTime)
        {
            SceneEditorWindow.Instance.Update();
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

            SceneEditorWindow.Instance.DrawSceneEditor(_spriteBatch);

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

            ImGui.Begin("Dockspace", ref p_open, dockSpaceFlags);
            ImGui.PopStyleVar(2);

            ImGui.DockSpace(ImGui.GetID("Dockspace"));
            ImGui.PopStyleVar();
        }
    }
}
