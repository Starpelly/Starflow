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
        public static void Imgui()
        {
            string testPath = @"C:\Dev\Tickflow\ExampleGame\Resources";

            ImGui.Begin("Asset Browser");
            // Debug.Log(GameManager.ContentManager.RootDirectory);
            for (int i = 0; i < LoadAllAssets(testPath).Count; i++)
            {
                ImGui.Text(LoadAllAssets(testPath)[i]);
            }
            ImGui.End();
        }

        public static List<string> LoadAllAssets(string path)
        {
            // ContentManager contentManager = GameManager.ContentManager;
            DirectoryInfo dir = new DirectoryInfo(path);

            List<string> directories = new List<string>();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach(FileInfo file in files)
            {
                string key = Path.GetFullPath(file.FullName);
                directories.Add(key);
            }
            return directories;
        }
    }
}
