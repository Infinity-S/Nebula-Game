using System;

namespace Nebula
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (NebulaGame game = new NebulaGame())
            {
                game.Run();
            }
        }
    }
#endif
}

