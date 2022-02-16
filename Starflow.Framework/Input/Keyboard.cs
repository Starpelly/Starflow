using Microsoft.Xna.Framework.Input;
using System;

namespace Starflow
{
    public class Keyboard
    {
        public static KeyboardState keys;
        public static KeyboardState lastKeys;

        public void Update()
        {
            lastKeys = keys;
            keys = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        public bool GetKeyDown(KeyCode key)
        {
            return keys.IsKeyDown((Keys)key) && lastKeys.IsKeyUp((Keys)key);
        }

        public bool GetKey(KeyCode key)
        {
            return keys.IsKeyDown((Keys)key);
        }

        public bool GetKeyUp(KeyCode key)
        {
            return lastKeys.IsKeyDown((Keys)key) && keys.IsKeyUp((Keys)key);
        }

        internal static object GetState()
        {
            throw new NotImplementedException();
        }
    }
}
