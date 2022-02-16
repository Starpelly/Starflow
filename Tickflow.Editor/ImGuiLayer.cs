using Tickflow;
using ImGuiNET;

namespace Tickflow.Editor
{
    public class ImGuiLayer
    {
        private Scene currentScene;

        public void Init()
        {
            currentScene = TickflowEditor.Instance.currentEditorScene;
        }

        public void SceneImGui()
        {
            ImGui.ShowDemoWindow();
            SceneEditorWindow.Imgui();
            GameViewWindow.Imgui();
            MainMenuBar.Imgui(TickflowEditor.Instance);

            Inspector.Imgui(currentScene.activeGameObject);
            Hierarchy.Imgui(currentScene);
            Console.Imgui();
            AssetBrowser.Imgui();
        }
    }
}
