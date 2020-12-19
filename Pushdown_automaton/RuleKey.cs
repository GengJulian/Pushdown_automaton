using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pushdown_automaton

{
    class RuleKey
    {
        public char Character { get; set; }
        public string CurrentTerminalSymbol { get; set; }

        public RuleKey(char character, string current)
        {
            Character = character;
            CurrentTerminalSymbol = current;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            RuleKey clone = obj as RuleKey;
            if (Character == clone.Character && CurrentTerminalSymbol == clone.CurrentTerminalSymbol)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Character, CurrentTerminalSymbol).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Character: {0} TerminalSymbol: {1}",this.Character,this.CurrentTerminalSymbol);
        }
    }
}
