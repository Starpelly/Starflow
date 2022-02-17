namespace Starflow
{
    public class Colors
    {
        /// <summary>
        /// Converts a Color to an Hexadecimal value.
        /// </summary>
        public static string Color2Hex(Microsoft.Xna.Framework.Color color)
        {
            string hex = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            return hex;
        }

        /// <summary>
        /// Converts a Hexadecimal Color to an RGB Color.
        /// </summary>
        public static Microsoft.Xna.Framework.Color Hex2RGB(string hex)
        {
            hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
            hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
            byte a = 255;//assume fully visible unless specified in hex
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            //Only use alpha if the string has enough characters
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return new Microsoft.Xna.Framework.Color(r, g, b, a);
        }
    }
}
