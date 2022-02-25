using System;

namespace Starflow.Editor
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new StarflowEditor())
                game.Run();
        }
    }
}