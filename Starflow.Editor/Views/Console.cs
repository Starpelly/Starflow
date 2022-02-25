using ImGuiNET;
using System;

namespace Starflow.Editor
{
    public class Console : View
    {
        public static void Imgui()
        {
            ImGui.Begin("Console");
            
            if (ImGui.Button("Clear")) { Debug.LogString = string.Empty; }
            ImGui.Separator();
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new System.Numerics.Vector2(0, 1));

            ImGui.BeginChild("scrolling");
            ImGui.TextUnformatted(Debug.LogString);
            ImGui.SetScrollHereY(1f);
            ImGui.PopStyleVar();
            ImGui.EndChild();

            ImGui.End();
        }
    }
}