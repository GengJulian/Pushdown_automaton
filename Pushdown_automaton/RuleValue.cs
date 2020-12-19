using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pushdown_automaton
{
    class RuleValue
    {
        public List<string> RuleValueElements { get; set; }
        public string RuleValueID { get; set; }

        public RuleValue(List<string> ruleValueElement, string ruleValueID)
        {
            RuleValueElements = ruleValueElement;
            RuleValueID = ruleValueID;
        }

        public override string ToString()
        {
            string stringRepresentation = "";
            foreach (var element in RuleValueElements)
            {
                stringRepresentation += element;
            }

            return string.Format("Value elements: {0} ValueID: {1}",
                                 stringRepresentation,
                                 RuleValueID.ToString());
        }
    }
}
