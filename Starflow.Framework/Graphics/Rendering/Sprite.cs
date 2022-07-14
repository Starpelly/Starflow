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

        public Sprite(string filePath)
        {
            if (GameRuntime.GraphicsDevice != null)
            {
                var texture = Texture2D.FromFile(GameRuntime.GraphicsDevice, filePath);
                this.texture = texture;
                Debug.Log("abs");
            }
            else
            {
                Debug.Log("a");
            }
        }
    }
}
