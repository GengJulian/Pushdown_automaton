using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pushdown_automaton

{
    class PushdownAutomaton
    {
        public Stack<string> AutomatonStack { get; set; }
        public Grammar Grammar { get; set; }
        public bool Accepted { get; set; }
        public string Expr { get; set; }
        public List<string> ValidationSteps { get; set; }

        public PushdownAutomaton(Grammar grammar)
        {
            AutomatonStack = new Stack<string>();
            Grammar = grammar;
            ValidationSteps = new List<string>();
        }

        public void ValidateExpression(string expr)
        {
            Expr = Regex.Replace(expr + "#", "[0-9]+", "i");
            AutomatonStack.Push("#");
            AutomatonStack.Push(Grammar.StartSymbol);
            string validationStep;
            int index = 0;
            while (AutomatonStack.Count != 0)
            {
                validationStep = "";            
                char c = Expr[index];
                string top = AutomatonStack.Pop();
                RuleKey ruleKey = new RuleKey(c, top);
                if (Grammar.GrammarRules.ContainsKey(ruleKey))
                {
                    RuleValue nextStep;
                    Grammar.GrammarRules.TryGetValue(ruleKey, out nextStep);

                    List<string> reverse = new List<string>();
                    for (int i = nextStep.RuleValueElements.Count - 1; i >= 0; i--)
                    {
                        reverse.Add(nextStep.RuleValueElements[i]);
                    }
                    if (reverse.Count != 0 && reverse[0] == "pop")
                    {
                        index++;
                        validationStep = Expr.Substring(index) + ",";
                    }
                    else
                    {
                        validationStep = Expr.Substring(index) + ",";
                        foreach (string s in reverse)
                        {
                            AutomatonStack.Push(s);
                        }
                    }
                    for (int i = 0; i < AutomatonStack.Count; i++)
                    {
                        validationStep += AutomatonStack.ElementAt(i);
                    }
                    validationStep += ",";
                    if (ValidationSteps.Count > 0)
                    {
                        validationStep += ValidationSteps[ValidationSteps.Count - 1].Split(',')[2];
                        validationStep += nextStep.RuleValueID;
                    }
                    else
                    {
                        validationStep += nextStep.RuleValueID;
                    }
                    
                    
                }
                else
                {
                    validationStep = "";
                    validationStep = "Wrong expression";
                    // cella üres -> hibás a megadott kifejezés
                    break;
                }
                ValidationSteps.Add(validationStep);
            }

            if (AutomatonStack.Count == 0 && Expr[index] == '#')
            {
                validationStep = "";
                validationStep = "O.K.";
                ValidationSteps.Add(validationStep);
                Accepted = true;
            }
        }
    }
}
