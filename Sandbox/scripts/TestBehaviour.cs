using Microsoft.Xna.Framework;
using Starflow;

namespace Sandbox
{
    public class TestMonoBehaviour : MonoBehaviour
    {
        private AudioSource ass;

        public override void Start()
        {
            ass = gameObject.AddComponent<AudioSource>();
            var sprite = gameObject.AddComponent<SpriteRenderer>();
            sprite.sprite = new Sprite(@"C:\Users\Braedon\Pictures\k4l10a-V_400x400.jpg");
            ass.clip = new AudioClip(@"C:\Users\Braedon\Music\MDK - Interlaced [HD].mp3");
            ass.volume = 0.00f;
            ass.playOnAwake = true;
            ass.Play();
            // transform.position = new Vector2(640, 360);
        }

        public override void Update()
        {
            float speed = 250;
            Vector2 dir = Vector2.Zero;

            if (Input.GetKey(KeyCode.Left))
                dir.X -= 1;
            if (Input.GetKey(KeyCode.Right))
                dir.X += 1;
            if (Input.GetKey(KeyCode.Up))
                dir.Y -= 1;
            if (Input.GetKey(KeyCode.Down))
                dir.Y += 1;
            if (dir != Vector2.Zero)
                dir.Normalize();

            transform.position += dir * Time.deltaTime * speed;
        }
    }
}
