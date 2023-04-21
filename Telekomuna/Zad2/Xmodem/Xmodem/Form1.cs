using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xmodem
{
    public partial class Xmodem : Form
    {
        Sender sen;
        Receiver rec;
        public Xmodem()
        {
            InitializeComponent();
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            String COM = WyborCOM.Text;
            if (Sender.Checked)
            {
                sen = new Sender(WyborCOM.Text);
                if (Wczytaj.ShowDialog() == DialogResult.OK)
                {
                    byte[] received = new byte[1];
                    sen.port.Read(received, 0, 1);
                    if (received[0] == 0x15 || received[0] == 0x43)
                    {
                        Trace.WriteLine("NAK received");
                        try
                        {
                            if (BaseOpt.Checked) sen.Read(Wczytaj.FileName, "1");
                            else sen.Read(Wczytaj.FileName, "2");
                            Status.Text = "Plik wysłany";
                        }
                        catch (SecurityException ex)
                        {
                            MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                            $"Details:\n\n{ex.StackTrace}");
                        }
                    }
                    else Trace.WriteLine("NAK not received " + received[0]);
                }
                
            }
            else
            {
                rec = new Receiver(WyborCOM.Text);
                if(BaseOpt.Checked) rec.Listening("1");
                else rec.Listening("2");
                Status.Text = "Plik odebrany";
            }
        }
        private void CheckCOMs_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            foreach (string s in SerialPort.GetPortNames())
            {
                result.Append(s+"; ");
            }
            Dostepne.Text = result.ToString();
        }
 
    }
}
