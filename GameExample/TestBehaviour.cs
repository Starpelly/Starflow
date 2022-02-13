using System;
using System.Collections.Generic;
using System.Text;
using Tickflow;

namespace GameExample
{
    public class TestBehaviour : Behaviour
    {
        public float bruh = 0;

        public override void Start()
        {
            Debug.Log("Start");
        }

        public override void Update()
        {
            Debug.Log("Update" + "  " + Input.mousePosition);
        }
    }
}
