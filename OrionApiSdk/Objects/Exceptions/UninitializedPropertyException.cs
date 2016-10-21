using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Exceptions
{
    public class UninitializedPropertyException : Exception
    {
        private const string MESSAGE = "{0} cannot be uninitialized";

        public UninitializedPropertyException(string propertyName) : 
            base(string.Format(MESSAGE, propertyName))
        {
        }
    }
}
