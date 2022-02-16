using Newtonsoft.Json;

namespace Tickflow
{
    public class Component
    {
        public bool enabled = true;
        [JsonIgnore] 
        public GameObject gameObject = null;
        [JsonIgnore]
        public Transform transform 
        { 
            get 
            {
                if (gameObject != null)
                {
                    return gameObject.transform; 
                }
                else
                {
                    return new Transform();
                }
            } 
        }

        public Component()
        {
        }

        public virtual void Draw() { }
    }
}
