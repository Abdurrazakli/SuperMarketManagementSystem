namespace demoMarketManagementSystem
{
    partial class AdminPage
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.comboBoxUserRole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreateNewUser = new System.Windows.Forms.Button();
            this.btnUpdateSelectedUser = new System.Windows.Forms.Button();
            this.btnDeleteSelectedUser = new System.Windows.Forms.Button();
            this.btnResetUserPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(85, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(85, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(85, 51);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(85, 20);
            this.textBoxSurname.TabIndex = 1;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(272, 10);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(121, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // comboBoxUserRole
            // 
            this.comboBoxUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserRole.FormattingEnabled = true;
            this.comboBoxUserRole.Items.AddRange(new object[] {
            "admin",
            "cashier",
            "dataman"});
            this.comboBoxUserRole.Location = new System.Drawing.Point(272, 47);
            this.comboBoxUserRole.Name = "comboBoxUserRole";
            this.comboBoxUserRole.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUserRole.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Surname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(187, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(187, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "User role";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(703, 234);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellLeave);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(318, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateNewUser
            // 
            this.btnCreateNewUser.Location = new System.Drawing.Point(434, 10);
            this.btnCreateNewUser.Name = "btnCreateNewUser";
            this.btnCreateNewUser.Size = new System.Drawing.Size(122, 23);
            this.btnCreateNewUser.TabIndex = 10;
            this.btnCreateNewUser.Text = "Create a new user";
            this.btnCreateNewUser.UseVisualStyleBackColor = true;
            this.btnCreateNewUser.Click += new System.EventHandler(this.btnCreateNewUser_Click);
            // 
            // btnUpdateSelectedUser
            // 
            this.btnUpdateSelectedUser.Location = new System.Drawing.Point(434, 39);
            this.btnUpdateSelectedUser.Name = "btnUpdateSelectedUser";
            this.btnUpdateSelectedUser.Size = new System.Drawing.Size(122, 23);
            this.btnUpdateSelectedUser.TabIndex = 11;
            this.btnUpdateSelectedUser.Text = "Update selected user";
            this.btnUpdateSelectedUser.UseVisualStyleBackColor = true;
            this.btnUpdateSelectedUser.Click += new System.EventHandler(this.btnUpdateSelectedUser_Click);
            // 
            // btnDeleteSelectedUser
            // 
            this.btnDeleteSelectedUser.Location = new System.Drawing.Point(434, 69);
            this.btnDeleteSelectedUser.Name = "btnDeleteSelectedUser";
            this.btnDeleteSelectedUser.Size = new System.Drawing.Size(122, 23);
            this.btnDeleteSelectedUser.TabIndex = 12;
            this.btnDeleteSelectedUser.Text = "Delete selected user";
            this.btnDeleteSelectedUser.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedUser.Click += new System.EventHandler(this.btnDeleteSelectedUser_Click);
            // 
            // btnResetUserPassword
            // 
            this.btnResetUserPassword.Location = new System.Drawing.Point(562, 10);
            this.btnResetUserPassword.Name = "btnResetUserPassword";
            this.btnResetUserPassword.Size = new System.Drawing.Size(129, 23);
            this.btnResetUserPassword.TabIndex = 13;
            this.btnResetUserPassword.Text = "Reset user\'s password";
            this.btnResetUserPassword.UseVisualStyleBackColor = true;
            this.btnResetUserPassword.Click += new System.EventHandler(this.BtnResetUserPassword_Click);
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(44)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(727, 359);
            this.Controls.Add(this.btnResetUserPassword);
            this.Controls.Add(this.btnDeleteSelectedUser);
            this.Controls.Add(this.btnUpdateSelectedUser);
            this.Controls.Add(this.btnCreateNewUser);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxUserRole);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Name = "AdminPage";
            this.Text = "AdminPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPage_FormClosed);
            this.Click += new System.EventHandler(this.AdminPage_Click);
            this.DoubleClick += new System.EventHandler(this.AdminPage_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.ComboBox comboBoxUserRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCreateNewUser;
        private System.Windows.Forms.Button btnUpdateSelectedUser;
        private System.Windows.Forms.Button btnDeleteSelectedUser;
        private System.Windows.Forms.Button btnResetUserPassword;
    }
}