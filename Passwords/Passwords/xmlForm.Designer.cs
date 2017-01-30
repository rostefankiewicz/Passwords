namespace Passwords
{
    partial class xmlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmlForm));
            this.acctLabel = new System.Windows.Forms.Label();
            this.acctCB = new System.Windows.Forms.ComboBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.addAcctButton = new System.Windows.Forms.Button();
            this.editAcctButton = new System.Windows.Forms.Button();
            this.removeAcctButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // acctLabel
            // 
            this.acctLabel.AutoSize = true;
            this.acctLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acctLabel.Location = new System.Drawing.Point(12, 9);
            this.acctLabel.Name = "acctLabel";
            this.acctLabel.Size = new System.Drawing.Size(77, 20);
            this.acctLabel.TabIndex = 0;
            this.acctLabel.Text = "Account";
            // 
            // acctCB
            // 
            this.acctCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acctCB.FormattingEnabled = true;
            this.acctCB.Location = new System.Drawing.Point(13, 37);
            this.acctCB.Name = "acctCB";
            this.acctCB.Size = new System.Drawing.Size(257, 28);
            this.acctCB.TabIndex = 1;
            this.acctCB.SelectedIndexChanged += new System.EventHandler(this.acctCB_SelectedIndexChanged);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(12, 68);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(103, 20);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "User Name";
            // 
            // UserNameTB
            // 
            this.UserNameTB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTB.Location = new System.Drawing.Point(12, 91);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.ReadOnly = true;
            this.UserNameTB.Size = new System.Drawing.Size(258, 26);
            this.UserNameTB.TabIndex = 3;
            // 
            // passwordTB
            // 
            this.passwordTB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passwordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTB.Location = new System.Drawing.Point(12, 143);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.ReadOnly = true;
            this.passwordTB.Size = new System.Drawing.Size(258, 26);
            this.passwordTB.TabIndex = 5;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(12, 120);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(91, 20);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // addAcctButton
            // 
            this.addAcctButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAcctButton.Location = new System.Drawing.Point(12, 176);
            this.addAcctButton.Name = "addAcctButton";
            this.addAcctButton.Size = new System.Drawing.Size(126, 36);
            this.addAcctButton.TabIndex = 6;
            this.addAcctButton.Text = "ADD";
            this.addAcctButton.UseVisualStyleBackColor = true;
            this.addAcctButton.Click += new System.EventHandler(this.addAcctButton_Click);
            // 
            // editAcctButton
            // 
            this.editAcctButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAcctButton.Location = new System.Drawing.Point(145, 176);
            this.editAcctButton.Name = "editAcctButton";
            this.editAcctButton.Size = new System.Drawing.Size(125, 36);
            this.editAcctButton.TabIndex = 7;
            this.editAcctButton.Text = "EDIT";
            this.editAcctButton.UseVisualStyleBackColor = true;
            this.editAcctButton.Click += new System.EventHandler(this.editAcctButton_Click);
            // 
            // removeAcctButton
            // 
            this.removeAcctButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAcctButton.Location = new System.Drawing.Point(145, 217);
            this.removeAcctButton.Name = "removeAcctButton";
            this.removeAcctButton.Size = new System.Drawing.Size(125, 36);
            this.removeAcctButton.TabIndex = 8;
            this.removeAcctButton.Text = "REMOVE";
            this.removeAcctButton.UseVisualStyleBackColor = true;
            this.removeAcctButton.Click += new System.EventHandler(this.removeAcctButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(12, 217);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(125, 36);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // xmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 265);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.removeAcctButton);
            this.Controls.Add(this.editAcctButton);
            this.Controls.Add(this.addAcctButton);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.UserNameTB);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.acctCB);
            this.Controls.Add(this.acctLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "xmlForm";
            this.Text = "Account Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label acctLabel;
        private System.Windows.Forms.ComboBox acctCB;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button addAcctButton;
        private System.Windows.Forms.Button editAcctButton;
        private System.Windows.Forms.Button removeAcctButton;
        private System.Windows.Forms.Button saveButton;
    }
}