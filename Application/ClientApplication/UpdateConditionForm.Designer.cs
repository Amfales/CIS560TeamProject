namespace ClientApplication
{
    partial class UpdateConditionForm
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
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxBookIDBox = new System.Windows.Forms.TextBox();
            this.uxBookIDLabel = new System.Windows.Forms.Label();
            this.uxConditionLabel = new System.Windows.Forms.Label();
            this.uxConditionBox = new System.Windows.Forms.ComboBox();
            this.uxUpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(12, 72);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(68, 34);
            this.uxReturnButton.TabIndex = 7;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxBookIDBox
            // 
            this.uxBookIDBox.Location = new System.Drawing.Point(77, 12);
            this.uxBookIDBox.Name = "uxBookIDBox";
            this.uxBookIDBox.Size = new System.Drawing.Size(172, 20);
            this.uxBookIDBox.TabIndex = 6;
            // 
            // uxBookIDLabel
            // 
            this.uxBookIDLabel.AutoSize = true;
            this.uxBookIDLabel.Location = new System.Drawing.Point(22, 15);
            this.uxBookIDLabel.Name = "uxBookIDLabel";
            this.uxBookIDLabel.Size = new System.Drawing.Size(49, 13);
            this.uxBookIDLabel.TabIndex = 5;
            this.uxBookIDLabel.Text = "Book ID:";
            // 
            // uxConditionLabel
            // 
            this.uxConditionLabel.AutoSize = true;
            this.uxConditionLabel.Location = new System.Drawing.Point(17, 46);
            this.uxConditionLabel.Name = "uxConditionLabel";
            this.uxConditionLabel.Size = new System.Drawing.Size(54, 13);
            this.uxConditionLabel.TabIndex = 8;
            this.uxConditionLabel.Text = "Condition:";
            // 
            // uxConditionBox
            // 
            this.uxConditionBox.FormattingEnabled = true;
            this.uxConditionBox.Items.AddRange(new object[] {
            "Poor",
            "Fair",
            "Good",
            "New"});
            this.uxConditionBox.Location = new System.Drawing.Point(77, 42);
            this.uxConditionBox.Name = "uxConditionBox";
            this.uxConditionBox.Size = new System.Drawing.Size(172, 21);
            this.uxConditionBox.TabIndex = 9;
            // 
            // uxUpdateButton
            // 
            this.uxUpdateButton.Location = new System.Drawing.Point(86, 72);
            this.uxUpdateButton.Name = "uxUpdateButton";
            this.uxUpdateButton.Size = new System.Drawing.Size(163, 34);
            this.uxUpdateButton.TabIndex = 10;
            this.uxUpdateButton.Text = "Update Condition";
            this.uxUpdateButton.UseVisualStyleBackColor = true;
            this.uxUpdateButton.Click += new System.EventHandler(this.uxUpdateButton_Click);
            // 
            // UpdateConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 121);
            this.Controls.Add(this.uxUpdateButton);
            this.Controls.Add(this.uxConditionBox);
            this.Controls.Add(this.uxConditionLabel);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxBookIDBox);
            this.Controls.Add(this.uxBookIDLabel);
            this.Name = "UpdateConditionForm";
            this.Text = "UpdateConditionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.TextBox uxBookIDBox;
        private System.Windows.Forms.Label uxBookIDLabel;
        private System.Windows.Forms.Label uxConditionLabel;
        private System.Windows.Forms.ComboBox uxConditionBox;
        private System.Windows.Forms.Button uxUpdateButton;
    }
}