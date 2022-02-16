using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tickflow.Editor
{
    public static class AssetBrowser
    {
        private static int nodeClicked = 0;

        public static void Imgui()
        {
            string testPath = @"C:\Dev\Tickflow\ExampleGame\Resources";
            string[] files = Directory.GetFiles(testPath, "*", SearchOption.AllDirectories);
            string[] directories = Directory.GetDirectories(testPath, "*", SearchOption.AllDirectories);
            ImGui.Begin("Asset Browser");

            ImGuiTreeNodeFlags nodeflags = ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.NoTreePushOnOpen;
            for (int i = 0; i < files.Length; i++)
            {
                bool isSelected = (nodeClicked == i);
                if (isSelected)
                    nodeflags = ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.NoTreePushOnOpen | ImGuiTreeNodeFlags.Selected;

                string fileName = Path.GetFileName(files[i]);
                ImGui.TreeNodeEx(fileName, nodeflags);
                if (ImGui.IsItemClicked() && !ImGui.IsItemToggledOpen())
                {
                    nodeClicked = i;
                }
            }
            foreach (string directory in directories)
            {
                string directoryName = Path.GetFileName(Path.GetDirectoryName(directory));
                ImGui.Text(directoryName);
            }

            ImGui.End();
        }
    }
}
