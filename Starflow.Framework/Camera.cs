using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Starflow
{
    public class Camera : Component
    {
        public float Zoom;
        public Rectangle Bounds;
        public Rectangle VisibleArea;
        public Matrix Transform;

        public Camera()
        {
            // Bounds = viewport.Bounds;
            Zoom = 1f;
            transform.position = Vector2.Zero;
            // GameManager.Instance.SetCamera(this);
        }


        private void UpdateVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(Transform);

            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);

            var min = new Vector2(
                MathHelper.Min(tl.x, MathHelper.Min(tr.x, MathHelper.Min(bl.x, br.x))),
                MathHelper.Min(tl.y, MathHelper.Min(tr.y, MathHelper.Min(bl.y, br.y))));
            var max = new Vector2(
                MathHelper.Max(tl.x, MathHelper.Max(tr.x, MathHelper.Max(bl.x, br.x))),
                MathHelper.Max(tl.y, MathHelper.Max(tr.y, MathHelper.Max(bl.y, br.y))));
            VisibleArea = new Rectangle((int)min.x, (int)min.y, (int)(max.x - min.x), (int)(max.y - min.y));
        }

        private void UpdateMatrix()
        {
            Transform = Matrix.CreateTranslation(new Vector3(transform.position.x, transform.position.y, 0f)) * 
                    Matrix.CreateRotationZ(transform.rotation) *
                    Matrix.CreateScale(Zoom) *
                    Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
            UpdateVisibleArea();
        }

        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;
        }

        public void UpdateCamera(Viewport bounds)
        {
            Bounds = bounds.Bounds;
            UpdateMatrix();
        }
    }
}
