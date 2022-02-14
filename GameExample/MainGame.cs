using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Tickflow;

using MonoGame.ImGui;
using ImGuiNET;

namespace GameExample
{
    public class MainGame : GameManager
    {
        public static ImGUIRenderer ImGuiRenderer;
        public static SpriteBatch spriteBatch;
        bool p_open = true;

        public static System.Numerics.Vector3 testColor;

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

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {
            ImGuiRenderer.BeginLayout(gameTime);
            Dockspace();
            // MainMenuBar();
            ImGui.ShowDemoWindow();

            ImGui.Begin("Test");
            ImGui.ColorEdit3("Color Editor", ref testColor);
            ImGui.End();

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
