using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Starflow
{
    public class Transform : Component
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;
        public Transform parent;
        public Vector3 eulerAngles;
        public int childCount => children.Count;
        public int GetSiblingIndex() { return 0; }

        public readonly List<GameObject> children = new List<GameObject>();

        /// <summary>
        /// Set the parent of the transform.
        /// </summary>
        public void SetParent(Transform parent)
        {
            transform.parent = parent;
            parent.children.Add(gameObject);
        }

        /// <summary>
        /// Transform child by index.
        /// </summary>
        public Transform GetChild(int index)
        {
            return children[index].transform;
        }
    }
}
