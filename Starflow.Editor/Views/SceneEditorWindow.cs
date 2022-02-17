using ImGuiNET;

using System.Numerics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Starflow.Editor.Util;

using Vector2 = System.Numerics.Vector2;

namespace Starflow.Editor
{
    public class SceneEditorWindow : View
    {
        private EditorCamera editorCamera;

        public static SceneEditorWindow Instance { get; private set; }

        public SceneEditorWindow()
        {
            Instance = this;
            editorCamera = new EditorCamera();
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                editorCamera.position.X -= 500 * Time.deltaTime;
            }
            Debug.Log(editorCamera.Transform);
        }

        public void Imgui()
        {
            ImGui.Begin("Scene", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);

            // Vector2 viewportPanelSize = ImGui.GetContentRegionAvail();

            /*if (viewportSize != viewportPanelSize)
            {
                viewportSize = viewportPanelSize;

                if (viewportSize.X > 0 && viewportSize.Y > 0)
                {
                    StarflowEditor.SceneRenderTarget = new RenderTarget2D(StarflowEditor.Instance.GraphicsDevice, (int)viewportSize.X, (int)viewportSize.Y, false, StarflowEditor.Instance.GraphicsDevice.PresentationParameters.BackBufferFormat, DepthFormat.Depth24);
                }

            }*/

            Vector2 windowSize = GetLargestSizeForViewport();
            Vector2 windowPos = GetCenteredPositionForViewport(windowSize);

            ImGui.SetCursorPos(new Vector2(windowPos.X, windowPos.Y));

            IntPtr renderTargetID = StarflowEditor.ImGuiRenderer.BindTexture(StarflowEditor.SceneRenderTarget);
            ImGui.Image(renderTargetID, new Vector2(windowSize.X, windowSize.Y));
            ImGui.End();
        }

        public void DrawSceneEditor(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, editorCamera.Transform);

            StarflowEditor.Instance.GraphicsDevice.Clear(Colors.Hex2RGB("3f3d3f"));

            // DrawGrid(sb, (int)viewportSize.X, (int)viewportSize.Y);

            GameManager.Components.Draw();

            sb.End();
        }

        private Vector2 GetLargestSizeForViewport()
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

        private Vector2 GetCenteredPositionForViewport(Vector2 aspectSize)
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

        private void DrawGrid(SpriteBatch sb, int width, int height)
        {
            Texture2D texture1px = Graphics.Rectangle(Color.White, 1, 1);
            int cols = 32;
            int rows = 32;
            int gridSize = 32;
            int centerX = width / 2;
            int centerY = height / 2;
            Color col = Colors.Hex2RGB("5c5c5c");

            for (int x = -cols; x < cols; x++)
            {
                Rectangle rectangle = new Rectangle((centerX + x * gridSize), 0, 1, height);
                sb.Draw(texture1px, rectangle, col);
            }
            for (int y = -rows; y < rows; y++)
            {
                Rectangle rectangle = new Rectangle(0, (centerY + y * gridSize), width, 1);
                sb.Draw(texture1px, rectangle, col);
            }
        }
    }
}
