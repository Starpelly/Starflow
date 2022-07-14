using System;
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
        
        public static void Line(SpriteBatch sb, Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.y , edge.x);

            Texture2D tex = new Texture2D(game.GraphicsDevice, 1, 1);

            sb.Draw(tex,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.x,
                    (int)start.y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.Red, //colour of line
                angle,     //angle of line (calulated above)
                new Microsoft.Xna.Framework.Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }
    }
}
