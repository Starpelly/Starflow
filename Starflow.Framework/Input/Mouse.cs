using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Starflow
{
    public class Mouse
    {
        public static MouseState mouse;
        public static MouseState lastMouse;

        public Vector2 mousePosition;

        public void Update()
        {
            lastMouse = mouse;
            mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
            Input.mousePosition = new Vector2(mouse.X, mouse.Y);
        }

        public bool GetMouseButtonDown(int button)
        {
            switch (button)
            {
                case 0:
                    return mouse.LeftButton == ButtonState.Pressed && lastMouse.LeftButton == ButtonState.Released;
                case 1:
                    return mouse.RightButton == ButtonState.Pressed && lastMouse.RightButton == ButtonState.Released;
                case 2:
                    return mouse.MiddleButton == ButtonState.Pressed && lastMouse.MiddleButton == ButtonState.Released;
                default:
                    return mouse.LeftButton == ButtonState.Pressed && lastMouse.LeftButton == ButtonState.Released;
            }
        }

        public bool GetMouseButtonUp(int button)
        {
            switch (button)
            {
                case 0:
                    return mouse.LeftButton == ButtonState.Released && lastMouse.LeftButton == ButtonState.Pressed;
                case 1:
                    return mouse.RightButton == ButtonState.Released && lastMouse.RightButton == ButtonState.Pressed;
                case 2:
                    return mouse.MiddleButton == ButtonState.Released && lastMouse.MiddleButton == ButtonState.Pressed;
                default:
                    return mouse.LeftButton == ButtonState.Released && lastMouse.LeftButton == ButtonState.Pressed;
            }
        }
    }
}
