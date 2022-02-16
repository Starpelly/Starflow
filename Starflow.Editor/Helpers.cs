namespace Starflow.Editor
{
    public class Helpers
    {
        public static System.Numerics.Vector3 XnaVector2Numerics(Microsoft.Xna.Framework.Vector2 vector2)
        {
            return new System.Numerics.Vector3(vector2.X, vector2.Y, 0);
        }

        public static Microsoft.Xna.Framework.Vector2 Numerics2XnaVector(System.Numerics.Vector3 vector2)
        {
            return new Microsoft.Xna.Framework.Vector2(vector2.X, vector2.Y);
        }
    }
}
