using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starflow.Data
{
    public class Scene
    {
        public List<GameObject> GameObjects = new List<GameObject>();

        public Starflow.Scene ToScene()
        {
            Starflow.Scene scene = new Starflow.Scene();
            scene.gameObjects = GameObjects;
            return scene;
        }
    }
}
