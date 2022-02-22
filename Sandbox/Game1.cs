using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starflow;

namespace Sandbox
{
    public class Game1 : GameManager
    {

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {
        }

        public override void Start()
        {
            Scene testScene = new Scene();
            testScene.name = "te";
            System.Collections.Generic.List<GameObject> gameObjects = new System.Collections.Generic.List<GameObject>();
            for (int i = 0; i < 120; i++)
            {
                gameObjects.Add(new GameObject($"Test{i}"));
                if (i == 0)
                {
                    gameObjects[0].AddComponent<SpriteRenderer>();
                    gameObjects[0].AddComponent<Sandbox.TestBehaviour>();
                }
            }
            testScene.gameObjects = gameObjects;
            GameManager.ChangeScene(testScene);
        }

        public override void GameUpdate(Scene currentScene)
        {
        }
    }
}
