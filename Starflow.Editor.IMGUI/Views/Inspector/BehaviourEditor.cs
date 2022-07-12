using System;
using System.Linq;
using ImGuiNET;

namespace Starflow.Editor
{
    [CustomEditor(typeof(MonoBehaviour))]
    public class MonoBehaviourEditor : Editor
    {
        public override void Imgui(Component component)
        {
            /*MonoBehaviour b = (MonoBehaviour)component;
            var fieldValues = b.GetType().GetFields().Select(field => field.GetValue(b)).ToList();
            var fieldNames = b.GetType().GetFields().Select(field => field.Name).ToList();
            for (int i = 0; i < fieldValues.Count; i++)
            {
                var fieldVal = fieldValues[i];
                var fieldName = fieldNames[i];
                Type fieldType = fieldVal.GetType();
                if (fieldType == typeof(float))
                {
                    float field = (float)fieldVal;
                    if (ImGui.DragFloat(fieldName, ref field)) fieldVal = field;
                }
                else if (fieldType == typeof(int))
                {
                    int field = (int)fieldVal;
                    if (ImGui.DragInt(fieldName, ref field)) fieldVal = field;
                }
                else
                {
                    // ImGui.Button(fieldName); // also shows fields form Component.cs, which is obviously a problem
                }
            }*/
        }
    }
}