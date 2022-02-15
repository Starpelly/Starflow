using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Tickflow;

using MonoGame.ImGui;
using ImGuiNET;

namespace Tickflow.Editor
{
    public class MainGame : GameManager
    {
        public static ImGUIRenderer ImGuiRenderer;
        public static SpriteBatch spriteBatch;
        bool p_open = true;
        private Scene currentScene;

        public override void Start()
        {
            ChangeScene(new TestScene());
        }

        public override void Init()
        {
            ImGuiRenderer = new ImGUIRenderer(this).Initialize().RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;

            Window.Title = "Tickflow Engine";
        }

        public override void Update(Scene currentScene)
        {
            this.currentScene = currentScene;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {
            var style = ImGui.GetStyle();
            style.WindowRounding = 5.3f;
            style.FrameRounding = 2.3f;
            style.ScrollbarRounding = 0;

            var colors = style.Colors;
            colors[(int)ImGuiCol.TextDisabled] = new System.Numerics.Vector4(0.60f, 0.60f, 0.60f, 1.00f);
            colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.09f, 0.09f, 0.15f, 1.00f);
            colors[(int)ImGuiCol.PopupBg] = new System.Numerics.Vector4(0.05f, 0.05f, 0.10f, 0.85f);
            colors[(int)ImGuiCol.Border] = new System.Numerics.Vector4(0.70f, 0.70f, 0.70f, 0.65f);
            colors[(int)ImGuiCol.BorderShadow] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.00f);
            colors[(int)ImGuiCol.FrameBg] = new System.Numerics.Vector4(0.00f, 0.00f, 0.01f, 1.00f);
            colors[(int)ImGuiCol.FrameBgHovered] = new System.Numerics.Vector4(0.90f, 0.80f, 0.80f, 0.40f);
            colors[(int)ImGuiCol.FrameBgActive] = new System.Numerics.Vector4(0.90f, 0.65f, 0.65f, 0.45f);
            colors[(int)ImGuiCol.TitleBg] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.83f);
            colors[(int)ImGuiCol.TitleBgCollapsed] = new System.Numerics.Vector4(0.40f, 0.40f, 0.80f, 0.20f);
            colors[(int)ImGuiCol.TitleBgActive] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.87f);
            colors[(int)ImGuiCol.MenuBarBg] = new System.Numerics.Vector4(0.01f, 0.01f, 0.02f, 0.80f);
            colors[(int)ImGuiCol.ScrollbarBg] = new System.Numerics.Vector4(0.20f, 0.25f, 0.30f, 0.60f);
            colors[(int)ImGuiCol.ScrollbarGrab] = new System.Numerics.Vector4(0.55f, 0.53f, 0.55f, 0.51f);
            colors[(int)ImGuiCol.ScrollbarGrabHovered] = new System.Numerics.Vector4(0.56f, 0.56f, 0.56f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarGrabActive] = new System.Numerics.Vector4(0.56f, 0.56f, 0.56f, 0.91f);
            colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.90f, 0.90f, 0.90f, 0.83f);
            colors[(int)ImGuiCol.SliderGrab] = new System.Numerics.Vector4(0.70f, 0.70f, 0.70f, 0.62f);
            colors[(int)ImGuiCol.SliderGrabActive] = new System.Numerics.Vector4(0.30f, 0.30f, 0.30f, 0.84f);
            colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.48f, 0.72f, 0.89f, 0.49f);
            colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.50f, 0.69f, 0.99f, 0.68f);
            colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.80f, 0.50f, 0.50f, 1.00f);
            colors[(int)ImGuiCol.Header] = new System.Numerics.Vector4(0.30f, 0.69f, 1.00f, 0.53f);
            colors[(int)ImGuiCol.HeaderHovered] = new System.Numerics.Vector4(0.44f, 0.61f, 0.86f, 1.00f);
            colors[(int)ImGuiCol.HeaderActive] = new System.Numerics.Vector4(0.38f, 0.62f, 0.83f, 1.00f);
            colors[(int)ImGuiCol.ResizeGrip] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 0.85f);
            colors[(int)ImGuiCol.ResizeGripHovered] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 0.60f);
            colors[(int)ImGuiCol.ResizeGripActive] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 0.90f);
            colors[(int)ImGuiCol.PlotLines] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.PlotLinesHovered] = new System.Numerics.Vector4(0.90f, 0.70f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogram] = new System.Numerics.Vector4(0.90f, 0.70f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogramHovered] = new System.Numerics.Vector4(1.00f, 0.60f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.TextSelectedBg] = new System.Numerics.Vector4(0.00f, 0.00f, 1.00f, 0.35f);

            ImGuiRenderer.BeginLayout(gameTime);
            Dockspace();
            currentScene.SceneImGui();
            ImGui.ShowDemoWindow();
            GameViewWindow.imgui();
            // MainMenuBar();

            ImGuiRenderer.EndLayout();
        }

        private void MainMenuBar()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem("Undo", "CTRL+Z"))
                    {
                        Debug.Log("na");
                    }
                    ImGui.Separator();
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
        }

        private void Dockspace()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0f, 0f), ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(Tickflow.Window.width, Tickflow.Window.height));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0f);
            ImGuiWindowFlags dockSpaceFlags = ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoMove |
                ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            ImGui.Begin("Dockspace", ref p_open, dockSpaceFlags);
            ImGui.PopStyleVar(2);

            ImGui.DockSpace(ImGui.GetID("Dockspace"));
        }
    }
}
