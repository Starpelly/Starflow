using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public class Window
    {
        public static int width { get { return GameManager.Instance.GraphicsDevice.PresentationParameters.BackBufferWidth; } }
        public static int height { get { return GameManager.Instance.GraphicsDevice.PresentationParameters.BackBufferHeight; } }

        private static Vector2 GetAspectRatio(int width, int height)
        {
            if (height == width)
                return new Vector2(1, 1);
            else
            {
                var dividend = 0;
                var divisor = 0;
                var remainder = 0;

                if (height > width)
                {
                    dividend = height;
                    divisor = width;
                }
                else if (width > height)
                {
                    dividend = width;
                    divisor = height;
                }

                var gdc = -1;
                while (gdc == -1)
                {
                    remainder = dividend % divisor;
                    if (remainder == 0)
                        gdc = divisor;
                    else
                    {
                        dividend = divisor;
                        divisor = remainder;
                    }
                }

                var hr = width / gdc;
                var vr = height / gdc;
                return new Vector2(hr, vr);
            }
        }
    }
}
