using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starflow.Editor.Utils;

namespace Starflow.Editor.Utils
{
    public class GridLines
    {
        public static void Draw(EditorCameraComponent cam, SpriteBatch sb)
        {
            // Infinite grid kinda, honestly I probably would've been better off porting the grid i had earlier into here.
            // Maybe some day. 
            Vector2 cameraPos = new Vector2(cam.Position.X, cam.Position.Y);
            Vector2 projectionSize = new Vector2(SceneView.wSize.X, SceneView.wSize.Y);
            int height = (int)projectionSize.Y;
            int width = (int)projectionSize.X;
            
            Texture2D texture1px = new Texture2D(StarflowEditor.instance.GraphicsDevice, 1, 1);
            texture1px.SetData(new Color[] { Color.White });

            int firstX = ((int)(cameraPos.X / EditorProperties.GRID_WIDTH) * EditorProperties.GRID_HEIGHT);
            int firstY = ((int)(cameraPos.Y / EditorProperties.GRID_HEIGHT) * EditorProperties.GRID_HEIGHT);
            
            Debug.Log(firstX + "   " + firstY);
            
            for (float x = -32; x < 32; x++)
            {
                Rectangle rectangle = new Rectangle((int)(firstX + x * EditorProperties.GRID_WIDTH), (-firstY - 32 * 16), 1, 1080);
                sb.Draw(texture1px, rectangle, Colors.Hex2RGB("636363"));
            }
            for (float y = -32; y < 32; y++)
            {
                Rectangle rectangle = new Rectangle(firstX - 32 * 32, (int)(-firstY + y * EditorProperties.GRID_HEIGHT), 1920, 1);
                sb.Draw(texture1px, rectangle, Colors.Hex2RGB("636363"));
            }
        }
    }
}