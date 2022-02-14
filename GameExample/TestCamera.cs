using Tickflow;

namespace GameExample
{
    public class TestCamera : Behaviour
    {
        public Camera cam;
        private float moveSpeed = 350;

        public override void Update()
        {
            if (Input.GetKey(KeyCode.Up))
            {
                gameObject.transform.position.Y -= moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Down))
            {
                gameObject.transform.position.Y += moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Left))
            {
                gameObject.transform.position.X -= moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Right))
            {
                gameObject.transform.position.X += moveSpeed * Time.deltaTime;
            }
        }
    }
}
