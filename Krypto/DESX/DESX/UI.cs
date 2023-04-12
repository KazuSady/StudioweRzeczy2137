
using PdfSharp.Pdf.IO;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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
            DESX desx = new DESX();
            List<String> keys = desx.generateKeys();
            Key1.Text = keys.ElementAt(0);
            Key2.Text = keys.ElementAt(1);
            Key3.Text = keys.ElementAt(2);
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
                    byte[] bytes = File.ReadAllBytes(WczytajDoKodowania.FileName);
                    string text = Encoding.UTF8.GetString(bytes);
                    SetText(text, TextToCode);
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
                    byte[] bytes = File.ReadAllBytes(WczytajDoDekodowania.FileName);
                    string text = Encoding.UTF8.GetString(bytes);
                    SetText(text, TextToDecode);
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
                        byte[] textBytes = Encoding.UTF8.GetBytes(TextToCode.Text);
                        using (BinaryWriter bw = new BinaryWriter(filewrite))
                        {
                            bw.Write(textBytes);
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
                        byte[] textBytes = Encoding.UTF8.GetBytes(TextToDecode.Text);
                        using (BinaryWriter bw = new BinaryWriter(filewrite))
                        {
                            bw.Write(textBytes);
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

        private void CodeIt_Click(object sender, EventArgs e)
        {

            DESX desx = new DESX();
            String key1 = Key1.Text;
            String key2 = Key2.Text;
            String key3 = Key3.Text;
            char[] text = TextToCode.Text.ToCharArray();

            TextToDecode.Text = desx.encrypt(text, key1, key2, key3, false);
        }

        private void DecodeIt_Click(object sender, EventArgs e)
        {
            DESX desx = new DESX();
            String key1 = Key1.Text;
            String key2 = Key2.Text;
            String key3 = Key3.Text;
            char[] text = TextToDecode.Text.ToCharArray();

            TextToCode.Text = desx.encrypt(text, key1, key2, key3, true);
        }
    }
    }

