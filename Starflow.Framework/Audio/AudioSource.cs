namespace Starflow
{
    public class AudioSource : Component
    {
        public AudioClip clip { get; set; }
        public float pitch { get; set; }
        public float time { get; set; }
        public float volume { get; set; }
        
        public AudioSource()
        {
            GameManager.Components.Add(this);
        }

        public void Play()
        {
            clip.Play();
        }

        public void Pause()
        {
            
        }

        public void UnPause()
        {
            
        }

        public void Stop()
        {
            
        }
    }
}