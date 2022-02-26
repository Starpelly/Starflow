using ImGuiNET;
using System;
using System.Numerics;

namespace Starflow.Editor
{
    public class SceneView : View
    {
        public static void Imgui()
        {
            ImGui.Begin("Scene");
            {
                ImGui.BeginChild("Scene Render");
                Vector2 wSize = ImGui.GetWindowSize();
                ImGui.Image(StarflowEditor.instance.ImGuiRenderer.BindTexture(StarflowEditor.instance.sceneRenderTarget), wSize);
                StarflowEditor.instance.UpdateRenderTexture((int)wSize.X, (int)wSize.Y);
                ImGui.EndChild();
            }

            ImGui.End();
        }
    }
}