using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using Tickflow;
using ImGuiNET;

namespace Tickflow.Editor
{
    public class TestScene : Scene
    {
        GameObject gameObject;

        public override void Init()
        {
            gameObject = new GameObject("Test");
            GameObject cam = new GameObject("Cam");

            TestBehaviour testBehaviour = gameObject.AddComponent<TestBehaviour>();
            TestCamera testCamera = cam.AddComponent<TestCamera>();
            testCamera.cam = cam.AddComponent<Camera>();
            this.activeGameObject = cam;
        }

        public override void SceneImGui()
        {
            if (activeGameObject != null)
            {
                ImGui.Begin("Inspector");
                for (int i = 0; i < activeGameObject.components.Count; i++)
                {
                    Component c = activeGameObject.components[i];
                    ImGui.Text(c.GetType().Name);

                    if (c.GetType().BaseType.Name != "Behaviour") // hacky fix rn
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
                }
                ImGui.End();
            }

            ImGui.Begin("Hierarchy");

            ImGui.End();

            ImGui.Begin("Console");

            ImGui.End();

            ImGui.Begin("Asset Browser");

            ImGui.End();
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
