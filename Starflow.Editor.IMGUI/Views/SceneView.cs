using ImGuiNET;
using System;
using System.Numerics;

namespace Starflow.Editor
{
    public class SceneView : View
    {
        public static Vector2 wSize = new Vector2(1280, 720);
        public static Vector2 wPos = new Vector2(1280, 720);
        
        public static void Imgui()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0, 0));
            ImGui.Begin("Scene");
            {
                ImGui.BeginChild("Scene Render");
                {
                    wSize = ImGui.GetWindowSize();
                    wPos = ImGui.GetWindowPos() + new Vector2(StarflowEditor.instance.Window.Position.X, StarflowEditor.instance.Window.Position.Y);
                    ImGui.Image(StarflowEditor.instance.ImGuiRenderer.BindTexture(StarflowEditor.instance.sceneRenderTarget), wSize);
                }
                ImGui.EndChild();
            }
            ImGui.End();
            ImGui.PopStyleVar();
        }
    }
}