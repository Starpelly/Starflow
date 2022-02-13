using Microsoft.Xna.Framework;
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
                return new Rectangle(transform.position.ToPoint(), transform.scale.ToPoint() * sprite.texture.Bounds.Size);
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

            sb.Draw(sprite.texture, Rect, color);
        }
   }
}
