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

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(transform.position.ToPoint(), transform.scale.ToPoint() * texture.Bounds.Size);
            }
        }

        public T AddComponent<T>() where T : Behaviour, new()
        {
            T t = new T();
            t.Start();
            t.gameObject = this;

            GameManager.Behaviours.Add(t);

            components.Add(t);
            return t;
        }

        public GameObject(string _name, Texture2D _texture)
        {
            name = _name;
            texture = _texture;
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
