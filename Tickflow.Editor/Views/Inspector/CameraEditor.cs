using ImGuiNET;

namespace Tickflow.Editor
{
    [CustomEditor(typeof(Camera))]
    public class CameraEditor : Editor
    {
        public override void Imgui(Component component)
        {
            ImGui.Text("Camera code here");
        }
    }
}
