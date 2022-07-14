namespace Starflow
{
    public static class Convert
    {
        public static Microsoft.Xna.Framework.Vector2 ToXNA(this Vector2 vector2)
        {
            return new Microsoft.Xna.Framework.Vector2
            {
                X = vector2.x,
                Y = vector2.y
            };
        }
    }
}
