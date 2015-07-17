using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatterBox
{
    public interface ISymbolizer : IEnumerator<string>
    {
        //string GetNext();
        string LookAhead();
    }
}
