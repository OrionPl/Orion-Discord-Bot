namespace Orion_Bot
{
    partial class Main
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
            this.inputConsoleButton = new System.Windows.Forms.Button();
            this.consoleOutputRichTB = new System.Windows.Forms.RichTextBox();
            this.inputConsoleTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputConsoleButton
            // 
            this.inputConsoleButton.Location = new System.Drawing.Point(713, 416);
            this.inputConsoleButton.Name = "inputConsoleButton";
            this.inputConsoleButton.Size = new System.Drawing.Size(75, 23);
            this.inputConsoleButton.TabIndex = 0;
            this.inputConsoleButton.Text = "Send";
            this.inputConsoleButton.UseVisualStyleBackColor = true;
            this.inputConsoleButton.Click += new System.EventHandler(this.inputConsoleButton_Click);
            // 
            // consoleOutputRichTB
            // 
            this.consoleOutputRichTB.Location = new System.Drawing.Point(12, 12);
            this.consoleOutputRichTB.Name = "consoleOutputRichTB";
            this.consoleOutputRichTB.Size = new System.Drawing.Size(776, 400);
            this.consoleOutputRichTB.TabIndex = 1;
            this.consoleOutputRichTB.Text = "";
            // 
            // inputConsoleTB
            // 
            this.inputConsoleTB.Location = new System.Drawing.Point(12, 418);
            this.inputConsoleTB.Name = "inputConsoleTB";
            this.inputConsoleTB.Size = new System.Drawing.Size(695, 20);
            this.inputConsoleTB.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inputConsoleTB);
            this.Controls.Add(this.consoleOutputRichTB);
            this.Controls.Add(this.inputConsoleButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inputConsoleButton;
        private System.Windows.Forms.RichTextBox consoleOutputRichTB;
        private System.Windows.Forms.TextBox inputConsoleTB;
    }
}

