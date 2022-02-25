namespace Starflow
{
    public class AudioSource : Component
    {
        public AudioClip clip;
        public bool mute;
        public bool playOnAwake;
        public bool loop;
        public float pitch;
        public float time;
        public float volume;
        
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
            clip.Stop();
        }
    }
}