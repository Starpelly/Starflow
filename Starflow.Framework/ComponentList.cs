using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Microsoft.Xna.Framework.Graphics;

namespace Starflow
{
    public class ComponentList : IEnumerable<Behaviour>
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

        public void Draw()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                activeComponents()[i].Draw();
            }
        }

        internal void EarlyUpdate()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    Behaviour b = (Behaviour)(object)activeComponents()[i];
                    b.EarlyUpdate();
                }
            }
        }

        internal void Update()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    Behaviour b = (Behaviour)(object)activeComponents()[i];
                    b.Update();
                }
            }
        }

        internal void LateUpdate()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    Behaviour b = (Behaviour)(object)activeComponents()[i];
                    b.LateUpdate();
                }
            }
        }

        public IEnumerator<Behaviour> GetEnumerator()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                if (activeComponents()[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    var behaviour = activeComponents()[i];
                    if (behaviour != null)
                        yield return (Behaviour)(object)behaviour;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < activeComponents().Count; i++)
            {
                var behaviour = activeComponents()[i];
                if (behaviour != null)
                    yield return behaviour;
            }
        }
    }
}
