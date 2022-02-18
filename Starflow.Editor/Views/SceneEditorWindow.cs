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
        public int zoom = 1;

        public static SceneEditorWindow Instance { get; private set; }

        public SceneEditorWindow()
        {
            Instance = this;
            editorCamera = new EditorCamera(StarflowEditor.Instance.GraphicsDevice.Viewport.Width / zoom, StarflowEditor.Instance.GraphicsDevice.Viewport.Height / zoom, -1, 1);
            editorCamera.Move((Microsoft.Xna.Framework.Vector3.UnitX - Microsoft.Xna.Framework.Vector3.UnitY) * 64);
        }

        public void Update(DynamicGrid _grid)
        {
            if (Input.GetKey(KeyCode.D))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(500 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(-500 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.W))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(0, 500 * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(0, -500 * Time.deltaTime, 0));
            }

            _grid.CalculateBestGridSize(zoom);
            _grid.CalculateGridData(data =>
            {
                var viewport = StarflowEditor.Instance.GraphicsDevice.Viewport;
                data.GridDim = viewport.Height;

                var worldTopLeft = editorCamera.ScreenToWorld(viewport, new Microsoft.Xna.Framework.Vector2(0, 0));
                var worldTopRight = editorCamera.ScreenToWorld(viewport, new Microsoft.Xna.Framework.Vector2(viewport.Width, 0));
                var worldBottomRight = editorCamera.ScreenToWorld(viewport, new Microsoft.Xna.Framework.Vector2(viewport.Width, viewport.Height));
                var worldBottomLeft = editorCamera.ScreenToWorld(viewport, new Microsoft.Xna.Framework.Vector2(0, viewport.Height));

                Aabb bounds = new Aabb();
                bounds.Grow(worldTopLeft);
                bounds.Grow(worldTopRight);
                bounds.Grow(worldBottomRight);
                bounds.Grow(worldBottomLeft);

                return bounds;
            });
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

        public void DrawSceneEditor(SpriteBatch sb, DynamicGrid _grid, PrimitiveBatch _primitiveBatch)
        {
            StarflowEditor.Instance.GraphicsDevice.Clear(Colors.Hex2RGB("464646"));

            _primitiveBatch.Begin(editorCamera.View, editorCamera.Projection);
            _grid.Render(_primitiveBatch, Matrix.Identity);
            _primitiveBatch.End();

            var viewport = StarflowEditor.Instance.GraphicsDevice.Viewport;
            var translation = editorCamera.View.Translation;
            var spriteBatchTransformation = Matrix.CreateTranslation(viewport.Width / 2 / zoom, viewport.Height / 2 / zoom, 0) *
                                            Matrix.CreateTranslation(translation.X, -translation.Y, 0)
                                            * Matrix.CreateScale(zoom);

            sb.Begin(transformMatrix: spriteBatchTransformation, samplerState: SamplerState.PointClamp);


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