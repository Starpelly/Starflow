using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using Microsoft.Xna.Framework.Graphics;

namespace Tickflow
{
    public class ComponentList : IEnumerable<Behaviour>
    {
        private readonly List<Behaviour> behaviours = new List<Behaviour>();
        private readonly List<SpriteRenderer> sprites = new List<SpriteRenderer>(); // should be renderers in general, but we get there when we get there

        public void Add<T>(T type)
        {
            if (type.GetType().IsSubclassOf(typeof(Behaviour)))
            {
                behaviours.Add((Behaviour)(object)type);
            }
            else if (type.GetType() == typeof(SpriteRenderer))
            {
                sprites.Add((SpriteRenderer)(object)type);
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].Draw(spriteBatch);
            }
        }

        internal void EarlyUpdate()
        {
            for (int i = 0; i < behaviours.Count; i++)
                behaviours[i].EarlyUpdate();
        }

        internal void Update()
        {
            for (int i = 0; i < behaviours.Count; i++)
                behaviours[i].Update();
        }

        internal void LateUpdate()
        {
            for (int i = 0; i < behaviours.Count; i++)
                behaviours[i].LateUpdate();
        }

        public IEnumerator<Behaviour> GetEnumerator()
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                var behaviour = behaviours[i];
                if (behaviour != null)
                    yield return behaviour;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                var behaviour = behaviours[i];
                if (behaviour != null)
                    yield return behaviour;
            }
        }
    }
}
