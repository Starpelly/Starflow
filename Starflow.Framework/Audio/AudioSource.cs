using System.Threading;
using NAudio;
using NAudio.Wave;

namespace Starflow
{
    public class AudioSource : Behaviour
    {
        /// <summary>
        /// The default AudioClip to play.
        /// </summary>
        public AudioClip clip;
        /// <summary>
        /// Un- / Mutes the AudioSource. Mute sets the volume=0, Un-Mute restore the original volume.
        /// </summary>
        public bool mute;
        /// <summary>
        /// If set to true, the audio source will automatically start playing on awake.
        /// </summary>
        public bool playOnAwake = true;
        /// <summary>
        /// Is the audio clip looping?
        /// </summary>
        public bool loop;
        /// <summary>
        /// The pitch of the audio source.
        /// </summary>
        public float pitch;
        /// <summary>
        /// Playback position in seconds.
        /// </summary>
        public double time
        {
            get => Time();
            set {}
        }
        public float volume;

        private double Time()
        {
            if (this.outputDevice != null && audioFile != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                    return (this.outputDevice.GetPosition() * 1000.0 /
                        this.outputDevice.OutputWaveFormat.BitsPerSample / this.outputDevice.OutputWaveFormat.Channels *
                        8 / this.outputDevice.OutputWaveFormat.SampleRate) / 1000.0;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
        
        private WaveOutEvent outputDevice { get; set; }
        private AudioFileReader audioFile { get; set; }

        public AudioSource()
        {
            GameManager.Components.Add(this);
        }

        public void Play()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }

            if (audioFile == null)
            {
                audioFile = new AudioFileReader(clip.audioFileURL);
                outputDevice.Init(audioFile);
            }
            
            outputDevice.Play();
        }
        

        public void Pause()
        {
            
        }

        public void UnPause()
        {
            
        }

        public void Stop()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();   
            }
            else
            {
                Debug.LogError("No Output Device!");
            }
        }
        
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        public override void Awake()
        {
            if (playOnAwake)
            {
                Play();
            }
        }
    }
}