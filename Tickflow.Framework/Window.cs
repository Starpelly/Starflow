using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tickflow
{
    public class Window
    {
        public static int width { get { return GameManager.Instance.GraphicsDevice.PresentationParameters.BackBufferWidth; } }
        public static int height { get { return GameManager.Instance.GraphicsDevice.PresentationParameters.BackBufferHeight; } }
    }
}
