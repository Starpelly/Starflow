using ImGuiNET;
using System;
using System.Collections.Generic;

namespace Starflow.Editor
{
    public class Hierarchy : View
    {
        private static int nodeClicked = 0;
        private static string payloadDragDropTyoe = "Hierarchy";

        public static void Imgui(Scene currentScene)
        {
            ImGui.Begin("Hierarchy");

            for (int i = 0; i < currentScene.gameObjects.Count; i++)
            {
                GameObject gameObject = currentScene.gameObjects[i];
                bool treeNodeOpen = doTreeNode(currentScene.gameObjects, gameObject, i, currentScene);

                BasicTreeNodeChecks(currentScene, gameObject, treeNodeOpen);
            }

            if (ImGui.BeginPopupContextWindow())
            {
                if (ImGui.Selectable("Create Empty"))
                {
                    currentScene.gameObjects.Add(new GameObject("GameObject"));
                }
                ImGui.EndPopup();
            }

            ImGui.End();
        }

        private static void BasicTreeNodeChecks(Scene scene, GameObject setActiveGameObject, bool gameObjectOpen)
        {

            if (ImGui.IsItemClicked() && !ImGui.IsItemToggledOpen())
            {
                scene.SetActiveGameObject(setActiveGameObject);
            }

            if (gameObjectOpen)
            {
                for (int c = 0; c < setActiveGameObject.transform.childCount; c++)
                {
                    bool childOpen = doTreeNode(setActiveGameObject.transform.children, setActiveGameObject.transform.GetChild(c).gameObject, c, scene);
                    BasicTreeNodeChecks(scene, setActiveGameObject.transform.GetChild(c).gameObject, childOpen);
                }
                ImGui.TreePop();
            }
        }

        private unsafe static bool doTreeNode(List<GameObject> gameObjects, GameObject gameObject, int i, Scene currentScene)
        {
            ImGui.PushID(i);
            ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.FramePadding | ImGuiTreeNodeFlags.SpanAvailWidth | ImGuiTreeNodeFlags.Leaf;
            if (gameObject.transform.childCount > 0) flags = ImGuiTreeNodeFlags.FramePadding | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.SpanAvailWidth;

            if (currentScene.activeGameObject == gameObject)
                flags |= ImGuiTreeNodeFlags.Selected;

            bool treeNodeOpen = ImGui.TreeNodeEx(gameObject.name, flags, gameObject.name);
            ImGui.PopID();

            if (ImGui.BeginDragDropSource())
            {
                ImGui.SetDragDropPayload(payloadDragDropTyoe, (IntPtr)(&i), sizeof(int));
                ImGui.Text(gameObject.name);
                ImGui.EndDragDropSource();
            }

            if (ImGui.BeginDragDropTarget())
            {
                var payloadObj = ImGui.AcceptDragDropPayload(payloadDragDropTyoe);
                if (payloadObj.NativePtr != null)
                {
                    var dataPtr = (int*)payloadObj.Data;
                    int srcIndex = dataPtr[0];

                    var srcItem = gameObjects[srcIndex];
                    gameObjects[srcIndex] = gameObjects[i];
                    gameObjects[i] = srcItem;

                    Debug.Log(gameObjects[i].name);
                }
                ImGui.EndDragDropTarget();
            }

            return treeNodeOpen;
        }
    }
}