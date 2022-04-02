using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.Business.Exceptions
{
    public class ErrorNotFoundException : Exception
    {
        public ErrorNotFoundException() { }

        public ErrorNotFoundException(string message)
            : base(message) { }

        public ErrorNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
