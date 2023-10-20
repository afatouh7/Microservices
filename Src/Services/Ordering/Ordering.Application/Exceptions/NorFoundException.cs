using System;

namespace Ordering.Application.Exceptions
{
    public class NorFoundException :ApplicationException
    {
        public NorFoundException(string name, object key) : base($"Entity \"{ name}\" ({key}) was notfound")
        {

        }
    }
}
