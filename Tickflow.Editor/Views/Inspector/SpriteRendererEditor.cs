using ImGuiNET;

namespace Tickflow.Editor
{
    [CustomEditor(typeof(SpriteRenderer))]
    public class SpriteRendererEditor : Editor
    {
        public override void Imgui(Component component)
        {
            SpriteRenderer spriteRenderer = (SpriteRenderer)component;
            System.Numerics.Vector4 col = new System.Numerics.Vector4(spriteRenderer.color.R / 255f, spriteRenderer.color.G / 255f, spriteRenderer.color.B/ 255f, spriteRenderer.color.A / 255f);
            if (ImGui.ColorPicker4("Color Picker: ", ref col))
            {
                spriteRenderer.color = new Microsoft.Xna.Framework.Color(col.X, col.Y, col.Z, col.W);
            }
        }
    }
}
