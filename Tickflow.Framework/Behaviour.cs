namespace Tickflow
{
    public abstract class Behaviour : Component
    {
        /// <summary>
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        public virtual void Start() { }
        /// <summary>
        /// EarlyUpdate is called before all Update functions have been called
        /// </summary>
        public virtual void EarlyUpdate() { }
        /// <summary>
        /// Update is called every frame, if the Behaviour is enabled.
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// LateUpdate is called after all Update functions have been called, if the Behaviour is enabled.
        /// </summary>
        public virtual void LateUpdate() { }
    }
}
