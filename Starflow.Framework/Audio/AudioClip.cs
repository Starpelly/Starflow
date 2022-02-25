using NAudio;
using NAudio.Wave;

namespace Starflow
{
    public class AudioClip
    {
        private WaveOutEvent outputDevice { get; set; }
        private AudioFileReader audioFile { get; set; }
        private string audioFileURL { get; set; }
        
        public float length { get; }

        public AudioClip(string url)
        { 
            audioFileURL = url;
        }
        
        internal void Play()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }

            if (audioFile == null)
            {
                audioFile = new AudioFileReader(audioFileURL);
                outputDevice.Init(audioFile);
            }
            
            outputDevice.Play();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }
    }
}