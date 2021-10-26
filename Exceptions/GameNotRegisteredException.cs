using System;

namespace ApiGameCatalog.Exceptions
{
    public class GameNotRegiteredException : Exception
    {
        public GameNotRegiteredException() : base("This game not registered.")
        {}
    }
}