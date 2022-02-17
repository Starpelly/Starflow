using Microsoft.Xna.Framework.Graphics;
using Starflow;

namespace Sandbox
{
    public class TestBehaviour : Behaviour
    {
        public override void Start()
        {
            Debug.Log("Start Call");
            Sprite sprite = new Sprite(Game1.ContentManager.Load<Texture2D>("morsh"));
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
