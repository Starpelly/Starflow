using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using ImGuiNET;

namespace Starflow.Editor
{
    public class Inspector : View
    {
        public static void Imgui(GameObject activeGameObject)
        {
            ImGui.Begin("Inspector");

            if (activeGameObject != null)
            {
                GameObject(activeGameObject);
            }

            ImGui.End();
        }

        private static void GameObject(GameObject activeGameObject)
        {
            ImGui.Checkbox("##goEnabled", ref activeGameObject.enabled);
            ImGui.SameLine();
            ImGui.InputText("##label", ref activeGameObject.name, 64);
            ImGui.Separator();
            new TransformEditor().Imgui(activeGameObject);

            for (int i = 0; i < activeGameObject.components.Count; i++)
            {
                Component c = activeGameObject.components[i];

                bool open = true;
                if (ImGui.CollapsingHeader(c.GetType().Name, ref open))
                {
                    if (c.GetType().BaseType.Name != "Behaviour" || c.GetType().Namespace == "Starflow") // hacky fix rn
                    {
                        var types = GetTypesWithAttribute(Assembly.GetExecutingAssembly());
                        foreach (var type in types)
                        {
                            if (type.GetCustomAttribute<CustomEditor>().m_InspectedType == c.GetType())
                            {
                                MethodInfo methodInfo = type.GetMethod("Imgui");
                                if (methodInfo != null)
                                {
                                    ParameterInfo[] parameters = methodInfo.GetParameters();
                                    object classInstance = Activator.CreateInstance(type, null);
                                    if (parameters.Length == 0)
                                    {
                                        methodInfo.Invoke(classInstance, null);
                                    }
                                    else
                                    {
                                        object[] parametersArray = new object[] { c };
                                        methodInfo.Invoke(classInstance, parametersArray);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        new BehaviourEditor().Imgui(c);
                    }
                }
                // ImGui.Checkbox(c.GetType().Name, ref c.enabled);
            }
            if (ImGui.Button("Add Component"))
            {
                Debug.Log("Add Component Menu");
            }
        }

        static IEnumerable<Type> GetTypesWithAttribute(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(CustomEditor), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}