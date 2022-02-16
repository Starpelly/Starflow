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
            GameViewWindow.imgui();
            MainMenuBar.Imgui(TickflowEditor.Instance);

            if (currentScene.activeGameObject != null)
            {
                Inspector.Imgui(currentScene.activeGameObject);
            }
            Hierarchy.Imgui(currentScene);
            Console.Imgui();
            AssetBrowser.Imgui();
        }
    }
}
