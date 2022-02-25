using Microsoft.Xna.Framework.Graphics;
using Starflow;

namespace Sandbox
{
    public class TestBehaviour : Behaviour
    {
        public float Float;
        public int Integer;
        public string String;

        public override void Start()
        {
            Debug.Log("Start Calls?");
            Sprite sprite = new Sprite(GameManager.Instance.Content.Load<Texture2D>("AMONGCOLON"));
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            // this.gameObject.transform.position = new Microsoft.Xna.Framework.Vector2(370, 10);
        }

        public override void Update()
        {
        	if (Input.GetKeyDown(KeyCode.Z))
            {
                AudioSource ass = this.gameObject.AddComponent<AudioSource>();
                ass.clip = new AudioClip(@"C:\Users\Braedon\Music\Brain Opwer.mp3");
                ass.Play();
            }
        }
    }
}
