using ImGuiNET;
using System;
using System.Numerics;

namespace Starflow.Editor
{
    public class GameView : View
    {
        public static Vector2 wSize = new Vector2(1280, 720);
        public static Vector2 wPos = new Vector2(1280, 720);

        public static void Imgui()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0, 0));
            ImGui.Begin("Game");
            {
                
            }
            ImGui.End();
            ImGui.PopStyleVar();
        }
    }
}