using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tickflow;

using ImGuiNET;

namespace GameExample
{
    public class TestBehaviour : Behaviour
    {
        public float bruh = 0;
        SpriteRenderer spriteRenderer;

        public override void Start()
        {
            Texture2D tex = GameManager.ContentManager.Load<Texture2D>("icon");
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = new Sprite(tex);
            // gameObject.transform.scale = new Vector2(0.5f, 0.5f);
        }

        public override void Update()
        {
            spriteRenderer.color = new Color(MainGame.testColor.X, MainGame.testColor.Y, MainGame.testColor.Z);
            gameObject.transform.rotation = (float)Math.Sin(Time.time);
            gameObject.transform.position = Input.mousePosition;
        }
    }
}
