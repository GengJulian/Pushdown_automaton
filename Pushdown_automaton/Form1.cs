using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pushdown_automaton
{
    public partial class Form1 : Form
    {
        private string[,] parsingTable;
        List<string> nonTerminalSymbols;
        List<char> terminalSymbols;
        string startSymbol;
        Dictionary<RuleKey, RuleValue> grammarRules;
        Grammar grammar;
        PushdownAutomaton pushdownAutomaton;
        string[,] tempParsingTable;
        Dictionary<string, string> changedCells;


        public Form1()
        {
            InitializeComponent();
            nonTerminalSymbols = new List<string> { "E", "E'", "T", "T'", "F" };
            terminalSymbols = new List<char> { '+', '*', '(', ')', 'i' };
            startSymbol = "E";
            grammarRules = new Dictionary<RuleKey, RuleValue>
            {
                { new RuleKey('(',"E"),new RuleValue( new List<string> { "T", "E'" },"1") },
                { new RuleKey('i',"E"), new RuleValue(new List<string> { "T", "E'" },"1")},
                { new RuleKey('+',"E'"), new RuleValue(new List<string> { "+", "T", "E'" },"2" )},
                { new RuleKey(')',"E'"), new RuleValue(new List<string> {},"3") },
                { new RuleKey('#',"E'"), new RuleValue(new List<string> {},"3") },
                { new RuleKey('(',"T"), new RuleValue(new List<string> { "F", "T'" },"4") },
                { new RuleKey('i',"T"), new RuleValue(new List<string> { "F", "T'" },"4") },
                { new RuleKey('+',"T'"), new RuleValue(new List<string> {},"6") },
                { new RuleKey('*',"T'"), new RuleValue(new List<string> { "*", "F", "T'" },"5") },
                { new RuleKey(')',"T'"), new RuleValue(new List<string> {},"6")},
                { new RuleKey('#',"T'"), new RuleValue(new List<string> {},"6")},
                { new RuleKey('(',"F"), new RuleValue(new List<string> { "(", "E", ")" },"7") },
                { new RuleKey('i',"F"), new RuleValue(new List<string> { "i" },"8") },
                { new RuleKey('+',"+"), new RuleValue(new List<string> { "pop" },"") },
                { new RuleKey('*',"*"), new RuleValue(new List<string> { "pop" },"") },
                { new RuleKey('(',"("), new RuleValue(new List<string> { "pop" },"") },
                { new RuleKey(')',")"), new RuleValue(new List<string> { "pop" },"") },
                { new RuleKey('i',"i"), new RuleValue(new List<string> { "pop" },"") },
            };

            grammar = new Grammar(
                terminalSymbols,
                nonTerminalSymbols,
                startSymbol,
                grammarRules);

            parsingTable = new String[,]{
                    {"", "+", "*", "(", ")", "i", "#"},
                    {"E", "", "", "(TE',1)", "", "(TE',1)", ""},
                    {"E'", "(+TE',2)", "", "", "(e,3)", "", "(e,3)"},
                    {"T", "", "", "(FT',4)", "", "(FT',4)", ""},
                    {"T'", "(e,6)", "(*FT',5)", "", "(e,6)", "", "(e,6)"},
                    {"F", "", "", "((E),7)", "", "(i,8)", ""},
                    {"+", "pop", "", "", "", "", ""},
                    {"*", "", "pop", "", "", "", ""},
                    {"(", "", "", "pop", "", "", ""},
                    {")", "", "", "", "pop", "", ""},
                    {"i", "", "", "", "", "pop", ""},
                    {"#", "", "", "", "", "", "elfogad"}};
            tempParsingTable = parsingTable;
            DrawMatrix(tempParsingTable);
            pushdownAutomaton = new PushdownAutomaton(grammar);
            changedCells = new Dictionary<string, string>();
        }

        private void DrawMatrix(string[,] matrix)
        {
            tablePanel.AutoSize = true;
            tablePanel.Controls.Clear();
            tablePanel.Refresh();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    TextBox textbox = new TextBox();
                    textbox.Name = string.Format("{0}{1}", row, column);
                    textbox.Text = matrix[row, column];
                    textbox.Font = new Font("Times New Roman", 16.0f,
                        FontStyle.Bold);
                    textbox.TextChanged += TextChanged;
                    textbox.TextAlign = HorizontalAlignment.Center;
                    tablePanel.Controls.Add(textbox, column, row);
                }
            }
        }

        private new void TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string cellValue = tb.Text;
            int rowIndex = int.Parse(tb.Name[0].ToString());
            int columnIndex = int.Parse(tb.Name[1].ToString());
            tempParsingTable[rowIndex, columnIndex] = cellValue;
            updateTable_Button.Visible = true;
            string cellKey = rowIndex + "," + columnIndex;
            if (changedCells.ContainsKey(cellKey))
            {
                changedCells[cellKey] = cellValue;
            }
            else
            {
                changedCells.Add(cellKey, cellValue);
            }
        }

        private void EditGrammarByTable(int rowId, int columnId, string newCellValue)
        {
            newCellValue = newCellValue.Trim('(');
            newCellValue = newCellValue.Trim(')');
            if (rowId > 0 && columnId > 0)
            {
                char character = Convert.ToChar(tempParsingTable[0, columnId]);
                string terminalSymbol = tempParsingTable[rowId, 0];
                RuleKey key = new RuleKey(character, terminalSymbol);
                if (newCellValue.Length > 0)
                {
                    RuleValue newRuleValue;
                    if (rowId < 6)
                    {
                        string ruleValueID = newCellValue.Split(',')[1];
                        newCellValue = newCellValue.Split(',')[0];
                        string[] ruleValueElements = new string[newCellValue.Length];
                        for (int i = 0; i < grammar.NonTerminalSymbols.Count; i++)
                        {
                            int index = newCellValue.IndexOf(grammar.NonTerminalSymbols[i]);
                            if (index != -1)
                            {
                                string symbol = grammar.NonTerminalSymbols[i];
                                ruleValueElements[index] = symbol;
                            }
                        }
                        for (int i = 0; i < grammar.TerminalSymbols.Count; i++)
                        {
                            int index = newCellValue.IndexOf(grammar.TerminalSymbols[i]);
                            if (index != -1)
                            {
                                ruleValueElements[index] = Convert.ToString(grammar.TerminalSymbols[i]);
                            }
                        }

                        if (ruleValueElements.Length == 0)
                        {
                            ruleValueElements[0] = newCellValue;
                        }

                        List<string> elementList = ruleValueElements.ToList();
                        newRuleValue = new RuleValue(elementList, ruleValueID);
                    }
                    else
                    {
                        newRuleValue = new RuleValue(new List<string> { newCellValue }, "");
                    }


                    if (grammarRules.ContainsKey(key))
                    {
                        grammarRules[key] = newRuleValue;
                    }
                    else
                    {
                        grammarRules.Add(key, newRuleValue);
                    }
                }
                else
                {
                    if (grammarRules.ContainsKey(key))
                    {
                        grammarRules.Remove(key);
                    }
                }

            }
        }



        private void ValidateInput_Button_Click(object sender, EventArgs e)
        {
            showSteps_button.Visible = false;
            accepted_Label.Visible = false;
            if (inputExpression_textBox.Text.Length > 0)
            {
                pushdownAutomaton.ValidateExpression(inputExpression_textBox.Text);
                if (pushdownAutomaton.Accepted)
                {
                    accepted_Label.Text = "Valid expression!";
                    accepted_Label.ForeColor = Color.Green;
                    accepted_Label.Visible = true;
                    showSteps_button.Visible = true;
                }
                else
                {
                    accepted_Label.Text = "Not valid expression!";
                    accepted_Label.ForeColor = Color.Red;
                    accepted_Label.Visible = true;
                }
                pushdownAutomaton.Accepted = false;
                pushdownAutomaton.AutomatonStack.Clear();
            }
        }

        private void UpdateTable_Button_Click(object sender, EventArgs e)
        {
            foreach (var cell in changedCells)
            {
                var keyComponents = cell.Key.Split(',');
                int rowIndex = Convert.ToInt32(keyComponents[0]);
                int columnIndex = Convert.ToInt32(keyComponents[1]);
                EditGrammarByTable(rowIndex, columnIndex, cell.Value);
            }
            changedCells.Clear();
            updateTable_Button.Visible = false;

            for (int row = 0; row < 12; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    Console.Write(tempParsingTable[row, column] + " ");
                }
                Console.WriteLine("");
            }

            foreach (var rule in grammarRules)
            {
                Console.WriteLine("Key: "
                              + rule.Key.ToString()
                              + " "
                              + rule.Value.ToString());
            }
        }

        private void InputExpression_textBox_TextChanged(object sender, EventArgs e)
        {
            if (inputExpression_textBox.Text.Length > 0)
                validateInput_Button.Visible = true;
            else
                validateInput_Button.Visible = false;
        }

        private void ShowSteps_button_Click(object sender, EventArgs e)
        {
            ValidationSteps stepsForm = new ValidationSteps(pushdownAutomaton.ValidationSteps);
            stepsForm.Show();
            pushdownAutomaton.ValidationSteps.Clear();
        }

        private void AddNewRow_Button_Click(object sender, EventArgs e)
        {
            string[,] extendedMatrix = new string[tempParsingTable.GetLength(0) + 1, tempParsingTable.GetLength(1) + 1];
            for (int i = 0; i < tempParsingTable.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < tempParsingTable.GetLength(1); j++)
                {
                    extendedMatrix[i, j] = tempParsingTable[i, j];
                    Console.Write(extendedMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < tempParsingTable.GetLength(1); i++)
            {
                extendedMatrix[extendedMatrix.GetLength(0)-1, i] = tempParsingTable[tempParsingTable.GetLength(0) - 1, i];
            }

            tempParsingTable = extendedMatrix;
            DrawMatrix(tempParsingTable);
            
        }
    }
}
