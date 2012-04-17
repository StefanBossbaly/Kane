using System.IO.Ports;
namespace project
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.connectButton = new System.Windows.Forms.Button();
			this.connectLabel = new System.Windows.Forms.Label();
			this.portsBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(12, 61);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(260, 23);
			this.connectButton.TabIndex = 0;
			this.connectButton.Text = "Connect";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
			// 
			// connectLabel
			// 
			this.connectLabel.Location = new System.Drawing.Point(12, 9);
			this.connectLabel.Name = "connectLabel";
			this.connectLabel.Size = new System.Drawing.Size(260, 23);
			this.connectLabel.TabIndex = 2;
			this.connectLabel.Text = "Please enter the COM port which the Ardurino is connected to";
			// 
			// portsBox
			// 
			this.portsBox.FormattingEnabled = true;
			this.portsBox.Location = new System.Drawing.Point(12, 34);
			this.portsBox.Name = "portsBox";
			this.portsBox.Size = new System.Drawing.Size(260, 21);
			this.portsBox.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 93);
			this.Controls.Add(this.portsBox);
			this.Controls.Add(this.connectLabel);
			this.Controls.Add(this.connectButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Stefan\'s Project";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox portsBox;
		private System.Windows.Forms.Label connectLabel;
		private System.Windows.Forms.Button connectButton;
		
		public void ConnectButtonClick(object sender, System.EventArgs e)
		{
			if (portsBox.SelectedItem == null)
				return;
			DisplayForm form = new DisplayForm((string)portsBox.SelectedItem);
			form.ShowDialog();
			form.Close();
		}
	}
}
