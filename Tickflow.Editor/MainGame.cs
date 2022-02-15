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
            Window.AllowUserResizing = true;
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
            style.WindowPadding = new System.Numerics.Vector2(8.00f, 8.00f);
            style.FramePadding = new System.Numerics.Vector2(5.00f, 2.00f);
            style.ItemSpacing = new System.Numerics.Vector2(6.00f, 6.00f);
            style.ItemInnerSpacing = new System.Numerics.Vector2(6.00f, 6.00f);
            style.TouchExtraPadding = new System.Numerics.Vector2(0.00f, 0.00f);
            style.IndentSpacing = 25;
            style.ScrollbarSize = 15;
            style.GrabMinSize = 10;
            style.WindowBorderSize = 1;
            style.ChildBorderSize = 1;
            style.PopupBorderSize = 1;
            style.FrameBorderSize = 1;
            style.TabBorderSize = 1;
            style.WindowRounding = 7;
            style.ChildRounding = 4;
            style.FrameRounding = 3;
            style.PopupRounding = 4;
            style.ScrollbarRounding = 9;
            style.GrabRounding = 3;
            style.LogSliderDeadzone = 4;
            style.TabRounding = 4;

            var colors = style.Colors;
            colors[(int)ImGuiCol.Text] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.TextDisabled] = new System.Numerics.Vector4(0.50f, 0.50f, 0.50f, 1.00f);
            colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.10f, 0.10f, 0.10f, 1.00f);
            colors[(int)ImGuiCol.ChildBg] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.00f);
            colors[(int)ImGuiCol.PopupBg] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.92f);
            colors[(int)ImGuiCol.Border] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.29f);
            colors[(int)ImGuiCol.BorderShadow] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.24f);
            colors[(int)ImGuiCol.FrameBg] = new System.Numerics.Vector4(0.05f, 0.05f, 0.05f, 0.54f);
            colors[(int)ImGuiCol.FrameBgHovered] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.54f);
            colors[(int)ImGuiCol.FrameBgActive] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 1.00f);
            colors[(int)ImGuiCol.TitleBg] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.TitleBgActive] = new System.Numerics.Vector4(0.06f, 0.06f, 0.06f, 1.00f);
            colors[(int)ImGuiCol.TitleBgCollapsed] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.MenuBarBg] = new System.Numerics.Vector4(0.14f, 0.14f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarBg] = new System.Numerics.Vector4(0.05f, 0.05f, 0.05f, 0.54f);
            colors[(int)ImGuiCol.ScrollbarGrab] = new System.Numerics.Vector4(0.34f, 0.34f, 0.34f, 0.54f);
            colors[(int)ImGuiCol.ScrollbarGrabHovered] = new System.Numerics.Vector4(0.40f, 0.40f, 0.40f, 0.54f);
            colors[(int)ImGuiCol.ScrollbarGrabActive] = new System.Numerics.Vector4(0.56f, 0.56f, 0.56f, 0.54f);
            colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.33f, 0.67f, 0.86f, 1.00f);
            colors[(int)ImGuiCol.SliderGrab] = new System.Numerics.Vector4(0.34f, 0.34f, 0.34f, 0.54f);
            colors[(int)ImGuiCol.SliderGrabActive] = new System.Numerics.Vector4(0.56f, 0.56f, 0.56f, 0.54f);
            colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.05f, 0.05f, 0.05f, 0.54f);
            colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.54f);
            colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 1.00f);
            colors[(int)ImGuiCol.Header] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.52f);
            colors[(int)ImGuiCol.HeaderHovered] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.36f);
            colors[(int)ImGuiCol.HeaderActive] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 0.33f);
            colors[(int)ImGuiCol.Separator] = new System.Numerics.Vector4(0.28f, 0.28f, 0.28f, 0.29f);
            colors[(int)ImGuiCol.SeparatorHovered] = new System.Numerics.Vector4(0.44f, 0.44f, 0.44f, 0.29f);
            colors[(int)ImGuiCol.SeparatorActive] = new System.Numerics.Vector4(0.40f, 0.44f, 0.47f, 1.00f);
            colors[(int)ImGuiCol.ResizeGrip] = new System.Numerics.Vector4(0.28f, 0.28f, 0.28f, 0.29f);
            colors[(int)ImGuiCol.ResizeGripHovered] = new System.Numerics.Vector4(0.44f, 0.44f, 0.44f, 0.29f);
            colors[(int)ImGuiCol.ResizeGripActive] = new System.Numerics.Vector4(0.40f, 0.44f, 0.47f, 1.00f);
            colors[(int)ImGuiCol.Tab] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.52f);
            colors[(int)ImGuiCol.TabHovered] = new System.Numerics.Vector4(0.14f, 0.14f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.TabActive] = new System.Numerics.Vector4(0.20f, 0.20f, 0.20f, 0.36f);
            colors[(int)ImGuiCol.TabUnfocused] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.52f);
            colors[(int)ImGuiCol.TabUnfocusedActive] = new System.Numerics.Vector4(0.14f, 0.14f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.DockingPreview] = new System.Numerics.Vector4(0.33f, 0.67f, 0.86f, 1.00f);
            colors[(int)ImGuiCol.DockingEmptyBg] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotLines] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotLinesHovered] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogram] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogramHovered] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.TextSelectedBg] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 1.00f);
            colors[(int)ImGuiCol.DragDropTarget] = new System.Numerics.Vector4(0.33f, 0.67f, 0.86f, 1.00f);
            colors[(int)ImGuiCol.NavHighlight] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.NavWindowingHighlight] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 0.70f);
            colors[(int)ImGuiCol.NavWindowingDimBg] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 0.20f);
            colors[(int)ImGuiCol.ModalWindowDimBg] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 0.35f);

            ImGuiRenderer.BeginLayout(gameTime);
            Dockspace();
            currentScene.SceneImGui();
            ImGui.ShowDemoWindow();
            GameViewWindow.imgui();
            MainMenuBar.Imgui(this);

            ImGuiRenderer.EndLayout();
        }

        private void Dockspace()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0f, 0f), ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(Tickflow.Window.width, Tickflow.Window.height));
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
