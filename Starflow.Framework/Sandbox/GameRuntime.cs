using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;

namespace Starflow
{
    public class GameRuntime : GameManager
    {
        public string ApplicationTitle;
        public Scene StartingScene;

        public static new GraphicsDevice GraphicsDevice => Instance.GraphicsDevice;

        public GameRuntime()
        {
        }

        public override void Start()
        {
            Window.Title = ApplicationTitle;
            ChangeScene(StartingScene);
        }
    }
}
