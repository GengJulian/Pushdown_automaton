namespace Pushdown_automaton
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.inputExpression_textBox = new System.Windows.Forms.TextBox();
            this.validateInput_Button = new System.Windows.Forms.Button();
            this.accepted_Label = new System.Windows.Forms.Label();
            this.updateTable_Button = new System.Windows.Forms.Button();
            this.showSteps_button = new System.Windows.Forms.Button();
            this.AddNewRow_Button = new System.Windows.Forms.Button();
            this.AddNewColumn_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.AutoSize = true;
            this.tablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tablePanel.ColumnCount = 7;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.Location = new System.Drawing.Point(12, 85);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 12;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tablePanel.Size = new System.Drawing.Size(8, 13);
            this.tablePanel.TabIndex = 0;
            // 
            // inputExpression_textBox
            // 
            this.inputExpression_textBox.Location = new System.Drawing.Point(12, 24);
            this.inputExpression_textBox.Name = "inputExpression_textBox";
            this.inputExpression_textBox.Size = new System.Drawing.Size(216, 20);
            this.inputExpression_textBox.TabIndex = 1;
            this.inputExpression_textBox.TextChanged += new System.EventHandler(this.InputExpression_textBox_TextChanged);
            // 
            // validateInput_Button
            // 
            this.validateInput_Button.Location = new System.Drawing.Point(243, 22);
            this.validateInput_Button.Name = "validateInput_Button";
            this.validateInput_Button.Size = new System.Drawing.Size(75, 23);
            this.validateInput_Button.TabIndex = 2;
            this.validateInput_Button.Text = "Validate";
            this.validateInput_Button.UseVisualStyleBackColor = true;
            this.validateInput_Button.Visible = false;
            this.validateInput_Button.Click += new System.EventHandler(this.ValidateInput_Button_Click);
            // 
            // accepted_Label
            // 
            this.accepted_Label.AutoSize = true;
            this.accepted_Label.Location = new System.Drawing.Point(324, 29);
            this.accepted_Label.Name = "accepted_Label";
            this.accepted_Label.Size = new System.Drawing.Size(0, 13);
            this.accepted_Label.TabIndex = 5;
            this.accepted_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accepted_Label.Visible = false;
            // 
            // updateTable_Button
            // 
            this.updateTable_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.updateTable_Button.AutoSize = true;
            this.updateTable_Button.BackColor = System.Drawing.SystemColors.Control;
            this.updateTable_Button.Location = new System.Drawing.Point(541, 22);
            this.updateTable_Button.Name = "updateTable_Button";
            this.updateTable_Button.Size = new System.Drawing.Size(78, 23);
            this.updateTable_Button.TabIndex = 6;
            this.updateTable_Button.Text = "Update table";
            this.updateTable_Button.UseVisualStyleBackColor = false;
            this.updateTable_Button.Visible = false;
            this.updateTable_Button.Click += new System.EventHandler(this.UpdateTable_Button_Click);
            // 
            // showSteps_button
            // 
            this.showSteps_button.Location = new System.Drawing.Point(330, 21);
            this.showSteps_button.Name = "showSteps_button";
            this.showSteps_button.Size = new System.Drawing.Size(75, 23);
            this.showSteps_button.TabIndex = 7;
            this.showSteps_button.Text = "Show steps";
            this.showSteps_button.UseVisualStyleBackColor = true;
            this.showSteps_button.Visible = false;
            this.showSteps_button.Click += new System.EventHandler(this.ShowSteps_button_Click);
            // 
            // AddNewRow_Button
            // 
            this.AddNewRow_Button.AutoSize = true;
            this.AddNewRow_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddNewRow_Button.Location = new System.Drawing.Point(12, 50);
            this.AddNewRow_Button.Name = "AddNewRow_Button";
            this.AddNewRow_Button.Size = new System.Drawing.Size(79, 23);
            this.AddNewRow_Button.TabIndex = 8;
            this.AddNewRow_Button.Text = "Add new row";
            this.AddNewRow_Button.UseVisualStyleBackColor = true;
            this.AddNewRow_Button.Click += new System.EventHandler(this.AddNewRow_Button_Click);
            // 
            // AddNewColumn_Button
            // 
            this.AddNewColumn_Button.AutoSize = true;
            this.AddNewColumn_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddNewColumn_Button.Location = new System.Drawing.Point(111, 50);
            this.AddNewColumn_Button.Name = "AddNewColumn_Button";
            this.AddNewColumn_Button.Size = new System.Drawing.Size(96, 23);
            this.AddNewColumn_Button.TabIndex = 9;
            this.AddNewColumn_Button.Text = "Add new column";
            this.AddNewColumn_Button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(631, 514);
            this.Controls.Add(this.AddNewColumn_Button);
            this.Controls.Add(this.AddNewRow_Button);
            this.Controls.Add(this.showSteps_button);
            this.Controls.Add(this.updateTable_Button);
            this.Controls.Add(this.accepted_Label);
            this.Controls.Add(this.validateInput_Button);
            this.Controls.Add(this.inputExpression_textBox);
            this.Controls.Add(this.tablePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.TextBox inputExpression_textBox;
        private System.Windows.Forms.Button validateInput_Button;
        private System.Windows.Forms.Label accepted_Label;
        private System.Windows.Forms.Button updateTable_Button;
        private System.Windows.Forms.Button showSteps_button;
        private System.Windows.Forms.Button AddNewRow_Button;
        private System.Windows.Forms.Button AddNewColumn_Button;
    }
}

