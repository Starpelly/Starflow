using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starflow
{
    public static class Time
    {
        /// <summary>
        /// The interval in seconds from the last frame to the current one.
        /// </summary>
        public static float deltaTime { get; set; }

        /// <summary>
        /// The time in seconds since the game started.
        /// </summary>
        public static float time { get; set; }

        public static int frameCount { get; set; }

        public static int fps { get { return _fps; } }

        static internal int _fps { get; set; }

        static internal DateTime _lastTime { get; set; }
        static internal int _framesRendered = 0;
    }
}
