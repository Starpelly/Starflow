using Microsoft.Xna.Framework.Graphics;
using ImGuiNET;
using MonoGame.ImGui;

using System.Numerics;
using System;

namespace Tickflow.Editor
{
    public class GameViewWindow
    {
        public static void imgui()
        {
            ImGui.Begin("Game Viewport", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);

            Vector2 windowSize = GetLargestSizeForViewport();
            Vector2 windowPos = GetCenteredPositionForViewport(windowSize);

            ImGui.SetCursorPos(new Vector2(windowPos.X, windowPos.Y));

            IntPtr renderTargetID = MainGame.ImGuiRenderer.BindTexture(GameManager.TestRenderTarget);
            ImGui.Image(renderTargetID, new Vector2(windowSize.X, windowSize.Y));

            ImGui.End();
        }

        private static Vector2 GetLargestSizeForViewport()
        {
            Vector2 windowSize = new Vector2();
            windowSize = ImGui.GetContentRegionAvail();
            windowSize.X -= ImGui.GetScrollX();
            windowSize.Y -= ImGui.GetScrollY();

            float aspectWidth = windowSize.X;
            float aspectHeight = aspectWidth / TargetAspectRatio();
            if (aspectHeight > windowSize.Y)
            {
                aspectHeight = windowSize.Y;
                aspectWidth = aspectHeight * TargetAspectRatio();
            }

            return new Vector2(aspectWidth, aspectHeight);
        }

        private static Vector2 GetCenteredPositionForViewport(Vector2 aspectSize)
        {
            Vector2 windowSize = new Vector2();
            windowSize = ImGui.GetContentRegionAvail();
            windowSize.X -= ImGui.GetScrollX();
            windowSize.Y -= ImGui.GetScrollY();

            float viewportX = (windowSize.X / 2.0f) - (aspectSize.X / 2.0f);
            float viewportY = (windowSize.Y / 2.0f) - (aspectSize.Y / 2.0f);

            return new Vector2(viewportX + ImGui.GetCursorPosX(), viewportY + ImGui.GetCursorPosY());
        }

        public static float TargetAspectRatio()
        {
            return 16.0f / 9.0f;
        }
    }
}
