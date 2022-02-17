using ImGuiNET;

using System.Numerics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Starflow.Editor.Util;

using Vector2 = System.Numerics.Vector2;
using System.Collections.Generic;

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
            if (Input.GetKey(KeyCode.A))
            {
                editorCamera.position.X -= 500 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                editorCamera.position.X += 500 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                editorCamera.position.Y += 500 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                editorCamera.position.Y -= 500 * Time.deltaTime;
            }

            editorCamera.UpdateCamera(StarflowEditor.Instance.GraphicsDevice.Viewport);
        }

        public void Imgui()
        {
            ImGui.Begin("Scene", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);

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

            for (int i = 0; i < StarflowEditor.Instance.currentEditorScene.gameObjects.Count; i++)
            {
                List<Component> components = StarflowEditor.Instance.currentEditorScene.gameObjects[i].components;

                for (int j = 0; j < components.Count; j++)
                {
                    if (components[j].GetType() == typeof(SpriteRenderer))
                    {
                        SpriteRenderer sp = (SpriteRenderer)components[j];
                        sp.sprite = new Sprite(StarflowEditor.Instance.Content.Load<Texture2D>("morsh"));
                        sp.Draw(sb);
                    }
                }
            }

            // sb.Draw(StarflowEditor.Instance.Content.Load<Texture2D>("morsh"), new Microsoft.Xna.Framework.Vector2(0, 0), Color.White);
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
    }
}
