using Starflow;
using ImGuiNET;

namespace Starflow.Editor
{
    public class ImGuiLayer
    {
        private Scene currentScene;

        public void Init()
        {
            currentScene = StarflowEditor.Instance.currentEditorScene;
        }

        public void SceneImGui()
        {
            ImGui.ShowDemoWindow();
            SceneEditorWindow.Imgui();
            GameViewWindow.Imgui();
            MainMenuBar.Imgui(StarflowEditor.Instance);

            Inspector.Imgui(currentScene.activeGameObject);
            Hierarchy.Imgui(currentScene);
            Console.Imgui();
            AssetBrowser.Imgui();
        }
    }
}
