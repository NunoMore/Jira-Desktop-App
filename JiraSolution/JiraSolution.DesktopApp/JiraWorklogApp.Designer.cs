using System.Windows.Forms;
using JiraSolution.DesktopApp.Domain;

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
			this.ButtonIssues = new System.Windows.Forms.Button();
			this.TextBoxUsername = new System.Windows.Forms.TextBox();
			this.TextBoxPassword = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.TextBoxProject = new System.Windows.Forms.TextBox();
			this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.programBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.TextBoxIssue = new System.Windows.Forms.TextBox();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.programBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.Issue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonIssues
			// 
			this.ButtonIssues.Location = new System.Drawing.Point(436, 33);
			this.ButtonIssues.Name = "ButtonIssues";
			this.ButtonIssues.Size = new System.Drawing.Size(107, 39);
			this.ButtonIssues.TabIndex = 0;
			this.ButtonIssues.Text = "Get Issues";
			this.ButtonIssues.UseVisualStyleBackColor = true;
			this.ButtonIssues.Click += new System.EventHandler(this.ButtonIssues_Click);
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
			this.TextBoxPassword.Size = new System.Drawing.Size(145, 20);
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
			// textBox4
			// 
			this.textBox4.BackColor = System.Drawing.SystemColors.Control;
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox4.Location = new System.Drawing.Point(224, 80);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(140, 13);
			this.textBox4.TabIndex = 9;
			this.textBox4.Text = "Issue:";
			// 
			// TextBoxIssue
			// 
			this.TextBoxIssue.Location = new System.Drawing.Point(224, 99);
			this.TextBoxIssue.Name = "TextBoxIssue";
			this.TextBoxIssue.Size = new System.Drawing.Size(140, 20);
			this.TextBoxIssue.TabIndex = 8;
			this.TextBoxIssue.TextChanged += new System.EventHandler(this.TextBoxIssue_TextChanged);
			// 
			// dataGrid
			// 
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Issue});
			this.dataGrid.Location = new System.Drawing.Point(30, 201);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.Size = new System.Drawing.Size(240, 150);
			this.dataGrid.TabIndex = 10;
			// 
			// programBindingSource2
			// 
			this.programBindingSource2.DataSource = typeof(JiraSolution.DesktopApp.Program);
			// 
			// Issue
			// 
			this.Issue.HeaderText = "Issue Name";
			this.Issue.Name = "Issue";
			this.Issue.ReadOnly = true;
			// 
			// JiraWorklogApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 450);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.TextBoxIssue);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.TextBoxProject);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.TextBoxPassword);
			this.Controls.Add(this.TextBoxUsername);
			this.Controls.Add(this.ButtonIssues);
			this.Name = "JiraWorklogApp";
			this.Text = "Jira Worklog App";
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ButtonIssues;
		private System.Windows.Forms.TextBox TextBoxUsername;
		private System.Windows.Forms.TextBox TextBoxPassword;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox TextBoxProject;
		private System.Windows.Forms.BindingSource programBindingSource;
		private System.Windows.Forms.BindingSource programBindingSource1;
		private System.Windows.Forms.BindingSource projectBindingSource;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox TextBoxIssue;
		private System.Windows.Forms.DataGridView dataGrid;
		private BindingSource programBindingSource2;
		private DataGridViewTextBoxColumn Issue;
	}
}

