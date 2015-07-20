namespace ChatterBox
{
    using System.Collections.Generic;

    public interface ISymbolizer : IEnumerator<string>
    {
        string LookAhead();
    }
}