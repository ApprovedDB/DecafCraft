using System;

namespace DecafCraft.Server
{
    public class Decaf
    {
        private static bool _isRunning = false;
        public static bool IsRunning() => _isRunning;

        private static Server _server;

        /* CTor for Server */
        public Decaf()
        {
            
            _isRunning = true;
        }
        
        public static Server GetServer() => _server;

        public static void SetServer(Server server)
        {
            if (_server != null)
            {
                throw new InvalidOperationException("Cannot redifine Server.");
            }

            _server = server;
        }
    }
}