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
            ass.clip = new AudioClip(@"C:\Users\Braedon\Music\Brain Opwer.mp3");
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
        }
    }
}
