using ImGuiNET;

namespace Starflow.Editor
{
    public class EditorProperties
    {
        public static string ProjectLocation = @"C:\Dev\Starflow\Sandbox";
        public static string[] ExcludeFiles = { "obj/", "bin/", ".mgcb", ".csproj", ".manifest" };

        public static float toolbarSize = 50;
        public static float menuBarHeight;

        public static void DefaultTheme()
        {
            var style = ImGui.GetStyle();
            style.ChildRounding = 0.0f;
            style.FrameBorderSize = 1.0f;
            style.FrameRounding = 0.0f;
            style.GrabMinSize = 7.0f;
            style.PopupRounding = 0.0f;
            style.ScrollbarRounding = 12.0f;
            style.ScrollbarSize = 13.0f;
            style.TabBorderSize = 1.0f;
            style.TabRounding = 0.0f;
            style.WindowRounding = 0.0f;
            style.WindowBorderSize = 1.0f;

            var colors = style.Colors;
            colors[(int)ImGuiCol.Text]                   = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 1.000f);
            colors[(int)ImGuiCol.TextDisabled]           = new System.Numerics.Vector4(0.500f, 0.500f, 0.500f, 1.000f);
            colors[(int)ImGuiCol.WindowBg]               = new System.Numerics.Vector4(0.180f, 0.180f, 0.180f, 1.000f);
            colors[(int)ImGuiCol.ChildBg]                = new System.Numerics.Vector4(0.280f, 0.280f, 0.280f, 0.000f);
            colors[(int)ImGuiCol.PopupBg]                = new System.Numerics.Vector4(0.313f, 0.313f, 0.313f, 1.000f);
            colors[(int)ImGuiCol.Border]                 = new System.Numerics.Vector4(0.266f, 0.266f, 0.266f, 1.000f);
            colors[(int)ImGuiCol.BorderShadow]           = new System.Numerics.Vector4(0.000f, 0.000f, 0.000f, 0.000f);
            colors[(int)ImGuiCol.FrameBg]                = new System.Numerics.Vector4(0.160f, 0.160f, 0.160f, 1.000f);
            colors[(int)ImGuiCol.FrameBgHovered]         = new System.Numerics.Vector4(0.200f, 0.200f, 0.200f, 1.000f);
            colors[(int)ImGuiCol.FrameBgActive]          = new System.Numerics.Vector4(0.280f, 0.280f, 0.280f, 1.000f);
            colors[(int)ImGuiCol.TitleBg]                = new System.Numerics.Vector4(0.148f, 0.148f, 0.148f, 1.000f);
            colors[(int)ImGuiCol.TitleBgActive]          = new System.Numerics.Vector4(0.148f, 0.148f, 0.148f, 1.000f);
            colors[(int)ImGuiCol.TitleBgCollapsed]       = new System.Numerics.Vector4(0.148f, 0.148f, 0.148f, 1.000f);
            colors[(int)ImGuiCol.MenuBarBg]              = new System.Numerics.Vector4(0.195f, 0.195f, 0.195f, 1.000f);
            colors[(int)ImGuiCol.ScrollbarBg]            = new System.Numerics.Vector4(0.160f, 0.160f, 0.160f, 1.000f);
            colors[(int)ImGuiCol.ScrollbarGrab]          = new System.Numerics.Vector4(0.277f, 0.277f, 0.277f, 1.000f);
            colors[(int)ImGuiCol.ScrollbarGrabHovered]   = new System.Numerics.Vector4(0.300f, 0.300f, 0.300f, 1.000f);
            colors[(int)ImGuiCol.ScrollbarGrabActive]    = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.CheckMark]              = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 1.000f);
            colors[(int)ImGuiCol.SliderGrab]             = new System.Numerics.Vector4(0.391f, 0.391f, 0.391f, 1.000f);
            colors[(int)ImGuiCol.SliderGrabActive]       = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.Button]                 = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 0.000f);
            colors[(int)ImGuiCol.ButtonHovered]          = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 0.156f);
            colors[(int)ImGuiCol.ButtonActive]           = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 0.391f);
            colors[(int)ImGuiCol.Header]                 = new System.Numerics.Vector4(0.313f, 0.313f, 0.313f, 1.000f);
            colors[(int)ImGuiCol.HeaderHovered]          = new System.Numerics.Vector4(0.469f, 0.469f, 0.469f, 1.000f);
            colors[(int)ImGuiCol.HeaderActive]           = new System.Numerics.Vector4(0.469f, 0.469f, 0.469f, 1.000f);
            colors[(int)ImGuiCol.Separator]              = colors[(int)ImGuiCol.Border];
            colors[(int)ImGuiCol.SeparatorHovered]       = new System.Numerics.Vector4(0.391f, 0.391f, 0.391f, 1.000f);
            colors[(int)ImGuiCol.SeparatorActive]        = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.ResizeGrip]             = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 0.250f);
            colors[(int)ImGuiCol.ResizeGripHovered]      = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 0.670f);
            colors[(int)ImGuiCol.ResizeGripActive]       = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.Tab]                    = new System.Numerics.Vector4(0.098f, 0.098f, 0.098f, 1.000f);
            colors[(int)ImGuiCol.TabHovered]             = new System.Numerics.Vector4(0.352f, 0.352f, 0.352f, 1.000f);
            colors[(int)ImGuiCol.TabActive]              = new System.Numerics.Vector4(0.195f, 0.195f, 0.195f, 1.000f);
            colors[(int)ImGuiCol.TabUnfocused]           = new System.Numerics.Vector4(0.098f, 0.098f, 0.098f, 1.000f);
            colors[(int)ImGuiCol.TabUnfocusedActive]     = new System.Numerics.Vector4(0.195f, 0.195f, 0.195f, 1.000f);
            colors[(int)ImGuiCol.DockingPreview]         = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 0.781f);
            colors[(int)ImGuiCol.DockingEmptyBg]         = new System.Numerics.Vector4(0.180f, 0.180f, 0.180f, 1.000f);
            colors[(int)ImGuiCol.PlotLines]              = new System.Numerics.Vector4(0.469f, 0.469f, 0.469f, 1.000f);
            colors[(int)ImGuiCol.PlotLinesHovered]       = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.PlotHistogram]          = new System.Numerics.Vector4(0.586f, 0.586f, 0.586f, 1.000f);
            colors[(int)ImGuiCol.PlotHistogramHovered]   = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.TextSelectedBg]         = new System.Numerics.Vector4(1.000f, 1.000f, 1.000f, 0.156f);
            colors[(int)ImGuiCol.DragDropTarget]         = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.NavHighlight]           = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.NavWindowingHighlight]  = new System.Numerics.Vector4(1.000f, 0.391f, 0.000f, 1.000f);
            colors[(int)ImGuiCol.NavWindowingDimBg]      = new System.Numerics.Vector4(0.000f, 0.000f, 0.000f, 0.586f);
            colors[(int)ImGuiCol.ModalWindowDimBg]       = new System.Numerics.Vector4(0.000f, 0.000f, 0.000f, 0.586f);
        }

        public static void SteamTheme()
        {
            var style = ImGui.GetStyle();
            style.FrameBorderSize = 1.0f;
            style.WindowRounding = 0.0f;
            style.ChildRounding = 0.0f;
            style.FrameRounding = 0.0f;
            style.PopupRounding = 0.0f;
            style.ScrollbarRounding = 0.0f;
            style.GrabRounding = 0.0f;
            style.TabRounding = 0.0f;

            var colors = style.Colors;
            colors[(int)ImGuiCol.Text] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.TextDisabled] = new System.Numerics.Vector4(0.50f, 0.50f, 0.50f, 1.00f);
            colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.29f, 0.34f, 0.26f, 1.00f);
            colors[(int)ImGuiCol.ChildBg] = new System.Numerics.Vector4(0.29f, 0.34f, 0.26f, 1.00f);
            colors[(int)ImGuiCol.PopupBg] = new System.Numerics.Vector4(0.24f, 0.27f, 0.20f, 1.00f);
            colors[(int)ImGuiCol.Border] = new System.Numerics.Vector4(0.54f, 0.57f, 0.51f, 0.50f);
            colors[(int)ImGuiCol.BorderShadow] = new System.Numerics.Vector4(0.14f, 0.16f, 0.11f, 0.52f);
            colors[(int)ImGuiCol.FrameBg] = new System.Numerics.Vector4(0.24f, 0.27f, 0.20f, 1.00f);
            colors[(int)ImGuiCol.FrameBgHovered] = new System.Numerics.Vector4(0.27f, 0.30f, 0.23f, 1.00f);
            colors[(int)ImGuiCol.FrameBgActive] = new System.Numerics.Vector4(0.30f, 0.34f, 0.26f, 1.00f);
            colors[(int)ImGuiCol.TitleBg] = new System.Numerics.Vector4(0.24f, 0.27f, 0.20f, 1.00f);
            colors[(int)ImGuiCol.TitleBgActive] = new System.Numerics.Vector4(0.29f, 0.34f, 0.26f, 1.00f);
            colors[(int)ImGuiCol.TitleBgCollapsed] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.51f);
            colors[(int)ImGuiCol.MenuBarBg] = new System.Numerics.Vector4(0.24f, 0.27f, 0.20f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarBg] = new System.Numerics.Vector4(0.35f, 0.42f, 0.31f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarGrab] = new System.Numerics.Vector4(0.28f, 0.32f, 0.24f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarGrabHovered] = new System.Numerics.Vector4(0.25f, 0.30f, 0.22f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarGrabActive] = new System.Numerics.Vector4(0.23f, 0.27f, 0.21f, 1.00f);
            colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.SliderGrab] = new System.Numerics.Vector4(0.35f, 0.42f, 0.31f, 1.00f);
            colors[(int)ImGuiCol.SliderGrabActive] = new System.Numerics.Vector4(0.54f, 0.57f, 0.51f, 0.50f);
            colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.29f, 0.34f, 0.26f, 0.40f);
            colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.35f, 0.42f, 0.31f, 1.00f);
            colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.54f, 0.57f, 0.51f, 0.50f);
            colors[(int)ImGuiCol.Header] = new System.Numerics.Vector4(0.35f, 0.42f, 0.31f, 1.00f);
            colors[(int)ImGuiCol.HeaderHovered] = new System.Numerics.Vector4(0.35f, 0.42f, 0.31f, 0.6f);
            colors[(int)ImGuiCol.HeaderActive] = new System.Numerics.Vector4(0.54f, 0.57f, 0.51f, 0.50f);
            colors[(int)ImGuiCol.Separator] = new System.Numerics.Vector4(0.14f, 0.16f, 0.11f, 1.00f);
            colors[(int)ImGuiCol.SeparatorHovered] = new System.Numerics.Vector4(0.54f, 0.57f, 0.51f, 1.00f);
            colors[(int)ImGuiCol.SeparatorActive] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.ResizeGrip] = new System.Numerics.Vector4(0.19f, 0.23f, 0.18f, 0.00f); // grip invis
            colors[(int)ImGuiCol.ResizeGripHovered] = new System.Numerics.Vector4(0.54f, 0.57f, 0.51f, 1.00f);
            colors[(int)ImGuiCol.ResizeGripActive] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.Tab] = new System.Numerics.Vector4(0.35f, 0.42f, 0.31f, 1.00f);
            colors[(int)ImGuiCol.TabHovered] = new System.Numerics.Vector4(0.54f, 0.57f, 0.51f, 0.78f);
            colors[(int)ImGuiCol.TabActive] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.TabUnfocused] = new System.Numerics.Vector4(0.24f, 0.27f, 0.20f, 1.00f);
            colors[(int)ImGuiCol.TabUnfocusedActive] = new System.Numerics.Vector4(0.35f, 0.42f, 0.31f, 1.00f);
            colors[(int)ImGuiCol.DockingPreview] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.DockingEmptyBg] = new System.Numerics.Vector4(0.20f, 0.20f, 0.20f, 1.00f);
            colors[(int)ImGuiCol.PlotLines] = new System.Numerics.Vector4(0.61f, 0.61f, 0.61f, 1.00f);
            colors[(int)ImGuiCol.PlotLinesHovered] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogram] = new System.Numerics.Vector4(1.00f, 0.78f, 0.28f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogramHovered] = new System.Numerics.Vector4(1.00f, 0.60f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.TextSelectedBg] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.DragDropTarget] = new System.Numerics.Vector4(0.73f, 0.67f, 0.24f, 1.00f);
            colors[(int)ImGuiCol.NavHighlight] = new System.Numerics.Vector4(0.59f, 0.54f, 0.18f, 1.00f);
            colors[(int)ImGuiCol.NavWindowingHighlight] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 0.70f);
            colors[(int)ImGuiCol.NavWindowingDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.20f);
            colors[(int)ImGuiCol.ModalWindowDimBg] = new System.Numerics.Vector4(0.80f, 0.80f, 0.80f, 0.35f);
        }

        public static void EmbraceThaDarkness()
        {
            var style = ImGui.GetStyle();
            style.WindowPadding = new System.Numerics.Vector2(8.00f, 8.00f);
            style.FramePadding = new System.Numerics.Vector2(5.00f, 2.00f);
            style.ItemSpacing = new System.Numerics.Vector2(6.00f, 6.00f);
            style.ItemInnerSpacing = new System.Numerics.Vector2(6.00f, 6.00f);
            style.TouchExtraPadding = new System.Numerics.Vector2(0.00f, 0.00f);
            style.IndentSpacing = 25;
            style.ScrollbarSize = 15;
            style.GrabMinSize = 10;
            style.WindowBorderSize = 1;
            style.ChildBorderSize = 1;
            style.PopupBorderSize = 1;
            style.FrameBorderSize = 1;
            style.TabBorderSize = 1;
            style.WindowRounding = 7;
            style.ChildRounding = 4;
            style.FrameRounding = 3;
            style.PopupRounding = 4;
            style.ScrollbarRounding = 9;
            style.GrabRounding = 3;
            style.LogSliderDeadzone = 4;
            style.TabRounding = 4;

            var colors = style.Colors;
            colors[(int)ImGuiCol.Text] = new System.Numerics.Vector4(1.00f, 1.00f, 1.00f, 1.00f);
            colors[(int)ImGuiCol.TextDisabled] = new System.Numerics.Vector4(0.50f, 0.50f, 0.50f, 1.00f);
            colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.10f, 0.10f, 0.10f, 1.00f);
            colors[(int)ImGuiCol.ChildBg] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.00f);
            colors[(int)ImGuiCol.PopupBg] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.92f);
            colors[(int)ImGuiCol.Border] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.29f);
            colors[(int)ImGuiCol.BorderShadow] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.24f);
            colors[(int)ImGuiCol.FrameBg] = new System.Numerics.Vector4(0.05f, 0.05f, 0.05f, 0.54f);
            colors[(int)ImGuiCol.FrameBgHovered] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.54f);
            colors[(int)ImGuiCol.FrameBgActive] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 1.00f);
            colors[(int)ImGuiCol.TitleBg] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.TitleBgActive] = new System.Numerics.Vector4(0.06f, 0.06f, 0.06f, 1.00f);
            colors[(int)ImGuiCol.TitleBgCollapsed] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.MenuBarBg] = new System.Numerics.Vector4(0.14f, 0.14f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.ScrollbarBg] = new System.Numerics.Vector4(0.05f, 0.05f, 0.05f, 0.54f);
            colors[(int)ImGuiCol.ScrollbarGrab] = new System.Numerics.Vector4(0.34f, 0.34f, 0.34f, 0.54f);
            colors[(int)ImGuiCol.ScrollbarGrabHovered] = new System.Numerics.Vector4(0.40f, 0.40f, 0.40f, 0.54f);
            colors[(int)ImGuiCol.ScrollbarGrabActive] = new System.Numerics.Vector4(0.56f, 0.56f, 0.56f, 0.54f);
            colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.33f, 0.67f, 0.86f, 1.00f);
            colors[(int)ImGuiCol.SliderGrab] = new System.Numerics.Vector4(0.34f, 0.34f, 0.34f, 0.54f);
            colors[(int)ImGuiCol.SliderGrabActive] = new System.Numerics.Vector4(0.56f, 0.56f, 0.56f, 0.54f);
            colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.05f, 0.05f, 0.05f, 0.54f);
            colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.19f, 0.19f, 0.19f, 0.54f);
            colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 1.00f);
            colors[(int)ImGuiCol.Header] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.52f);
            colors[(int)ImGuiCol.HeaderHovered] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.36f);
            colors[(int)ImGuiCol.HeaderActive] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 0.33f);
            colors[(int)ImGuiCol.Separator] = new System.Numerics.Vector4(0.28f, 0.28f, 0.28f, 0.29f);
            colors[(int)ImGuiCol.SeparatorHovered] = new System.Numerics.Vector4(0.44f, 0.44f, 0.44f, 0.29f);
            colors[(int)ImGuiCol.SeparatorActive] = new System.Numerics.Vector4(0.40f, 0.44f, 0.47f, 1.00f);
            colors[(int)ImGuiCol.ResizeGrip] = new System.Numerics.Vector4(0.28f, 0.28f, 0.28f, 0.29f);
            colors[(int)ImGuiCol.ResizeGripHovered] = new System.Numerics.Vector4(0.44f, 0.44f, 0.44f, 0.29f);
            colors[(int)ImGuiCol.ResizeGripActive] = new System.Numerics.Vector4(0.40f, 0.44f, 0.47f, 1.00f);
            colors[(int)ImGuiCol.Tab] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.52f);
            colors[(int)ImGuiCol.TabHovered] = new System.Numerics.Vector4(0.14f, 0.14f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.TabActive] = new System.Numerics.Vector4(0.20f, 0.20f, 0.20f, 0.36f);
            colors[(int)ImGuiCol.TabUnfocused] = new System.Numerics.Vector4(0.00f, 0.00f, 0.00f, 0.52f);
            colors[(int)ImGuiCol.TabUnfocusedActive] = new System.Numerics.Vector4(0.14f, 0.14f, 0.14f, 1.00f);
            colors[(int)ImGuiCol.DockingPreview] = new System.Numerics.Vector4(0.33f, 0.67f, 0.86f, 1.00f);
            colors[(int)ImGuiCol.DockingEmptyBg] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotLines] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotLinesHovered] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogram] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.PlotHistogramHovered] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.TextSelectedBg] = new System.Numerics.Vector4(0.20f, 0.22f, 0.23f, 1.00f);
            colors[(int)ImGuiCol.DragDropTarget] = new System.Numerics.Vector4(0.33f, 0.67f, 0.86f, 1.00f);
            colors[(int)ImGuiCol.NavHighlight] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 1.00f);
            colors[(int)ImGuiCol.NavWindowingHighlight] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 0.70f);
            colors[(int)ImGuiCol.NavWindowingDimBg] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 0.20f);
            colors[(int)ImGuiCol.ModalWindowDimBg] = new System.Numerics.Vector4(1.00f, 0.00f, 0.00f, 0.35f);
        }
    }
}