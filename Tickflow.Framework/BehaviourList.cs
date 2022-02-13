using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Tickflow
{
    public class BehaviourList : IEnumerable<Behaviour>
    {
        private readonly List<Behaviour> behaviours = new List<Behaviour>();
        private readonly Dictionary<Type, Behaviour> behavioursByType = new Dictionary<Type, Behaviour>();

        public void Add(Behaviour type)
        {
            var insert = 0;
            behaviours.Insert(insert, type);
        }

        internal void EarlyUpdate()
        {

        }

        internal void Update()
        {
            for (int i = 0; i < behaviours.Count; i++)
                behaviours[i].Update();
        }

        internal void LateUpdate()
        {
            for (int i = 0; i < behaviours.Count; i++)
                behaviours[i].Update();
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
