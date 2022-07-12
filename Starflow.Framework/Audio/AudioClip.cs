using System.Threading;

namespace Starflow
{
    public class AudioClip
    {
        public string audioFileURL { get; set; }
        
        public float length { get; }

        public AudioClip(string url)
        { 
            audioFileURL = url;
        }
        
        // RUN DEM DEGREES MY NIGGA
    }
}