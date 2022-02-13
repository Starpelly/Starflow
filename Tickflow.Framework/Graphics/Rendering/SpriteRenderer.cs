using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tickflow
{
   public sealed class SpriteRenderer : Component
   {
        public Sprite sprite;
        public Color color;
        public bool flipX;
        public bool flipY;
        public int sortingOrder;

        public SpriteRenderer()
        {
        }

        public void Draw(SpriteBatch sb)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (flipX) spriteEffects = SpriteEffects.FlipHorizontally;
            if (flipY) spriteEffects = SpriteEffects.FlipVertically;

            sb.Draw(sprite.texture, gameObject.transform.position, new Rectangle(), color, gameObject.transform.rotation, new Vector2(0, 0), gameObject.transform.scale, spriteEffects, sortingOrder);
        }
   }
}
