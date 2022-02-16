using ImGuiNET;

namespace Starflow.Editor
{
    [CustomEditor(typeof(Camera))]
    public class CameraEditor : Editor
    {
        public override void Imgui(Component component)
        {
            Camera camera = (Camera)component;
            ImGui.SliderFloat("Zoom", ref camera.Zoom, 0, 5);
        }
    }
}
