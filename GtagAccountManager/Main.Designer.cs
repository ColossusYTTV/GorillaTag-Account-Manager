namespace GtagAccountManager
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ListInfo = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.account_list = new System.Windows.Forms.ListView();
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastChecked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(538, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.export_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.button2.Location = new System.Drawing.Point(458, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.import_Click);
            // 
            // ListInfo
            // 
            this.ListInfo.AutoSize = true;
            this.ListInfo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListInfo.Location = new System.Drawing.Point(12, 286);
            this.ListInfo.Name = "ListInfo";
            this.ListInfo.Size = new System.Drawing.Size(244, 17);
            this.ListInfo.TabIndex = 3;
            this.ListInfo.Text = "Unbanned: 0  Banned: 0  Not Checked: 0";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Default;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(619, 277);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 32);
            this.button5.TabIndex = 6;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.add_click);
            // 
            // account_list
            // 
            this.account_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.account_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Username,
            this.Password,
            this.Status,
            this.LastChecked});
            this.account_list.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.account_list.ForeColor = System.Drawing.Color.White;
            this.account_list.HideSelection = false;
            this.account_list.Location = new System.Drawing.Point(15, 13);
            this.account_list.Name = "account_list";
            this.account_list.Size = new System.Drawing.Size(679, 258);
            this.account_list.TabIndex = 7;
            this.account_list.UseCompatibleStateImageBehavior = false;
            this.account_list.MouseDown += new System.Windows.Forms.MouseEventHandler(this.account_list_MouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(133, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyUsernameAndPasswordToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(706, 313);
            this.Controls.Add(this.account_list);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ListInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Gtag Account Manager | By ColossusYTTV";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ListInfo;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListView account_list;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader LastChecked;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}

