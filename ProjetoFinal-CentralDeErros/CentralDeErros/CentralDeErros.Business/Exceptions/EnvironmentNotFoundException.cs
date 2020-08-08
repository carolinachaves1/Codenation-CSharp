using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Exceptions
{
    public class EnvironmentNotFoundException : Exception
    {
        public EnvironmentNotFoundException() { }

        public EnvironmentNotFoundException(string message)
            : base(message) { }

        public EnvironmentNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
