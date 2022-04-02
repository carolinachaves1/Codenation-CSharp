using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Exceptions
{
    public class LevelNotFoundException : Exception
    {
        public LevelNotFoundException() { }

        public LevelNotFoundException(string message)
            : base(message) { }

        public LevelNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
