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
}
