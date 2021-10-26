using System;

namespace ApiGameCatalog.Exceptions
{
    public class GameAlreadyRegisteredException : Exception
    {
        public GameAlreadyRegisteredException() : base("Game already Registered.")
        {

        }
    }
}