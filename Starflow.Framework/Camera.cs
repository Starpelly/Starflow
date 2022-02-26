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
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        private void UpdateMatrix()
        {
            Transform = Matrix.CreateTranslation(new Vector3(transform.position.X, transform.position.Y, 0f)) * 
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
