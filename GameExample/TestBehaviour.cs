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
            Texture2D tex = GameManager.ContentManager.Load<Texture2D>("icon");
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = new Sprite(tex);
            // gameObject.transform.scale = new Vector2(0.5f, 0.5f);
        }

        public override void Update()
        {
            gameObject.transform.rotation = (float)Math.Sin(Time.time);
            /// gameObject.transform.position = Input.mousePosition;
            if (Input.GetKey(KeyCode.D))
                gameObject.transform.position.X += 500f * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
                gameObject.transform.position.X -= 500f * Time.deltaTime;
            if (Input.GetKey(KeyCode.S))
                gameObject.transform.position.Y += 500f * Time.deltaTime;
            if (Input.GetKey(KeyCode.W))
                gameObject.transform.position.Y -= 500f * Time.deltaTime;
        }
    }
}
