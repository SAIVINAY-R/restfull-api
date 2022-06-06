using System;
using System.Runtime.Serialization;

namespace DemoApp.CustomeExceptions
{
    public class EntityAlreadyExistException : Exception
    {
        public EntityAlreadyExistException()
        {
        }

        public EntityAlreadyExistException(string message) : base(message)
        {
        }
    }
}
