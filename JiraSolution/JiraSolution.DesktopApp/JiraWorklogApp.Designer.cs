using System.Windows.Forms;

namespace JiraSolution.DesktopApp
{
	partial class JiraWorklogApp
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
			this.ButtonUsers = new System.Windows.Forms.Button();
			this.TextBoxUsername = new System.Windows.Forms.TextBox();
			this.TextBoxPassword = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.TextBoxProject = new System.Windows.Forms.TextBox();
			this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.programBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.programBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridIssuesOrWorklog = new System.Windows.Forms.DataGridView();
			this.TextUser = new System.Windows.Forms.TextBox();
			this.TextBoxUser = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridIssuesOrWorklog)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonUsers
			// 
			this.ButtonUsers.Location = new System.Drawing.Point(436, 33);
			this.ButtonUsers.Name = "ButtonUsers";
			this.ButtonUsers.Size = new System.Drawing.Size(107, 39);
			this.ButtonUsers.TabIndex = 0;
			this.ButtonUsers.Text = "Get Users";
			this.ButtonUsers.UseVisualStyleBackColor = true;
			this.ButtonUsers.Click += new System.EventHandler(this.ButtonUsers_Click);
			// 
			// TextBoxUsername
			// 
			this.TextBoxUsername.Location = new System.Drawing.Point(30, 44);
			this.TextBoxUsername.Name = "TextBoxUsername";
			this.TextBoxUsername.Size = new System.Drawing.Size(140, 20);
			this.TextBoxUsername.TabIndex = 1;
			this.TextBoxUsername.TextChanged += new System.EventHandler(this.TextBoxUsername_TextChanged);
			// 
			// TextBoxPassword
			// 
			this.TextBoxPassword.Location = new System.Drawing.Point(224, 43);
			this.TextBoxPassword.Name = "TextBoxPassword";
			this.TextBoxPassword.PasswordChar = '*';
			this.TextBoxPassword.Size = new System.Drawing.Size(140, 20);
			this.TextBoxPassword.TabIndex = 2;
			this.TextBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.Control;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Location = new System.Drawing.Point(30, 25);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(140, 13);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "Atlassian Username:";
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(224, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(140, 13);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "Atlassian Password:";
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.SystemColors.Control;
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Location = new System.Drawing.Point(30, 80);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(140, 13);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "Project:";
			// 
			// TextBoxProject
			// 
			this.TextBoxProject.Location = new System.Drawing.Point(30, 99);
			this.TextBoxProject.Name = "TextBoxProject";
			this.TextBoxProject.Size = new System.Drawing.Size(140, 20);
			this.TextBoxProject.TabIndex = 6;
			this.TextBoxProject.TextChanged += new System.EventHandler(this.TextBoxProject_TextChanged);
			// 
			// programBindingSource
			// 
			this.programBindingSource.DataSource = typeof(JiraSolution.DesktopApp.Program);
			// 
			// programBindingSource2
			// 
			this.programBindingSource2.DataSource = typeof(JiraSolution.DesktopApp.Program);
			// 
			// dataGridIssuesOrWorklog
			// 
			this.dataGridIssuesOrWorklog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridIssuesOrWorklog.Location = new System.Drawing.Point(30, 187);
			this.dataGridIssuesOrWorklog.Name = "dataGridIssuesOrWorklog";
			this.dataGridIssuesOrWorklog.Size = new System.Drawing.Size(513, 180);
			this.dataGridIssuesOrWorklog.TabIndex = 11;
			// 
			// TextUser
			// 
			this.TextUser.BackColor = System.Drawing.SystemColors.Control;
			this.TextUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TextUser.Location = new System.Drawing.Point(224, 80);
			this.TextUser.Name = "TextUser";
			this.TextUser.Size = new System.Drawing.Size(140, 13);
			this.TextUser.TabIndex = 13;
			this.TextUser.Text = "User: (optional)";
			// 
			// TextBoxUser
			// 
			this.TextBoxUser.Location = new System.Drawing.Point(224, 99);
			this.TextBoxUser.Name = "TextBoxUser";
			this.TextBoxUser.Size = new System.Drawing.Size(140, 20);
			this.TextBoxUser.TabIndex = 12;
			this.TextBoxUser.TextChanged += new System.EventHandler(this.TextBoxUser_TextChanged);
			// 
			// JiraWorklogApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 450);
			this.Controls.Add(this.TextUser);
			this.Controls.Add(this.TextBoxUser);
			this.Controls.Add(this.dataGridIssuesOrWorklog);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.TextBoxProject);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.TextBoxPassword);
			this.Controls.Add(this.TextBoxUsername);
			this.Controls.Add(this.ButtonUsers);
			this.Name = "JiraWorklogApp";
			this.Text = "Jira Worklog App";
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridIssuesOrWorklog)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ButtonUsers;
		private System.Windows.Forms.TextBox TextBoxUsername;
		private System.Windows.Forms.TextBox TextBoxPassword;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox TextBoxProject;
		private System.Windows.Forms.BindingSource programBindingSource;
		private System.Windows.Forms.BindingSource programBindingSource1;
		private System.Windows.Forms.BindingSource projectBindingSource;
		private BindingSource programBindingSource2;
		private DataGridView dataGridIssuesOrWorklog;
		private TextBox TextUser;
		private TextBox TextBoxUser;
	}
}

