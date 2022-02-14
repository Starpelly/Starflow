﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tickflow
{
   public sealed class SpriteRenderer : Component
   {
        public Sprite sprite;
        public Color color = Color.White;
        public bool flipX;
        public bool flipY;
        public int sortingOrder;

        public Rectangle Rect
        {
            get
            {
                return new Rectangle(transform.position.ToPoint() + sprite.offset.ToPoint(), 
                    new Point((int)(transform.scale.X * sprite.texture.Bounds.Size.X), (int)(transform.scale.Y * sprite.texture.Bounds.Size.Y)));
            }
        }

        public SpriteRenderer()
        {
            GameManager.Components.Add(this);
        }

        public void Draw(SpriteBatch sb)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (flipX) spriteEffects = SpriteEffects.FlipHorizontally;
            if (flipY) spriteEffects = SpriteEffects.FlipVertically;

            // temp solution rn
            sprite.pivot = new Vector2(sprite.texture.Width / 2, sprite.texture.Height / 2);

            sb.Draw(sprite.texture, Rect, null, color, gameObject.transform.rotation, sprite.pivot, spriteEffects, 0f);
        }
   }
}
