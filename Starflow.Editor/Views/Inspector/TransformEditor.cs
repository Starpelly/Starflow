using System.Numerics;

using ImGuiNET;

namespace Starflow.Editor
{
    [CustomEditor(typeof(Transform))]
    public class TransformEditor
    {
        public void Imgui(GameObject gameObject)
        {
            bool open = true;
            if (ImGui.CollapsingHeader("Transform", ref open))
            {
                Vector3 pos = Helpers.XnaVector2Numerics(gameObject.transform.position);
                if (ImGui.DragFloat3("Position", ref pos))
                {
                    gameObject.transform.position = Helpers.Numerics2XnaVector(pos);
                }
                float rot = gameObject.transform.rotation;
                if (ImGui.DragFloat("Rotation", ref rot))
                {
                    gameObject.transform.rotation = rot;
                }
                Vector3 scale = Helpers.XnaVector2Numerics(gameObject.transform.scale);
                if (ImGui.DragFloat3("Scale", ref scale))
                {
                    gameObject.transform.scale = Helpers.Numerics2XnaVector(scale);
                }
            }
        }
    }
}
