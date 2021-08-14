using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioseca.Model.Exception
{
    class BusinessRuleException : ApplicationException
    {

        public BusinessRuleException(string message) : base(message)
        {
        }

    }
}
