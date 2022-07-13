using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
