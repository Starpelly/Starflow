using Microsoft.Xna.Framework;
using static Starflow.Mathf;

namespace Starflow.Editor
{
    public class DynamicGridData
    {
        public int GridSize { get; set; }
        public int GridDim { get; set; }

        public Vector2i GridStart { get; set; }
        public Vector2i GridCount { get; set; }

        public Vector2 LineStart { get; set; }
        public Vector2 LineEnd { get; set; }
    }
}
