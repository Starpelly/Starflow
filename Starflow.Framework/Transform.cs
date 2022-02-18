using Microsoft.Xna.Framework;

namespace Starflow
{
    public class Transform : Component
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;
        public Transform parent;
        public int childCount;
    }

    /*public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2(float val)
        {
            x = val;
            y = val;
        }

        public static Vector2 operator -(Vector2 value)
        {
            value.x = 0f - value.x;
            value.y = 0f - value.y;
            return value;
        }

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.x += value2.x;
            value1.y += value2.y;
            return value1;
        }
    }*/
}
