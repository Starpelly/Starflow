using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using ImGuiNET;
using Microsoft.Xna.Framework.Graphics;

using Starflow.Editor.Runtime;

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
            float toolbarSize = 46;
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
                GameRuntime.Run();
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