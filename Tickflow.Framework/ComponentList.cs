using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Microsoft.Xna.Framework.Graphics;

namespace Tickflow
{
    public class ComponentList : IEnumerable<Behaviour>
    {
        private readonly List<Component> components = new List<Component>();

        public void Add<T>(T type)
        {
            components.Add((Component)(object)type);
        }

        internal void Draw()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Draw();
            }
        }

        internal void EarlyUpdate()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    Behaviour b = (Behaviour)(object)components[i];
                    b.EarlyUpdate();
                }
            }
        }

        internal void Update()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    Behaviour b = (Behaviour)(object)components[i];
                    b.Update();
                }
            }
        }

        internal void LateUpdate()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    Behaviour b = (Behaviour)(object)components[i];
                    b.LateUpdate();
                }
            }
        }

        public IEnumerator<Behaviour> GetEnumerator()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsSubclassOf(typeof(Behaviour)))
                {
                    var behaviour = components[i];
                    if (behaviour != null)
                        yield return (Behaviour)(object)behaviour;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < components.Count; i++)
            {
                var behaviour = components[i];
                if (behaviour != null)
                    yield return behaviour;
            }
        }
    }
}
