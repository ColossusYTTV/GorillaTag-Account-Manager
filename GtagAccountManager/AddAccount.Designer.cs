namespace GtagAccountManager
{
    partial class AddAccount
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
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.statuscomboBox = new System.Windows.Forms.ComboBox();
            this.BanTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.Gray;
            this.Username.Location = new System.Drawing.Point(10, 13);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(216, 25);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username";
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.Gray;
            this.Password.Location = new System.Drawing.Point(10, 42);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(216, 25);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password";
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Add.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(158, 107);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(66, 24);
            this.Add.TabIndex = 4;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // statuscomboBox
            // 
            this.statuscomboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.statuscomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statuscomboBox.ForeColor = System.Drawing.Color.White;
            this.statuscomboBox.FormattingEnabled = true;
            this.statuscomboBox.Location = new System.Drawing.Point(12, 74);
            this.statuscomboBox.Name = "statuscomboBox";
            this.statuscomboBox.Size = new System.Drawing.Size(212, 25);
            this.statuscomboBox.TabIndex = 6;
            // 
            // BanTime
            // 
            this.BanTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BanTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BanTime.ForeColor = System.Drawing.Color.Gray;
            this.BanTime.Location = new System.Drawing.Point(13, 106);
            this.BanTime.Name = "BanTime";
            this.BanTime.Size = new System.Drawing.Size(139, 25);
            this.BanTime.TabIndex = 7;
            this.BanTime.Text = "Hours";
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(236, 141);
            this.Controls.Add(this.BanTime);
            this.Controls.Add(this.statuscomboBox);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddAccount";
            this.Text = "AddAcount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ComboBox statuscomboBox;
        private System.Windows.Forms.TextBox BanTime;
    }
}