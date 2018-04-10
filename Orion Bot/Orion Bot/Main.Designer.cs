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
            this.inputTB = new System.Windows.Forms.TextBox();
            this.consoleRichTB = new System.Windows.Forms.RichTextBox();
            this.consoleSendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTB
            // 
            this.inputTB.Location = new System.Drawing.Point(12, 418);
            this.inputTB.Name = "inputTB";
            this.inputTB.Size = new System.Drawing.Size(695, 20);
            this.inputTB.TabIndex = 0;
            // 
            // consoleRichTB
            // 
            this.consoleRichTB.Location = new System.Drawing.Point(12, 12);
            this.consoleRichTB.Name = "consoleRichTB";
            this.consoleRichTB.Size = new System.Drawing.Size(776, 400);
            this.consoleRichTB.TabIndex = 1;
            this.consoleRichTB.Text = "";
            // 
            // consoleSendButton
            // 
            this.consoleSendButton.Location = new System.Drawing.Point(713, 416);
            this.consoleSendButton.Name = "consoleSendButton";
            this.consoleSendButton.Size = new System.Drawing.Size(75, 23);
            this.consoleSendButton.TabIndex = 2;
            this.consoleSendButton.Text = "Send";
            this.consoleSendButton.UseVisualStyleBackColor = true;
            this.consoleSendButton.Click += new System.EventHandler(this.consoleSendButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.consoleSendButton);
            this.Controls.Add(this.consoleRichTB);
            this.Controls.Add(this.inputTB);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTB;
        private System.Windows.Forms.RichTextBox consoleRichTB;
        private System.Windows.Forms.Button consoleSendButton;
    }
}