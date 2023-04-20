

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace DESX
{
    public partial class UI : Form
    {
        private byte[] source;
        private byte[] destination;
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
                source = File.ReadAllBytes(WczytajDoKodowania.FileName);
            }
        }
        
        private void ReadToDecode_Click(object sender, EventArgs e)
        {
            if (WczytajDoDekodowania.ShowDialog() == DialogResult.OK)
            {
                source = File.ReadAllBytes(WczytajDoDekodowania.FileName);
            }
        }

        private void ReadKey_Click(object sender, EventArgs e)
        {
            if (WczytajKlucz.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(WczytajKlucz.FileName);
                    string text = Encoding.UTF8.GetString(bytes);
                    SetText(text.Substring(1,8), Key1);
                    SetText(text.Substring(8, 8), Key2);
                    SetText(text.Substring(16,8), Key3);
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
            if (ZapiszDoKodowania.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(ZapiszDoKodowania.FileName, destination);
                Array.Clear(source,0,source.Length);
                Array.Clear(destination, 0, destination.Length);
                Odkodowany.Text = "";
            }
           
        }

        private void SaveToDecode_Click(object sender, EventArgs e)
        {
            if (ZapiszDoDekodowania.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(ZapiszDoDekodowania.FileName, destination);
                Array.Clear(source, 0, source.Length);
                Array.Clear(destination, 0, destination.Length);
               Zakodowany.Text = "";
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
                            StringBuilder keysB = new StringBuilder();
                            keysB.Append(Key1.Text);
                            keysB.Append(Key2.Text);
                            keysB.Append(Key3.Text);
                            bw.Write(keysB.ToString());
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
            destination = desx.encrypt(source, key1, key2, key3, false);
            Zakodowany.Text = "Zakodowano plik. Zapisz go!";

        }         

        private void DecodeIt_Click(object sender, EventArgs e)
        {
            DESX desx = new DESX();
            String key1 = Key1.Text;
            String key2 = Key2.Text;
            String key3 = Key3.Text;
            destination = desx.encrypt(source, key1, key2, key3, true);
            Odkodowany.Text = "Odkodowano plik. Zapisz go!";

        }

    }
    }

