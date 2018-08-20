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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JiraWorklogApp));
			this.Button = new System.Windows.Forms.Button();
			this.TextBoxUsername = new System.Windows.Forms.TextBox();
			this.TextBoxPassword = new System.Windows.Forms.TextBox();
			this.TextBoxProject = new System.Windows.Forms.TextBox();
			this.programBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridIssuesOrWorklog = new System.Windows.Forms.DataGridView();
			this.TextBoxUser = new System.Windows.Forms.TextBox();
			this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.programBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
			this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridIssuesOrWorklog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).BeginInit();
			this.SuspendLayout();
			// 
			// Button
			// 
			this.Button.Location = new System.Drawing.Point(414, 24);
			this.Button.Name = "Button";
			this.Button.Size = new System.Drawing.Size(129, 145);
			this.Button.TabIndex = 0;
			this.Button.Text = "Get Data";
			this.Button.UseVisualStyleBackColor = true;
			this.Button.Click += new System.EventHandler(this.Button_Click);
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
			// TextBoxProject
			// 
			this.TextBoxProject.Location = new System.Drawing.Point(30, 99);
			this.TextBoxProject.Name = "TextBoxProject";
			this.TextBoxProject.Size = new System.Drawing.Size(140, 20);
			this.TextBoxProject.TabIndex = 6;
			this.TextBoxProject.TextChanged += new System.EventHandler(this.TextBoxProject_TextChanged);
			// 
			// dataGridIssuesOrWorklog
			// 
			this.dataGridIssuesOrWorklog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridIssuesOrWorklog.Location = new System.Drawing.Point(30, 187);
			this.dataGridIssuesOrWorklog.Name = "dataGridIssuesOrWorklog";
			this.dataGridIssuesOrWorklog.Size = new System.Drawing.Size(513, 180);
			this.dataGridIssuesOrWorklog.TabIndex = 11;
			// 
			// TextBoxUser
			// 
			this.TextBoxUser.Location = new System.Drawing.Point(224, 99);
			this.TextBoxUser.Name = "TextBoxUser";
			this.TextBoxUser.Size = new System.Drawing.Size(140, 20);
			this.TextBoxUser.TabIndex = 12;
			this.TextBoxUser.TextChanged += new System.EventHandler(this.TextBoxUser_TextChanged);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(30, 392);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(513, 23);
			this.progressBar1.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Atlassian Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(221, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Atlassian Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Project:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(221, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "User (optional):";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(221, 133);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "End Date:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(27, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Start Date";
			// 
			// StartDatePicker
			// 
			this.StartDatePicker.Location = new System.Drawing.Point(30, 149);
			this.StartDatePicker.Name = "StartDatePicker";
			this.StartDatePicker.Size = new System.Drawing.Size(156, 20);
			this.StartDatePicker.TabIndex = 23;
			this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
			// 
			// EndDatePicker
			// 
			this.EndDatePicker.Location = new System.Drawing.Point(224, 149);
			this.EndDatePicker.Name = "EndDatePicker";
			this.EndDatePicker.Size = new System.Drawing.Size(156, 20);
			this.EndDatePicker.TabIndex = 24;
			this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
			// 
			// JiraWorklogApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 450);
			this.Controls.Add(this.EndDatePicker);
			this.Controls.Add(this.StartDatePicker);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.TextBoxUser);
			this.Controls.Add(this.dataGridIssuesOrWorklog);
			this.Controls.Add(this.TextBoxProject);
			this.Controls.Add(this.TextBoxPassword);
			this.Controls.Add(this.TextBoxUsername);
			this.Controls.Add(this.Button);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "JiraWorklogApp";
			this.Text = "Jira Worklog App";
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridIssuesOrWorklog)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Button;
		private System.Windows.Forms.TextBox TextBoxUsername;
		private System.Windows.Forms.TextBox TextBoxPassword;
		private System.Windows.Forms.TextBox TextBoxProject;
		private System.Windows.Forms.BindingSource programBindingSource;
		private System.Windows.Forms.BindingSource programBindingSource1;
		private System.Windows.Forms.BindingSource projectBindingSource;
		private BindingSource programBindingSource2;
		private DataGridView dataGridIssuesOrWorklog;
		private TextBox TextBoxUser;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private ProgressBar progressBar1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private DateTimePicker StartDatePicker;
		private DateTimePicker EndDatePicker;
	}
}

