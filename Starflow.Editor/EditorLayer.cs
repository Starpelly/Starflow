using System.Numerics;
using Starflow;
using ImGuiNET;

namespace Starflow.Editor
{
    public class EditorLayer
    {
        public void Init()
        {
        }

        public void SceneImGui()
        {
            ImGui.ShowDemoWindow();
            // SceneEditorWindow.Instance.Imgui();
            // GameViewWindow.Imgui();
            MainMenuBar.Imgui();
// 
            Inspector.Imgui(StarflowEditor.currentEditorScene.activeGameObject);
            Hierarchy.Imgui(StarflowEditor.currentEditorScene);
            Console.Imgui();
            AssetBrowser.Imgui();
        }
    }
}