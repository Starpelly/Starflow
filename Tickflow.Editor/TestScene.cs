using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tickflow;

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
        }
    }
}
