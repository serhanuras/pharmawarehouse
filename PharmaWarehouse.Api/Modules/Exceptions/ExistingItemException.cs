using System;

namespace PharmaWarehouse.Api.Modules.Exceptions
{
    public class ExistingItemException : Exception
    {
        public ExistingItemException(string message)
            : base(message)
        {
        }
    }
}
