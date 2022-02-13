using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tickflow;

namespace GameExample
{
    public class TestBehaviour : Behaviour
    {
        public float bruh = 0;

        public override void Start()
        {
            Texture2D tex = Graphics.Rectangle(Color.Blue, 64, 64);
            SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = new Sprite(tex);
        }

        public override void Update()
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }
}
