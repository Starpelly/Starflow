using System.Diagnostics;
using System.Numerics;
using ImGuiNET;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow.Editor
{
    public class Toolbar : View
    {
        public static IntPtr RunGameBTN;
        public static IntPtr RunSceneBTN;
        public static IntPtr BuildBTN;
        public static IntPtr ExportBTN;
        public static IntPtr InfoBTN;


        public static void Init()
        {
            RunGameBTN = StarflowEditor.instance.ImGuiRenderer.BindTexture(Texture2D.FromFile(StarflowEditor.instance.GraphicsDevice,
                @"Resources\Icons\playfromstart.png"));
            RunSceneBTN = StarflowEditor.instance.ImGuiRenderer.BindTexture(Texture2D.FromFile(StarflowEditor.instance.GraphicsDevice,
                @"Resources\Icons\playscene.png"));
            BuildBTN = StarflowEditor.instance.ImGuiRenderer.BindTexture(Texture2D.FromFile(StarflowEditor.instance.GraphicsDevice,
                @"Resources\Icons\build.png"));
            ExportBTN = StarflowEditor.instance.ImGuiRenderer.BindTexture(Texture2D.FromFile(StarflowEditor.instance.GraphicsDevice,
                @"Resources\Icons\package.png"));
            InfoBTN = StarflowEditor.instance.ImGuiRenderer.BindTexture(Texture2D.FromFile(StarflowEditor.instance.GraphicsDevice,
                @"Resources\Icons\info.png"));
        }
        
        public static void Imgui(float menuBarHeight)
        {
            float toolbarSize = 50;
            ImGuiViewportPtr viewport = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(new Vector2(viewport.Pos.X, viewport.Pos.Y + menuBarHeight - 1));
            ImGui.SetNextWindowSize(new Vector2(viewport.Size.X, toolbarSize));
            ImGui.SetNextWindowViewport(viewport.ID);

            ImGuiWindowFlags flags = ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoTitleBar |
                                     ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove |
                                     ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoSavedSettings | ImGuiWindowFlags.NoScrollWithMouse;
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 1);
            ImGui.Begin("Toolbar", flags);
            ImGui.PopStyleVar();

            if (ImGui.ImageButton(RunGameBTN, new Vector2(30, 30)))
            {
                string projLoc = EditorProperties.ProjectLocation + @"\Sandbox.csproj";
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine($"dotnet.exe build {projLoc}");
                cmd.StandardInput.WriteLine($"cd {EditorProperties.ProjectLocation}");
                cmd.StandardInput.WriteLine($"dotnet.exe run");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                // Debug.Log(cmd.StandardOutput.ReadToEnd());
                // cmd.WaitForExit();
            }
            ImGui.SameLine();
            ImGui.ImageButton(RunSceneBTN, new Vector2(30, 30));
            ImGui.SameLine();
            ImGui.ImageButton(BuildBTN, new Vector2(30, 30));
            ImGui.SameLine();
            ImGui.ImageButton(ExportBTN, new Vector2(30, 30));
            ImGui.SameLine();
            ImGui.ImageButton(InfoBTN, new Vector2(30, 30));
            
            ImGui.End();
        }
    }
}