using System;

namespace Sprint0MingfengHan
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Sprint0Game game = new Sprint0Game())
            {
                game.Run();
            }
        }
    }
#endif
}

