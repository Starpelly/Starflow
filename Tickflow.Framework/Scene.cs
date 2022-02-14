namespace Tickflow
{
    public abstract class Scene
    {
        private bool isRunning = false;

        public Scene()
        {

        }

        public abstract void Init();
    }
}
