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
            SceneEditorWindow.Instance.Imgui();
            // GameViewWindow.Imgui();
            MainMenuBar.Imgui(StarflowEditor.Instance);

            Inspector.Imgui(StarflowEditor.Instance.currentEditorScene.activeGameObject);
            Hierarchy.Imgui(StarflowEditor.Instance.currentEditorScene);
            Console.Imgui();
            AssetBrowser.Imgui();
        }
    }
}
