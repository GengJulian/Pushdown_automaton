using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pushdown_automaton
{
    class Grammar
    {
        public List<char> TerminalSymbols { get; set; }
        public List<string> NonTerminalSymbols { get; set; }
        public string StartSymbol { get; set; }
        public Dictionary<RuleKey, RuleValue> GrammarRules { get; set; }

        public Grammar(List<char> terminalSymbols, List<string> nonTerminalSymbols, String startSymbol, Dictionary<RuleKey, RuleValue> grammarRules)
        {
            TerminalSymbols = terminalSymbols;
            NonTerminalSymbols = nonTerminalSymbols;
            StartSymbol = startSymbol;
            GrammarRules = grammarRules;
        }
    }
}
