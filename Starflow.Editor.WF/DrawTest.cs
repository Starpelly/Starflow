using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow.Editor
{
    internal class DrawTest : MonoGame.Forms.Controls.MonoGameControl
    {
        EditorCamera editorCamera;
        public int zoom = 1;

        protected override void Initialize()
        {
            base.Initialize();

            editorCamera = new EditorCamera(GraphicsDevice.Viewport.Width / zoom, GraphicsDevice.Viewport.Height / zoom, -1, 1);
            editorCamera.Move((Microsoft.Xna.Framework.Vector3.UnitX - Microsoft.Xna.Framework.Vector3.UnitY) * 64);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Input.Update();
            Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Input.GetKey(KeyCode.D))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(500 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(-500 * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.W))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(0, 500 * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                editorCamera.Move(new Microsoft.Xna.Framework.Vector3(0, -500 * Time.deltaTime, 0));
            }
        }

        protected override void Draw()
        {
            base.Draw();
            GraphicsDevice.Clear(Colors.Hex2RGB("464646"));

            var viewport = GraphicsDevice.Viewport;
            var translation = editorCamera.View.Translation;
            var spriteBatchTransformation = Matrix.CreateTranslation(viewport.Width / 2 / zoom, viewport.Height / 2 / zoom, 0) *
                                Matrix.CreateTranslation(translation.X, -translation.Y, 0)
                                * Matrix.CreateScale(zoom);

            Editor.spriteBatch.Begin(transformMatrix: spriteBatchTransformation);

            for (int i = 0; i < EditorWindow.Instance.currentEditorScene.gameObjects.Count; i++)
            {
                List<Component> components = EditorWindow.Instance.currentEditorScene.gameObjects[i].components;

                for (int j = 0; j < components.Count; j++)
                {
                    if (components[j].GetType() == typeof(SpriteRenderer))
                    {
                        SpriteRenderer sp = (SpriteRenderer)components[j];
                        sp.sprite = new Sprite(LoadTexture(@"C:\Dev\Starflow\Sandbox\Content\morsh.png"));
                        sp.Draw(Editor.spriteBatch);
                    }
                }
            }

            Editor.spriteBatch.End();

        }

        public Texture2D LoadTexture(string Filename)
        {
            FileStream setStream = File.Open(Filename, FileMode.Open);
            Texture2D NewTexture = Texture2D.FromStream(GraphicsDevice, setStream);
            setStream.Dispose();
            return NewTexture;
        }
    }
}
