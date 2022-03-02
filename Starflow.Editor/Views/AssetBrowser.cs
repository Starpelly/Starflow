using ImGuiNET;

namespace Starflow.Editor
{
    public static class AssetBrowser
    {
        public static void Imgui()
        {
            string[] files = Directory.GetFileSystemEntries(EditorProperties.ProjectLocation, "*.*", SearchOption.AllDirectories);
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
                if (Directory.Exists(file))
                {
                    if (ImGui.TreeNode(relative))
                    {

                        ImGui.TreePop();
                    }
                }
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