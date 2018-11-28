namespace ClientApplication
{
    partial class RetireBookForm
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
            this.uxRetireButton = new System.Windows.Forms.Button();
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxBookIDBox = new System.Windows.Forms.TextBox();
            this.uxBookIDLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxRetireButton
            // 
            this.uxRetireButton.Location = new System.Drawing.Point(91, 42);
            this.uxRetireButton.Name = "uxRetireButton";
            this.uxRetireButton.Size = new System.Drawing.Size(163, 34);
            this.uxRetireButton.TabIndex = 16;
            this.uxRetireButton.Text = "Retire Book";
            this.uxRetireButton.UseVisualStyleBackColor = true;
            this.uxRetireButton.Click += new System.EventHandler(this.uxRetireButton_Click);
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(17, 42);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(68, 34);
            this.uxReturnButton.TabIndex = 13;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxBookIDBox
            // 
            this.uxBookIDBox.Location = new System.Drawing.Point(82, 11);
            this.uxBookIDBox.Name = "uxBookIDBox";
            this.uxBookIDBox.Size = new System.Drawing.Size(172, 20);
            this.uxBookIDBox.TabIndex = 12;
            // 
            // uxBookIDLabel
            // 
            this.uxBookIDLabel.AutoSize = true;
            this.uxBookIDLabel.Location = new System.Drawing.Point(27, 14);
            this.uxBookIDLabel.Name = "uxBookIDLabel";
            this.uxBookIDLabel.Size = new System.Drawing.Size(49, 13);
            this.uxBookIDLabel.TabIndex = 11;
            this.uxBookIDLabel.Text = "Book ID:";
            // 
            // RetireBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 90);
            this.Controls.Add(this.uxRetireButton);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxBookIDBox);
            this.Controls.Add(this.uxBookIDLabel);
            this.Name = "RetireBookForm";
            this.Text = "RetireBookForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxRetireButton;
        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.TextBox uxBookIDBox;
        private System.Windows.Forms.Label uxBookIDLabel;
    }
}