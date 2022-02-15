using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tickflow;

using ImGuiNET;

namespace Tickflow.Editor
{
    public class TestBehaviour : Behaviour
    {
        public float bruh;
        public int bruh2;
        public SpriteRenderer spriteRenderer;
        public SpriteRenderer spriteRenderer2;
        private RenderTarget2D renderTarget;

        public override void Start()
        {
            Texture2D tex = GameManager.ContentManager.Load<Texture2D>("morsh");
            GameObject gameObject2 = new GameObject("t");
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = new Sprite(tex);
            spriteRenderer2 = gameObject2.AddComponent<SpriteRenderer>();
            spriteRenderer2.sprite = new Sprite(tex);
            // gameObject.transform.scale = new Vector2(0.5f, 0.5f);
        }

        public override void Update()
        {
            gameObject.transform.rotation = (float)Math.Sin(Time.time) * 100;
        }
    }
}
