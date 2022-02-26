using System.Numerics;
using Starflow;
using ImGuiNET;

namespace Starflow.Editor
{
    public class EditorLayer
    {
        private float menuBarHeight;
        
        public void Init()
        {
            EditorProperties.SteamTheme();
            Toolbar.Init();
        }

        public void SceneImGui()
        {
            Dockspace();
            ImGui.ShowDemoWindow();
            // SceneEditorWindow.Instance.Imgui();
            // GameViewWindow.Imgui();
            MainMenuBar.Imgui();
            Toolbar.Imgui(menuBarHeight);
// 
            Inspector.Imgui(StarflowEditor.currentEditorScene.activeGameObject);
            Hierarchy.Imgui(StarflowEditor.currentEditorScene);
            Console.Imgui();
            AssetBrowser.Imgui();
        }
        
        private void Dockspace()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new System.Numerics.Vector2(0, 25));
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0f, 25), ImGuiCond.Always);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(StarflowEditor.instance.GraphicsDevice.PresentationParameters.BackBufferWidth, StarflowEditor.instance.GraphicsDevice.PresentationParameters.BackBufferHeight));
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0f);
            ImGuiWindowFlags dockSpaceFlags = ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse |
                                              ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoBackground | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            bool p_open = true;
            ImGui.Begin("Dockspace", ref p_open, dockSpaceFlags);
            ImGui.PopStyleVar(2);


            menuBarHeight = 20;
            
            ImGui.DockSpace(ImGui.GetID("Dockspace"), new System.Numerics.Vector2(0, 0), ImGuiDockNodeFlags.PassthruCentralNode);
            ImGui.PopStyleVar();
        }
    }
}