using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Tickflow;

namespace GameExample
{
    public class MainGame : GameManager
    {
        GameObject gameObject;
        public override void Start()
        {
            Texture2D tex = Graphics.Rectangle(Color.Magenta, 32, 32);
            gameObject = new GameObject("Test", tex);
        }

        public override void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += new Vector2(500 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position += new Vector2(-500 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector2(0, -500 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position += new Vector2(0, 500 * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                Exit();

            Debug.Log(Input.mousePosition);
        }

        public override void Draw(SpriteBatch sb)
        {
            gameObject.Draw(sb);
        }

    }
}
