using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Starflow.Editor
{
    public static class AssetBrowser
    {
        public static void Imgui()
        {
            string[] files = Directory.GetFiles(EditorProperties.ProjectLocation, "*", SearchOption.AllDirectories);
            ImGuiTreeNodeFlags nodeflags = ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.NoTreePushOnOpen;

            ImGui.Begin("Asset Browser");

            foreach (var file in files)
            {
                var relative = GetRelativePath(EditorProperties.ProjectLocation, file).Replace("\\", "/");

                bool cont = false;
                for (int i = 0; i < EditorProperties.ExcludeFiles.Length; i++)
                {
                    if (relative.Contains(EditorProperties.ExcludeFiles[i]))
                    {
                        cont = true;
                    }
                }
                if (cont) continue;

                string fileName = Path.GetFileName(file);
                ImGui.TreeNodeEx(fileName, nodeflags);
            }

            ImGui.End();
        }

        private static string GetRelativePath(string relativeTo, string path)
        {
            if (!relativeTo.EndsWith(Path.DirectorySeparatorChar.ToString()))
                relativeTo += Path.DirectorySeparatorChar;
            return path.Replace(relativeTo, "");
        }
    }
}
