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
        SpriteRenderer spriteRenderer;

        public override void Start()
        {
            Texture2D tex = GameManager.ContentManager.Load<Texture2D>("AMONGCOLON");
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = new Sprite(tex);
            spriteRenderer.offset = new Vector2(-38, -38);
            gameObject.transform.scale = new Vector2(0.1f, 0.1f);
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            gameObject.transform.position = Input.mousePosition;
        }
    }
}
