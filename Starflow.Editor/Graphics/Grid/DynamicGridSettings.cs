
using Microsoft.Xna.Framework;

namespace Starflow.Editor
{
    public class DynamicGridSettings
    {
        public Color MinorGridColor { get; set; } = Colors.Hex2RGB("494949");
        public Color MajorGridColor { get; set; } = Colors.Hex2RGB("646464");
        public Color OriginGridColor { get; set; } = Colors.Hex2RGB("8e8e8e");

        public int MaxGridSize { get; set; } = 2 << 6;
        public int HideLinesLower { get; set; } = 4;
        public int MajorLineEvery { get; set; } = 8;
        public int GridSizeInPixels { get; set; } = 8;
    }
}
