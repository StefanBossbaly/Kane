using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

namespace project
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//Populate the port in the list
			string[] ports = SerialPort.GetPortNames();
			
			portsBox.Items.Add("None");
			
			foreach(string port in ports)
			{
				portsBox.Items.Add(port);
			}
		}
	}
}
