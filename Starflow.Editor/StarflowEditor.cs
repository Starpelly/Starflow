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
    public class StarflowEditor : GameManager
    {
        public static ImGUIRenderer ImGuiRenderer;
        public static SpriteBatch spriteBatch;
        bool p_open = true;
        public static new StarflowEditor Instance { get; set; }
        public Scene currentEditorScene;
        private ImGuiLayer imGuiLayer;

        public override void Start()
        {
            Instance = this;
            Window.AllowUserResizing = true;

            currentEditorScene = new Scene();
            currentEditorScene.name = "te";
            GameObject test = new GameObject("Ass");
            test.AddComponent<SpriteRenderer>();
            test.AddComponent<ExampleProject.TestBehaviour>();
            currentEditorScene.gameObjects = new System.Collections.Generic.List<GameObject>() 
            { 
                test
            };
            ChangeScene(currentEditorScene);
            var stringJson = JsonConvert.SerializeObject(currentEditorScene);
            // Debug.Log(stringJson);

            imGuiLayer = new ImGuiLayer();
            imGuiLayer.Init();
        }

        public override void Init()
        {
            ImGuiRenderer = new ImGUIRenderer(this).Initialize().RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            var font = ImGui.GetIO().Fonts.AddFontFromFileTTF(@"C:\Windows\Fonts\ARIAL.TTF", 13);

            Window.Title = "Starflow Engine";
            EditorProperties.DefaultTheme();
        }

        public override void Update(Scene currentScn)
        {
            // currentScene = currentScn;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {

            ImGuiRenderer.BeginLayout(gameTime);
            Dockspace();
            imGuiLayer.SceneImGui();

            ImGuiRenderer.EndLayout();
        }

        private void Dockspace()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0f, 0f), ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(Starflow.Window.width, Starflow.Window.height));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0f);
            ImGuiWindowFlags dockSpaceFlags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoMove |
                ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            ImGui.Begin("Dockspace", ref p_open, dockSpaceFlags);
            ImGui.PopStyleVar(2);

            ImGui.DockSpace(ImGui.GetID("Dockspace"));
        }
    }
}
