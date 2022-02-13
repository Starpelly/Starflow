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
        public Texture2D texture;

        private List<Component> components = new List<Component>();

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

    public struct Transform
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;
    }
}
