using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Tickflow;

namespace GameExample
{
    public class MainGame : GameManager
    {
        GameObject gameObject;

        public override void Start()
        {
            gameObject = new GameObject("Test");

            TestBehaviour testBehaviour = gameObject.AddComponent<TestBehaviour>();
        }
    }
}
