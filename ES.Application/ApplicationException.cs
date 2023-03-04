using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application
{
    internal class ApplicationException: Exception
    {
        public ApplicationException(string message): base(message)
        { 
        }
    }
}
