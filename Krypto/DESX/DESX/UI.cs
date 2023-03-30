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
            Generated.Checked = true;
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

        private void SaveToCode_Click(object sender, EventArgs e)
        {
            ZapiszDoKodowania.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ZapiszDoKodowania.ShowDialog() ==DialogResult.OK)
            {
                try
                {
                    using (StreamWriter filewrite = new StreamWriter(ZapiszDoKodowania.FileName))
                    {
                        filewrite.WriteLine(TextToCode.Text);
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
            ZapiszDoDekodowania.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ZapiszDoDekodowania.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter filewrite = new StreamWriter(ZapiszDoDekodowania.FileName))
                    {
                        filewrite.WriteLine(TextToDecode.Text);
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

