using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using ImGuiNET;

namespace Tickflow.Editor
{
    public class MainMenuBar : View
    {
        public static void Imgui(TickflowEditor mainGame)
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("New"))
                    {

                    }
                    if (ImGui.MenuItem("Open"))
                    {

                    }
                    if (ImGui.MenuItem("Save"))
                    {

                    }
                    if (ImGui.MenuItem("Save As"))
                    {

                    }
                    ImGui.Separator();
                    if (ImGui.MenuItem("Exit", "Alt+F4"))
                    {
                        mainGame.Exit();
                    }
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem("Undo", "CTRL+Z"))
                    {
                        Debug.Log("na");
                    }
                    if (ImGui.MenuItem("Redo", "CTRL+Y or CTRL+ALT+Z"))
                    {
                        Debug.Log("na");
                    }
                    ImGui.Separator();
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("View"))
                {
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Help"))
                {
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Tools"))
                {
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
        }

        static IEnumerable<Type> GetTypesWithAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(CustomEditor), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
