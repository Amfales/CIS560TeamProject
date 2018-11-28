namespace ClientApplication
{
    partial class LoginForm
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
            this.uxTitleLabel = new System.Windows.Forms.Label();
            this.uxEmailTextbox = new System.Windows.Forms.TextBox();
            this.uxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.uxEmailLabel = new System.Windows.Forms.Label();
            this.uxPasswordLabel = new System.Windows.Forms.Label();
            this.uxLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxTitleLabel
            // 
            this.uxTitleLabel.AutoSize = true;
            this.uxTitleLabel.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTitleLabel.Location = new System.Drawing.Point(39, 18);
            this.uxTitleLabel.Name = "uxTitleLabel";
            this.uxTitleLabel.Size = new System.Drawing.Size(274, 58);
            this.uxTitleLabel.TabIndex = 0;
            this.uxTitleLabel.Text = "Egg-Laying Full-Milk\r\n   Pig Libraries LLC.";
            // 
            // uxEmailTextbox
            // 
            this.uxEmailTextbox.Location = new System.Drawing.Point(83, 98);
            this.uxEmailTextbox.Name = "uxEmailTextbox";
            this.uxEmailTextbox.Size = new System.Drawing.Size(162, 20);
            this.uxEmailTextbox.TabIndex = 1;
            // 
            // uxPasswordTextbox
            // 
            this.uxPasswordTextbox.Location = new System.Drawing.Point(83, 129);
            this.uxPasswordTextbox.Name = "uxPasswordTextbox";
            this.uxPasswordTextbox.PasswordChar = '•';
            this.uxPasswordTextbox.Size = new System.Drawing.Size(162, 20);
            this.uxPasswordTextbox.TabIndex = 2;
            // 
            // uxEmailLabel
            // 
            this.uxEmailLabel.AutoSize = true;
            this.uxEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxEmailLabel.Location = new System.Drawing.Point(40, 99);
            this.uxEmailLabel.Name = "uxEmailLabel";
            this.uxEmailLabel.Size = new System.Drawing.Size(42, 15);
            this.uxEmailLabel.TabIndex = 3;
            this.uxEmailLabel.Text = "Email:";
            // 
            // uxPasswordLabel
            // 
            this.uxPasswordLabel.AutoSize = true;
            this.uxPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPasswordLabel.Location = new System.Drawing.Point(19, 131);
            this.uxPasswordLabel.Name = "uxPasswordLabel";
            this.uxPasswordLabel.Size = new System.Drawing.Size(64, 15);
            this.uxPasswordLabel.TabIndex = 4;
            this.uxPasswordLabel.Text = "Password:";
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Location = new System.Drawing.Point(256, 98);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(82, 51);
            this.uxLoginButton.TabIndex = 5;
            this.uxLoginButton.Text = "Login";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            this.uxLoginButton.Click += new System.EventHandler(this.uxLoginButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 174);
            this.Controls.Add(this.uxLoginButton);
            this.Controls.Add(this.uxPasswordLabel);
            this.Controls.Add(this.uxEmailLabel);
            this.Controls.Add(this.uxPasswordTextbox);
            this.Controls.Add(this.uxEmailTextbox);
            this.Controls.Add(this.uxTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxTitleLabel;
        private System.Windows.Forms.TextBox uxEmailTextbox;
        private System.Windows.Forms.TextBox uxPasswordTextbox;
        private System.Windows.Forms.Label uxEmailLabel;
        private System.Windows.Forms.Label uxPasswordLabel;
        private System.Windows.Forms.Button uxLoginButton;
    }
}

