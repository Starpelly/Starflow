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
            Texture2D tex = Content.Load<Texture2D>("AMONGCOLON");
            gameObject = new GameObject("Test", tex);

            TestBehaviour testBehaviour = gameObject.AddComponent<TestBehaviour>();
        }

        public void Update()
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

            // Debug.Log(Input.mousePosition);
        }
    }
}
