using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Exceptions
{
    public class EmptyStringException : Exception
    {
        private const string MESSAGE = "{0} cannot be null or whitespace";

        public EmptyStringException(string propertyName) :
            base(string.Format(MESSAGE, propertyName))
        {
        }
    }
}
