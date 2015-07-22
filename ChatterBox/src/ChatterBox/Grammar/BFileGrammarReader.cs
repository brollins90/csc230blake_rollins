using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChatterBox.Grammar
{
    public class BFileGrammarReader : IGrammarReader
    {
        private string _filename;
        private StreamReader _streamReader;

        public BFileGrammarReader(string filename)
        {
            _filename = filename;
            _streamReader = new StreamReader(_filename);
        }

        ~BFileGrammarReader()
        {
            _streamReader.Close();
        }

        public IGrammar ReadGrammar()
        {
            string line;
            BGrammar grammar = new BGrammar();

            while ((line = GetNextLine()) != null)
            {
                var current = ProcessLine(line);
                grammar.AddProduction(current);
            }

            return grammar;
        }

        private Production[] ProcessLine(string line)
        {
            var productionsFound = new List<Production>();

            var colonIndex = line.IndexOf(':');
            //var lookaheadIndex = line.IndexOf('_');
            //lookaheadIndex = (lookaheadIndex == -1) ? line.Length : lookaheadIndex;

            var lhsLength = colonIndex;
            //var rhsLength = lookaheadIndex - lhsLength;
            //var lookaheadLength = line.Length - (lhsLength + rhsLength);

            var lhs = line.Substring(0, lhsLength).Trim();
            var rhs = line.Substring(colonIndex + 1).Trim();
            var split = rhs.Split('|');

            GrammarVariable variable = GrammarVariable.Get(lhs.ToUpper());

            foreach (var rule in split)
            {
                string ruleString = rule.Trim();
                var symbols = new List<GrammarSymbol>();

                var lookaheadIndex = ruleString.IndexOf('_');
                bool hasLookahead = lookaheadIndex != -1;

                var words = (hasLookahead)
                    ? ruleString.Substring(0, lookaheadIndex).Trim().Split(' ')
                    : ruleString.Split(' ');

                foreach (var word in words)
                {
                    bool isTerminal = word.Contains('\'');

                    GrammarSymbol symbol = (isTerminal)
                        ? (GrammarSymbol)new GrammarTerminal(word.Trim('\''))
                        : (GrammarSymbol)GrammarVariable.Get(word.ToUpper());

                    //if (isTerminal && string.IsNullOrWhiteSpace((symbol as GrammarTerminal).Value))
                    //{
                    //}
                    //else
                    //{
                        symbols.Add(symbol);
                    //}
                }

                var newProduction = new Production(variable, new GrammarMatcher(symbols.ToArray()));
                if (hasLookahead)
                {
                    var lookahead = rule.Substring(lookaheadIndex + 1);
                    bool negate = lookahead.StartsWith("!");
                    lookahead = lookahead.Replace(' ', ' ');
                    lookahead = lookahead.Replace('!', ' ');
                    lookahead = lookahead.Replace('\'', ' ');
                    lookahead = lookahead.Trim(' ');

                    newProduction.Matcher.Lookahead = lookahead;
                    newProduction.Matcher.LookaheadBool = !negate;
                }

                productionsFound.Add(newProduction);
            }

            return productionsFound.ToArray();
        }

        private string GetNextLine()
        {
            var line = _streamReader.ReadLine();
            return line;
        }




    }
}
