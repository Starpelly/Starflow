namespace Tickflow
{
    public abstract class Behaviour : Component
    {
        public virtual void Start() { }
        public virtual void EarlyUpdate() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }
    }
}
