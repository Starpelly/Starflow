using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starflow;

namespace Sandbox
{
    public class TestBehaviour : Behaviour
    {
        public float Float;
        public int Integer;
        public string String;

        private AudioSource ass;

        public override void Start()
        {
            Debug.Log("Start Calls?");
            Sprite sprite = new Sprite(GameManager.Instance.Content.Load<Texture2D>("AMONGCOLON"));
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            // this.gameObject.transform.position = new Microsoft.Xna.Framework.Vector2(370, 10);
            ass = this.gameObject.AddComponent<AudioSource>();
            ass.clip = new AudioClip(@"C:\Users\Braedon\Music\Big Rock Finish H.mp3");
            ass.playOnAwake = true;
        }

        public override void Update()
        {
        	if (Input.GetKeyDown(KeyCode.Z))
            {
                ass.Play();
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                this.gameObject.GetComponent<AudioSource>().Stop();
            }

            float val = Normalize((float)ass.time, 0, 10);
            gameObject.transform.position = new Vector2(MathHelper.Lerp(0, 400, val), 0);
        }
        
        public static float Normalize(float val, float min, float max)
        {
            return (val - min) / (max - min);
        }
    }
}
