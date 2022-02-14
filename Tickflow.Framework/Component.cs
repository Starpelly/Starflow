using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickflow
{
    public class Component
    {
        public GameObject gameObject = null;
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
