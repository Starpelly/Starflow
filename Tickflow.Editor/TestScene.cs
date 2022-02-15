﻿using Tickflow;
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
            this.activeGameObject = testBehaviour.spriteRenderer2.gameObject;
        }

        public override void SceneImGui()
        {
            if (activeGameObject != null)
            {
                Inspector.Imgui(activeGameObject);
            }
            Hierarchy.Imgui(this); // ah fuck wait

            ImGui.Begin("Console");

            ImGui.End();

            ImGui.Begin("Asset Browser");

            ImGui.End();
        }

        public override void SetActiveGameObject(GameObject gameObject)
        {
            this.activeGameObject = gameObject;
        }
    }
}
