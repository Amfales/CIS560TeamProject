namespace ClientApplication
{
    partial class CreateAccountForm
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
            this.uxCreateButton = new System.Windows.Forms.Button();
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxPasswordLabel = new System.Windows.Forms.Label();
            this.uxEmailLabel = new System.Windows.Forms.Label();
            this.uxPasswordTextbox = new System.Windows.Forms.TextBox();
            this.uxEmailTextbox = new System.Windows.Forms.TextBox();
            this.uxLastNameLabel = new System.Windows.Forms.Label();
            this.uxFirstNameLabel = new System.Windows.Forms.Label();
            this.uxLastNameBox = new System.Windows.Forms.TextBox();
            this.uxFirstNameBox = new System.Windows.Forms.TextBox();
            this.uxTypeLabel = new System.Windows.Forms.Label();
            this.uxUserTypeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uxCreateButton
            // 
            this.uxCreateButton.Location = new System.Drawing.Point(116, 171);
            this.uxCreateButton.Name = "uxCreateButton";
            this.uxCreateButton.Size = new System.Drawing.Size(205, 34);
            this.uxCreateButton.TabIndex = 5;
            this.uxCreateButton.Text = "Create User Account";
            this.uxCreateButton.UseVisualStyleBackColor = true;
            this.uxCreateButton.Click += new System.EventHandler(this.uxUpdateButton_Click);
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(36, 171);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(74, 34);
            this.uxReturnButton.TabIndex = 6;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxPasswordLabel
            // 
            this.uxPasswordLabel.AutoSize = true;
            this.uxPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPasswordLabel.Location = new System.Drawing.Point(54, 106);
            this.uxPasswordLabel.Name = "uxPasswordLabel";
            this.uxPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.uxPasswordLabel.TabIndex = 22;
            this.uxPasswordLabel.Text = "Password:";
            // 
            // uxEmailLabel
            // 
            this.uxEmailLabel.AutoSize = true;
            this.uxEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxEmailLabel.Location = new System.Drawing.Point(43, 75);
            this.uxEmailLabel.Name = "uxEmailLabel";
            this.uxEmailLabel.Size = new System.Drawing.Size(67, 13);
            this.uxEmailLabel.TabIndex = 21;
            this.uxEmailLabel.Text = "User\'s Email:";
            // 
            // uxPasswordTextbox
            // 
            this.uxPasswordTextbox.Location = new System.Drawing.Point(117, 103);
            this.uxPasswordTextbox.Name = "uxPasswordTextbox";
            this.uxPasswordTextbox.PasswordChar = '•';
            this.uxPasswordTextbox.Size = new System.Drawing.Size(204, 20);
            this.uxPasswordTextbox.TabIndex = 3;
            // 
            // uxEmailTextbox
            // 
            this.uxEmailTextbox.Location = new System.Drawing.Point(117, 72);
            this.uxEmailTextbox.Name = "uxEmailTextbox";
            this.uxEmailTextbox.Size = new System.Drawing.Size(204, 20);
            this.uxEmailTextbox.TabIndex = 2;
            // 
            // uxLastNameLabel
            // 
            this.uxLastNameLabel.AutoSize = true;
            this.uxLastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLastNameLabel.Location = new System.Drawing.Point(49, 46);
            this.uxLastNameLabel.Name = "uxLastNameLabel";
            this.uxLastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.uxLastNameLabel.TabIndex = 28;
            this.uxLastNameLabel.Text = "Last Name:";
            // 
            // uxFirstNameLabel
            // 
            this.uxFirstNameLabel.AutoSize = true;
            this.uxFirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFirstNameLabel.Location = new System.Drawing.Point(51, 15);
            this.uxFirstNameLabel.Name = "uxFirstNameLabel";
            this.uxFirstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.uxFirstNameLabel.TabIndex = 27;
            this.uxFirstNameLabel.Text = "First Name:";
            // 
            // uxLastNameBox
            // 
            this.uxLastNameBox.Location = new System.Drawing.Point(117, 43);
            this.uxLastNameBox.Name = "uxLastNameBox";
            this.uxLastNameBox.Size = new System.Drawing.Size(204, 20);
            this.uxLastNameBox.TabIndex = 1;
            // 
            // uxFirstNameBox
            // 
            this.uxFirstNameBox.Location = new System.Drawing.Point(117, 12);
            this.uxFirstNameBox.Name = "uxFirstNameBox";
            this.uxFirstNameBox.Size = new System.Drawing.Size(204, 20);
            this.uxFirstNameBox.TabIndex = 0;
            // 
            // uxTypeLabel
            // 
            this.uxTypeLabel.AutoSize = true;
            this.uxTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxTypeLabel.Location = new System.Drawing.Point(50, 135);
            this.uxTypeLabel.Name = "uxTypeLabel";
            this.uxTypeLabel.Size = new System.Drawing.Size(59, 13);
            this.uxTypeLabel.TabIndex = 30;
            this.uxTypeLabel.Text = "User Type:";
            // 
            // uxUserTypeBox
            // 
            this.uxUserTypeBox.FormattingEnabled = true;
            this.uxUserTypeBox.Items.AddRange(new object[] {
            "Patron",
            "Admin"});
            this.uxUserTypeBox.Location = new System.Drawing.Point(116, 132);
            this.uxUserTypeBox.Name = "uxUserTypeBox";
            this.uxUserTypeBox.Size = new System.Drawing.Size(205, 21);
            this.uxUserTypeBox.TabIndex = 4;
            this.uxUserTypeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uxUserTypeBox_KeyDown);
            // 
            // CreateAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 220);
            this.Controls.Add(this.uxUserTypeBox);
            this.Controls.Add(this.uxTypeLabel);
            this.Controls.Add(this.uxLastNameLabel);
            this.Controls.Add(this.uxFirstNameLabel);
            this.Controls.Add(this.uxLastNameBox);
            this.Controls.Add(this.uxFirstNameBox);
            this.Controls.Add(this.uxCreateButton);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxPasswordLabel);
            this.Controls.Add(this.uxEmailLabel);
            this.Controls.Add(this.uxPasswordTextbox);
            this.Controls.Add(this.uxEmailTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create User Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxCreateButton;
        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.Label uxPasswordLabel;
        private System.Windows.Forms.Label uxEmailLabel;
        private System.Windows.Forms.TextBox uxPasswordTextbox;
        private System.Windows.Forms.TextBox uxEmailTextbox;
        private System.Windows.Forms.Label uxLastNameLabel;
        private System.Windows.Forms.Label uxFirstNameLabel;
        private System.Windows.Forms.TextBox uxLastNameBox;
        private System.Windows.Forms.TextBox uxFirstNameBox;
        private System.Windows.Forms.Label uxTypeLabel;
        private System.Windows.Forms.ComboBox uxUserTypeBox;
    }
}