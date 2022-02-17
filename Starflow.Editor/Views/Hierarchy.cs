using ImGuiNET;
using System;

namespace Starflow.Editor
{
    public class Hierarchy : View
    {
        private static int nodeClicked = 0;

        public static void Imgui(Scene currentScene)
        {
            ImGui.Begin("Hierarchy");
            for (int i = 0; i < currentScene.gameObjects.Count; i++)
            {
                ImGuiTreeNodeFlags nodeflags = ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.SpanAvailWidth;

                bool isSelected = (nodeClicked == i);
                if (isSelected)
                    nodeflags = ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.SpanAvailWidth | ImGuiTreeNodeFlags.Selected;

                bool nodeOpen = ImGui.TreeNodeEx((IntPtr)i, nodeflags, currentScene.gameObjects[i].name);
                if (ImGui.IsItemClicked() && !ImGui.IsItemToggledOpen())
                {
                    nodeClicked = i;
                    currentScene.SetActiveGameObject(currentScene.gameObjects[i]);
                    // ImGui.TreePop();
                }
                if (nodeOpen)
                {
                    // child bullshit here
                    ImGui.TreePop();
                }
            }

            if (ImGui.BeginPopupContextWindow())
            {
                if (ImGui.Selectable("Create Empty"))
                {
                    currentScene.gameObjects.Add(new GameObject("GameObject"));
                }
                ImGui.EndPopup();
            }

            ImGui.End();
        }
    }
}
