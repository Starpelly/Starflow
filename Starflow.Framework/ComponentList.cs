using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public class ComponentList : IEnumerable<MonoBehaviour>
    {
        private readonly List<Component> components = new List<Component>();

        private List<Component> activeComponents()
        {
            return components.FindAll(c => c.gameObject.enabled && c.enabled);
        }

        public void Add<T>(T type)
        {
            components.Add((Component)(object)type);
        }

        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                activeComponents()[i].Draw(sb);
            }
        }

        public void EarlyUpdate()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(MonoBehaviour)))
                {
                    MonoBehaviour b = (MonoBehaviour)(object)activeComponents()[i];
                    b.EarlyUpdate();
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(MonoBehaviour)))
                {
                    MonoBehaviour b = (MonoBehaviour)(object)activeComponents()[i];
                    b.Update();
                }
            }
        }

        public void LateUpdate()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(MonoBehaviour)))
                {
                    MonoBehaviour b = (MonoBehaviour)(object)activeComponents()[i];
                    b.LateUpdate();
                }
            }
        }

        public IEnumerator<MonoBehaviour> GetEnumerator()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(MonoBehaviour)))
                {
                    var MonoBehaviour = activeComponents()[i];
                    if (MonoBehaviour != null)
                        yield return (MonoBehaviour)(object)MonoBehaviour;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                var MonoBehaviour = activeComponents()[i];
                if (MonoBehaviour != null)
                    yield return MonoBehaviour;
            }
        }
    }
}
