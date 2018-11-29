namespace ClientApplication
{
    partial class ResetPasswordForm
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
            this.uxPasswordLabel = new System.Windows.Forms.Label();
            this.uxEmailLabel = new System.Windows.Forms.Label();
            this.uxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.uxEmailTextbox = new System.Windows.Forms.TextBox();
            this.uxUpdateButton = new System.Windows.Forms.Button();
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxPasswordLabel
            // 
            this.uxPasswordLabel.AutoSize = true;
            this.uxPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPasswordLabel.Location = new System.Drawing.Point(16, 50);
            this.uxPasswordLabel.Name = "uxPasswordLabel";
            this.uxPasswordLabel.Size = new System.Drawing.Size(81, 13);
            this.uxPasswordLabel.TabIndex = 8;
            this.uxPasswordLabel.Text = "New Password:";
            // 
            // uxEmailLabel
            // 
            this.uxEmailLabel.AutoSize = true;
            this.uxEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxEmailLabel.Location = new System.Drawing.Point(21, 19);
            this.uxEmailLabel.Name = "uxEmailLabel";
            this.uxEmailLabel.Size = new System.Drawing.Size(76, 13);
            this.uxEmailLabel.TabIndex = 7;
            this.uxEmailLabel.Text = "Patron\'s Email:";
            // 
            // uxPasswordTextbox
            // 
            this.uxPasswordTextbox.Location = new System.Drawing.Point(100, 47);
            this.uxPasswordTextbox.Name = "uxPasswordTextbox";
            this.uxPasswordTextbox.PasswordChar = '•';
            this.uxPasswordTextbox.Size = new System.Drawing.Size(204, 20);
            this.uxPasswordTextbox.TabIndex = 6;
            // 
            // uxEmailTextbox
            // 
            this.uxEmailTextbox.Location = new System.Drawing.Point(100, 16);
            this.uxEmailTextbox.Name = "uxEmailTextbox";
            this.uxEmailTextbox.Size = new System.Drawing.Size(204, 20);
            this.uxEmailTextbox.TabIndex = 5;
            // 
            // uxUpdateButton
            // 
            this.uxUpdateButton.Location = new System.Drawing.Point(99, 78);
            this.uxUpdateButton.Name = "uxUpdateButton";
            this.uxUpdateButton.Size = new System.Drawing.Size(205, 34);
            this.uxUpdateButton.TabIndex = 18;
            this.uxUpdateButton.Text = "Reset Patron\'s Password";
            this.uxUpdateButton.UseVisualStyleBackColor = true;
            this.uxUpdateButton.Click += new System.EventHandler(this.uxRetireButton_Click);
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(19, 78);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(74, 34);
            this.uxReturnButton.TabIndex = 17;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 133);
            this.Controls.Add(this.uxUpdateButton);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxPasswordLabel);
            this.Controls.Add(this.uxEmailLabel);
            this.Controls.Add(this.uxPasswordTextbox);
            this.Controls.Add(this.uxEmailTextbox);
            this.Name = "ResetPasswordForm";
            this.Text = "ResetPasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxPasswordLabel;
        private System.Windows.Forms.Label uxEmailLabel;
        private System.Windows.Forms.TextBox uxPasswordTextbox;
        private System.Windows.Forms.TextBox uxEmailTextbox;
        private System.Windows.Forms.Button uxUpdateButton;
        private System.Windows.Forms.Button uxReturnButton;
    }
}