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
			this.panel1 = new System.Windows.Forms.Panel();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.TextBoxURL = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridIssuesOrWorklog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Button
			// 
			this.Button.BackColor = System.Drawing.Color.Lime;
			this.Button.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Button.Location = new System.Drawing.Point(381, 10);
			this.Button.Name = "Button";
			this.Button.Size = new System.Drawing.Size(129, 120);
			this.Button.TabIndex = 0;
			this.Button.Text = "Get Data";
			this.Button.UseVisualStyleBackColor = false;
			this.Button.Click += new System.EventHandler(this.Button_Click);
			// 
			// TextBoxUsername
			// 
			this.TextBoxUsername.Location = new System.Drawing.Point(6, 55);
			this.TextBoxUsername.Name = "TextBoxUsername";
			this.TextBoxUsername.Size = new System.Drawing.Size(140, 20);
			this.TextBoxUsername.TabIndex = 1;
			this.TextBoxUsername.TextChanged += new System.EventHandler(this.TextBoxUsername_TextChanged);
			// 
			// TextBoxPassword
			// 
			this.TextBoxPassword.Location = new System.Drawing.Point(191, 54);
			this.TextBoxPassword.Name = "TextBoxPassword";
			this.TextBoxPassword.PasswordChar = '*';
			this.TextBoxPassword.Size = new System.Drawing.Size(140, 20);
			this.TextBoxPassword.TabIndex = 2;
			this.TextBoxPassword.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
			// 
			// TextBoxProject
			// 
			this.TextBoxProject.Location = new System.Drawing.Point(6, 110);
			this.TextBoxProject.Name = "TextBoxProject";
			this.TextBoxProject.Size = new System.Drawing.Size(140, 20);
			this.TextBoxProject.TabIndex = 6;
			this.TextBoxProject.TextChanged += new System.EventHandler(this.TextBoxProject_TextChanged);
			// 
			// dataGridIssuesOrWorklog
			// 
			this.dataGridIssuesOrWorklog.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dataGridIssuesOrWorklog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridIssuesOrWorklog.Location = new System.Drawing.Point(14, 209);
			this.dataGridIssuesOrWorklog.Name = "dataGridIssuesOrWorklog";
			this.dataGridIssuesOrWorklog.Size = new System.Drawing.Size(513, 180);
			this.dataGridIssuesOrWorklog.TabIndex = 11;
			// 
			// TextBoxUser
			// 
			this.TextBoxUser.Location = new System.Drawing.Point(191, 110);
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
			this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.progressBar1.Location = new System.Drawing.Point(14, 395);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(513, 23);
			this.progressBar1.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Atlassian Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(188, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Atlassian Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Project:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(188, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "User (optional):";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(188, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "End Date:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Start Date";
			// 
			// StartDatePicker
			// 
			this.StartDatePicker.Location = new System.Drawing.Point(6, 160);
			this.StartDatePicker.Name = "StartDatePicker";
			this.StartDatePicker.Size = new System.Drawing.Size(156, 20);
			this.StartDatePicker.TabIndex = 23;
			this.StartDatePicker.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
			this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
			// 
			// EndDatePicker
			// 
			this.EndDatePicker.Location = new System.Drawing.Point(191, 160);
			this.EndDatePicker.Name = "EndDatePicker";
			this.EndDatePicker.Size = new System.Drawing.Size(156, 20);
			this.EndDatePicker.TabIndex = 24;
			this.EndDatePicker.Value = new System.DateTime(2018, 7, 31, 0, 0, 0, 0);
			this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.TextBoxURL);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.ButtonCancel);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.EndDatePicker);
			this.panel1.Controls.Add(this.TextBoxUsername);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.StartDatePicker);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.TextBoxProject);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.TextBoxUser);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.Button);
			this.panel1.Controls.Add(this.TextBoxPassword);
			this.panel1.Location = new System.Drawing.Point(14, 13);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(513, 190);
			this.panel1.TabIndex = 25;
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.BackColor = System.Drawing.Color.Red;
			this.ButtonCancel.Location = new System.Drawing.Point(381, 137);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(129, 43);
			this.ButtonCancel.TabIndex = 25;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = false;
			this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "ATLASSIAN URL: ";
			// 
			// TextBoxURL
			// 
			this.TextBoxURL.Location = new System.Drawing.Point(106, 7);
			this.TextBoxURL.Name = "TextBoxURL";
			this.TextBoxURL.Size = new System.Drawing.Size(225, 20);
			this.TextBoxURL.TabIndex = 27;
			this.TextBoxURL.Text = "glinttdev.atlassian.net";
			this.TextBoxURL.TextChanged += new System.EventHandler(this.TextBoxURL_TextChanged);
			// 
			// panel2
			// 
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Controls.Add(this.dataGridIssuesOrWorklog);
			this.panel2.Controls.Add(this.progressBar1);
			this.panel2.Location = new System.Drawing.Point(17, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(532, 430);
			this.panel2.TabIndex = 26;
			// 
			// JiraWorklogApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(561, 460);
			this.Controls.Add(this.panel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "JiraWorklogApp";
			this.Text = "Jira Worklog App";
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridIssuesOrWorklog)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.programBindingSource2)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

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
		private Panel panel1;
		private Button ButtonCancel;
		private TextBox TextBoxURL;
		private Label label7;
		private Panel panel2;
	}
}

