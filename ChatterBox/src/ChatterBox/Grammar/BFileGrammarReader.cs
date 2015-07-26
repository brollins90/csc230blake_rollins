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
            _streamReader = new StreamReader(new FileStream(_filename, FileMode.Open));
        }

        ~BFileGrammarReader()
        {
            _streamReader.Dispose();
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
            if (string.IsNullOrWhiteSpace(line))
            {
                return new Production[0];
            }
            var productionsFound = new List<Production>();

            var colonIndex = line.IndexOf(':');
            var lhsLength = colonIndex;

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
                    //Console.WriteLine(word);
                    bool isTerminal = word.Contains('\'');

                    GrammarSymbol symbol;
                    string finalWord = string.Empty;
                    if (isTerminal)
                    {
                        // Trim away the quotes and then lower case it
                        finalWord = word.Trim('\'');
                        finalWord = finalWord.ToLowerInvariant();
                        symbol = new GrammarTerminal(finalWord);
                    }
                    else
                    {
                        // uppercase the variables
                        finalWord = word.ToUpperInvariant();
                        symbol = GrammarVariable.Get(finalWord);
                    }
                    //Console.WriteLine(finalWord);
                    symbols.Add(symbol);
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
