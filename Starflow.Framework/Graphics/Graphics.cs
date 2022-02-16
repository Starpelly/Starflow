using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public static class Graphics
    {
        private static GameManager game;
        public static void Init(GameManager _game)
        {
            game = _game;
        }

        public static Texture2D Rectangle(Color color, int width, int height)
        {
            Texture2D tex = new Texture2D(game.GraphicsDevice, width, height);
            Color[] cols = new Color[width * height];
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = color;
            }

            tex.SetData(cols);
            return tex;
        }
    }
}
