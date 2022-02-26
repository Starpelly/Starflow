using Microsoft.Xna.Framework.Graphics;
using Starflow.Editor.Utils;

namespace Starflow.Editor
{
    public class SceneEditor
    {
        public static void Draw(SpriteBatch sb, EditorCameraComponent cam)
        {
            GridLines.Draw(cam, sb);
            
            for (int i = 0; i < StarflowEditor.currentEditorScene.gameObjects.Count; i++)
            {
                List<Component> components = StarflowEditor.currentEditorScene.gameObjects[i].components;

                for (int j = 0; j < components.Count; j++)
                {
                    if (components[j].GetType() == typeof(SpriteRenderer))
                    {
                        SpriteRenderer sp = (SpriteRenderer)components[j];
                        sp.sprite = new Sprite(Texture2D.FromFile(StarflowEditor.instance.GraphicsDevice, EditorProperties.ProjectLocation + @"\Content\morsh.png"));
                        sp.Draw(sb);
                    }
                }
            }
        }
    }
}
