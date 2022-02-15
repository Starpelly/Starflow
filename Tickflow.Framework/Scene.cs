using System.Collections.Generic;

namespace Tickflow
{
    public abstract class Scene
    {
        private bool isRunning = false;
        public List<GameObject> gameObjects = new List<GameObject>();
        protected GameObject activeGameObject = null;

        public Scene()
        {

        }

        public abstract void Init();
        public virtual void SceneImGui() { }
        public virtual void SetActiveGameObject(GameObject gameObject) { }
    }
}
