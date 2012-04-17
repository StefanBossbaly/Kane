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
			port = new SerialPort(portName);
			port.ReadTimeout = 100;
			port.Open();
			
			//Start the read thread
			readThread = new Thread(Read);
			running = true;
			readThread.Start();
			
			//Default Image to start with
			pictureBox.Image = Image.FromFile("C:\\Images\\floor1.jpg");
		}
		
		public void Read()
		{
			while (running)
			{
				try
				{
					switch (port.ReadByte())
					{
						case 0:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor1.jpg");
							break;
						case 1:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor2.jpg");
							break;
						case 2:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor3.jpg");
							break;
						case 3:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor4.jpg");
							break;
						case 4:
							pictureBox.Image = Image.FromFile("C:\\Images\\floor2.jpg");
							break;
						case 5:
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
			if (! readThread.Join(1000))
				readThread.Abort();
    		port.Close(); 
		}
	}
}
