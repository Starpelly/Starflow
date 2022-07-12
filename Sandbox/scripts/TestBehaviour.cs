using Starflow;

namespace Sandbox
{
    public class TestMonoBehaviour : MonoBehaviour
    {
        private AudioSource ass;

        public override void Start()
        {
            ass = gameObject.AddComponent<AudioSource>();
            ass.clip = new AudioClip(@"C:\Users\Braedon\Music\MDK - Interlaced [HD].mp3");
            ass.volume = 0.00f;
            ass.playOnAwake = true;
            ass.Play();
        }

        public override void Update()
        {
            Debug.Log(ass.time);
            if (Input.GetKeyDown(KeyCode.Space))
                if (ass.isPlaying)
                    ass.Pause();
                else
                    ass.Play();
        }
    }
}
