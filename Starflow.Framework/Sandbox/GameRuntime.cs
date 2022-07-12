using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starflow.Runtime
{
    public class GameRuntime : GameManager
    {
        public string ApplicationTitle;
        public Scene StartingScene;

        public override void Start()
        {
            Window.Title = ApplicationTitle;
            ChangeScene(StartingScene);
        }
    }
}
