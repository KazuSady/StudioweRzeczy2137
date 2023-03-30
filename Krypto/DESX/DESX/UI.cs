using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESX
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void UI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Key1.Text = "1";
            Key2.Text = "2";
            Key3.Text = "3";
        }

        private void SetText(string text, TextBox TextPlace)
        {
            TextPlace.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WczytajDoKodowania.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(WczytajDoKodowania.FileName);
                    SetText(sr.ReadToEnd(), TextToCode);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void ReadToDecode_Click(object sender, EventArgs e)
        {
            if (WczytajDoDekodowania.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(WczytajDoDekodowania.FileName);
                    SetText(sr.ReadToEnd(), TextToDecode);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void ReadKey_Click(object sender, EventArgs e)
        {
            if (WczytajKlucz.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(WczytajKlucz.FileName);
                    SetText(sr.ReadLine(), Key1);
                    SetText(sr.ReadLine(), Key2);
                    SetText(sr.ReadLine(), Key3);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void SaveToCode_Click(object sender, EventArgs e)
        {
            if (ZapiszDoKodowania.ShowDialog() ==DialogResult.OK)
            {
                try
                {
                    using (FileStream filewrite = new FileStream(ZapiszDoKodowania.FileName, FileMode.CreateNew))
                    {
                        using (BinaryWriter bw = new BinaryWriter(filewrite))
                        {
                            bw.Write(TextToCode.Text);
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
           
        }

        private void SaveToDecode_Click(object sender, EventArgs e)
        {
            if (ZapiszDoDekodowania.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream filewrite = new FileStream(ZapiszDoDekodowania.FileName, FileMode.CreateNew))
                    {
                        using (BinaryWriter bw = new BinaryWriter(filewrite))
                        {
                            bw.Write(TextToDecode.Text);
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void WriteKey_Click(object sender, EventArgs e)
        {
            if (ZapiszKlucz.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream filewrite = new FileStream(ZapiszKlucz.FileName, FileMode.CreateNew))
                    {
                        using (BinaryWriter bw = new BinaryWriter(filewrite))
                        {
                            bw.Write(Key1.Text);
                            bw.Write(Key2.Text);
                            bw.Write(Key3.Text);
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
    }

