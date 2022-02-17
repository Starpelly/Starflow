using Starflow;
using ImGuiNET;

namespace Starflow.Editor
{
    public class EditorLayer
    {
        private Scene currentScene;

        public void Init()
        {
            currentScene = StarflowEditor.Instance.currentEditorScene;
            new SceneEditorWindow();
        }

        public void SceneImGui()
        {
            // ImGui.ShowDemoWindow();
            SceneEditorWindow.Instance.Imgui();
            // GameViewWindow.Imgui();
            MainMenuBar.Imgui(StarflowEditor.Instance);

            Inspector.Imgui(currentScene.activeGameObject);
            Hierarchy.Imgui(currentScene);
            Console.Imgui();
            AssetBrowser.Imgui();
        }
    }
}
