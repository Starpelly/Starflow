using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public class Sprite
    {
        public Texture2D texture;
        public Vector2 pivot;
        public Vector2 offset;

        public enum Pivot
        {
            TopLeft = 0,
            CenterLeft,
            BottomLeft,
            TopCenter,
            Center,
            BottomCenter,
            TopRight,
            CenterRight,
            BottomRight
        }

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
        }
    }
}
