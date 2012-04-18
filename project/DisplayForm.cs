using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Resources;

namespace project
{
	public partial class DisplayForm : Form
	{
		private Thread readThread;
		private SerialPort port;
		private bool running;
		
		public DisplayForm(String portName)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//Init the port
			if (!portName.Equals("None"))
			{
				port = new SerialPort(portName);
				port.ReadTimeout = 100;
				port.Open();
				
				//Start the read thread
				readThread = new Thread(Read);
				running = true;
				readThread.Start();
			}
			
			//Default Image to start with
			pictureBox.Image = Image.FromFile("C:\\Images\\evil_lair.png");
		}
		
		public void Read()
		{
			while (running)
			{
				try
				{
					int number = port.ReadByte();
					switch (number)
					{
						case 48:
							pictureBox.Image = Image.FromFile("C:\\Images\\evil_lair.png");
							break;
						case 49:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor1.jpg");
							break;
						case 50:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor2.jpg");
							break;
						case 51:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor1.jpg");
							break;
						case 52:
							pictureBox.Image = Image.FromFile("C:\\Images\\depth_charge.jpg");
							break;
						case 53:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor2.jpg");
							break;
						default:
							break;
					}
				}
				catch (TimeoutException)
				{
					//NBD, no data to read
				}
			}
		}
		
		void DisplayFormFormClosing(object sender, FormClosingEventArgs e)
		{
			running = false;
			if (readThread != null && !readThread.Join(1000))
				readThread.Abort();
			
			if (port != null)
    			port.Close(); 
		}
	}
}
