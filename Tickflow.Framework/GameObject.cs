using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tickflow
{
    public class GameObject
    {
        public bool enabled;
        public string name;
        public Transform transform;

        private List<Component> components = new List<Component>();

        public T GetComponent<T>() where T : Component, new()
        {
            T t = new T();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] == t)
                {
                    try
                    {
                        return (T)(Component)(object)components[i];
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError(ex);
                    }
                }
            }

            return null;
        }

        public void RemoveComponent<T>(T componentClass) where T : Component // ill fix later
        {
            for (int i = 0; i < components.Count; i++)
            {
                Component c = components[i];
                if (componentClass == c)
                {
                    components.RemoveAt(i);
                    return;
                }
            }
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T t = new T();
            t.gameObject = this;
            if (t.GetType().IsSubclassOf(typeof(Behaviour)))
            {
                Behaviour b = (Behaviour)(object)t;
                b.Start();
                GameManager.Components.Add(b);
            }

            components.Add(t);
            return t;
        }

        public GameObject(string name)
        {
            this.name = name;
            transform = new Transform()
            {
                position = new Vector2(0, 0),
                rotation = 0f,
                scale = new Vector2(1, 1)
            };
        }
    }

    public class Transform : Component
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;
        public Transform parent;
        public int childCount;
    }
}
