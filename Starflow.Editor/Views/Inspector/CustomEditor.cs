using System;

namespace Starflow.Editor
{
    public class CustomEditor : Attribute
    {
        internal Type m_InspectedType;

        public CustomEditor(Type inspectedType)
        {
            if (inspectedType == null)
                Debug.LogError("Failed to load CustomEditor inspected type!");

            m_InspectedType = inspectedType;
        }
    }
}