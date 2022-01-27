﻿using System;

namespace JadesToolkit.Services.Exceptions
{
    [Serializable]
    public class InvalidStateException : Exception
    {
        public InvalidStateException() { }
        public InvalidStateException(string message) : base(message) { }
        public InvalidStateException(string message, Exception inner) : base(message, inner) { }
    }
}