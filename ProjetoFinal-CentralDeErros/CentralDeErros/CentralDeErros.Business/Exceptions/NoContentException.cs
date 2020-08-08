using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Exceptions
{
    public class NoContentException : Exception
    {
        public NoContentException() { }

        public NoContentException(string message)
            : base(message) { }

        public NoContentException(string message, Exception inner)
            : base(message, inner) { }
    }
}
