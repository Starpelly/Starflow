using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Starflow
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public float x;
        public float y;

        private static readonly Vector2 zeroVector = new Vector2(0f, 0f);

        private static readonly Vector2 unitVector = new Vector2(1f, 1f);

        private static readonly Vector2 unitXVector = new Vector2(1f, 0f);

        private static readonly Vector2 unitYVector = new Vector2(0f, 1f);

        public static Vector2 Zero => zeroVector;
        public static Vector2 One => unitVector;
        public static Vector2 UnitX => unitXVector;
        public static Vector2 UnitY => unitYVector;

        // Summary:
        //     Constructs a 2d vector with X and Y from two values.
        //
        // Parameters:
        //   x:
        //     The x coordinate in 2d-space.
        //
        //   y:
        //     The y coordinate in 2d-space.
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        // Summary:
        //     Constructs a 2d vector with X and Y set to the same value.
        //
        // Parameters:
        //   value:
        //     The x and y coordinates in 2d-space.
        public Vector2(float value)
        {
            x = value;
            y = value;
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

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.x -= value2.x;
            value1.y -= value2.y;
            return value1;
        }
        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            value1.x *= value2.x;
            value1.y *= value2.y;
            return value1;
        }
        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }
        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            value1.x /= value2.x;
            value1.y /= value2.y;
            return value1;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(Vector2 value1, float divider)
        {
            float num = 1f / divider;
            value1.x *= num;
            value1.y *= num;
            return value1;
        }
        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            if (value1.x == value2.x)
            {
                return value1.y == value2.y;
            }

            return false;
        }
        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            if (value1.x == value2.x)
            {
                return value1.y != value2.y;
            }

            return true;
        }


        public bool Equals(Vector2 other)
        {
            if (x == other.x)
            {
                return y == other.y;
            }

            return false;
        }
        public void Normalize()
        {
            float num = 1f / (float)Math.Sqrt(x * x + y * y);
            x *= num;
            y *= num;
        }
        public static Vector2 Normalize(Vector2 value)
        {
            float num = 1f / (float)Math.Sqrt(value.x * value.x + value.y * value.y);
            value.x *= num;
            value.y *= num;
            return value;
        }
        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            float num = 1f / (float)Math.Sqrt(value.x * value.x + value.y * value.y);
            result.x = value.x * num;
            result.y = value.y * num;
        }
        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        public static Vector2 Transform(Vector2 position, Matrix matrix)
        {
            return new Vector2(position.x * matrix.M11 + position.y * matrix.M21 + matrix.M41, position.x * matrix.M12 + position.y * matrix.M22 + matrix.M42);
        }
        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }
    }
}
