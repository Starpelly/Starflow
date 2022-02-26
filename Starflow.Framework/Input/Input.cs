using Microsoft.Xna.Framework;

namespace Starflow
{
    public class Input
    {
        public static readonly Keyboard keyboard = new Keyboard();
        public static readonly Mouse mouse = new Mouse();

        /// <summary>
        /// The current mouse position in pixel coordinates.
        /// </summary>
        public static Vector2 mousePosition;

        /// <summary>
        /// The current mouse scroll value. (Read Only)
        /// </summary>
        public static int mouseScrollValue { get { return Mouse.mouseScrollValue; } }

        public static void Update()
        {
            keyboard.Update();
            mouse.Update();
        }

        /// <summary>
        /// Returns true during the frame the user starts pressing down the key identified by the key [KeyCode] enum parameter.
        /// </summary>
        public static bool GetKeyDown(KeyCode key)
        {
            return keyboard.GetKeyDown(key);
        }

        /// <summary>
        /// Returns true while the user holds down the key identified by the key [KeyCode] enum parameter.
        /// </summary>
        public static bool GetKey(KeyCode key)
        {
            return keyboard.GetKey(key);
        }

        public static bool GetMouseButton(int button)
        {
            return mouse.GetMouseButton(button);
        }

        /// <summary>
        /// Returns true during the frame the user pressed the given mouse button.
        /// </summary>
        public static bool GetMouseButtonDown(int button)
        {
            return mouse.GetMouseButtonDown(button);
        }

        /// <summary>
        /// Returns true during the frame the user released the given mouse button.
        /// </summary>
        public static bool GetMouseButtonUp(int button)
        {
            return mouse.GetMouseButtonUp(button);
        }
    }
}
