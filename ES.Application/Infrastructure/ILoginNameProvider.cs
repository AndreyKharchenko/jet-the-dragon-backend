using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Infrastructure
{
    public interface ILoginNameProvider
    {
        string CurrentLoginName { get; }
    }
}
