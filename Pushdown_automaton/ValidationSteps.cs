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
    public partial class ValidationSteps : Form
    {
        List<string> validationSteps;
        public ValidationSteps()
        {
            InitializeComponent();
        }

        public ValidationSteps(List<string> validationSteps)
        {
            InitializeComponent();
            this.validationSteps = validationSteps;
            ShowValidationSteps();
        }

        public void ShowValidationSteps()
        {
            validationSteps_tableLayoutPanel.Visible = true;
            for (int i = 0; i < validationSteps.Count; i++)
            {
                TextBox textbox1 = new TextBox();
                textbox1.Text = validationSteps[i];
                textbox1.Font = new Font("Times New Roman", 16.0f,
                    FontStyle.Bold);
                textbox1.TextAlign = HorizontalAlignment.Center;
                Size size = TextRenderer.MeasureText(textbox1.Text, textbox1.Font);
                textbox1.Width = size.Width;
                textbox1.Height = size.Height;
                textbox1.Enabled = false;
                validationSteps_tableLayoutPanel.Controls.Add(textbox1, 0, i);
            }
        }
    }
}
