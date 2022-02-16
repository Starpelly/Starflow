using System;
using System.Collections.Generic;

namespace Starflow
{
    public class Scene
    {
        public string name;
        public List<GameObject> gameObjects = new List<GameObject>();
        public GameObject activeGameObject { get; private set; }

        public void SetActiveGameObject(GameObject gameObject)
        {
            activeGameObject = gameObject;
        }
    }
}
