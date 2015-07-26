namespace ChatterBox.Parser
{
    using System.Collections.Generic;

    public interface ITokenizer : IEnumerator<string>
    {
        string LookAhead();
    }
}