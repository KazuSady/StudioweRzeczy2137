namespace DESX
{
    partial class UI
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.GenKey = new System.Windows.Forms.Button();
            this.ReadToCode = new System.Windows.Forms.Button();
            this.ReadToDecode = new System.Windows.Forms.Button();
            this.WczytajDoKodowania = new System.Windows.Forms.OpenFileDialog();
           // this.TextToCode = new System.Windows.Forms.TextBox();
            //this.TextToDecode = new System.Windows.Forms.TextBox();
            this.WczytajDoDekodowania = new System.Windows.Forms.OpenFileDialog();
            this.CodeIt = new System.Windows.Forms.Button();
            this.DecodeIt = new System.Windows.Forms.Button();
            this.ToDecodeGroup = new System.Windows.Forms.GroupBox();
            this.SaveToDecode = new System.Windows.Forms.Button();
            this.ToCodeGroup = new System.Windows.Forms.GroupBox();
            this.SaveToCode = new System.Windows.Forms.Button();
            this.ZapiszDoKodowania = new System.Windows.Forms.SaveFileDialog();
            this.ZapiszDoDekodowania = new System.Windows.Forms.SaveFileDialog();
            this.Key1 = new System.Windows.Forms.TextBox();
            this.Key2 = new System.Windows.Forms.TextBox();
            this.Key3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReadKey = new System.Windows.Forms.Button();
            this.WriteKey = new System.Windows.Forms.Button();
            this.WczytajKlucz = new System.Windows.Forms.OpenFileDialog();
            this.ZapiszKlucz = new System.Windows.Forms.SaveFileDialog();
            this.ToDecodeGroup.SuspendLayout();
            this.ToCodeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenKey
            // 
            this.GenKey.BackColor = System.Drawing.Color.Purple;
            this.GenKey.Location = new System.Drawing.Point(14, 15);
            this.GenKey.Margin = new System.Windows.Forms.Padding(4);
            this.GenKey.Name = "GenKey";
            this.GenKey.Size = new System.Drawing.Size(169, 41);
            this.GenKey.TabIndex = 0;
            this.GenKey.Text = "Generuj klucze";
            this.GenKey.UseVisualStyleBackColor = false;
            this.GenKey.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReadToCode
            // 
            this.ReadToCode.BackColor = System.Drawing.Color.Purple;
            this.ReadToCode.Location = new System.Drawing.Point(127, 38);
            this.ReadToCode.Margin = new System.Windows.Forms.Padding(4);
            this.ReadToCode.Name = "ReadToCode";
            this.ReadToCode.Size = new System.Drawing.Size(117, 41);
            this.ReadToCode.TabIndex = 2;
            this.ReadToCode.Text = "Wczytaj plik";
            this.ReadToCode.UseVisualStyleBackColor = false;
            this.ReadToCode.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReadToDecode
            // 
            this.ReadToDecode.BackColor = System.Drawing.Color.Purple;
            this.ReadToDecode.Location = new System.Drawing.Point(135, 40);
            this.ReadToDecode.Margin = new System.Windows.Forms.Padding(4);
            this.ReadToDecode.Name = "ReadToDecode";
            this.ReadToDecode.Size = new System.Drawing.Size(117, 41);
            this.ReadToDecode.TabIndex = 3;
            this.ReadToDecode.Text = "Wczytaj plik";
            this.ReadToDecode.UseVisualStyleBackColor = false;
            this.ReadToDecode.Click += new System.EventHandler(this.ReadToDecode_Click);
            // 
            // WczytajDoKodowania
            // 
            this.WczytajDoKodowania.FileName = "openFileDialog1";
            // 
            // TextToCode
            //
            /*
            this.TextToCode.Location = new System.Drawing.Point(7, 86);
            this.TextToCode.Margin = new System.Windows.Forms.Padding(4);
            this.TextToCode.Multiline = true;
            this.TextToCode.Name = "TextToCode";
            this.TextToCode.Size = new System.Drawing.Size(360, 259);
            this.TextToCode.TabIndex = 4;
            this.TextToCode.Text = "Wpisz tekst do zakodowania";
            
            // 
            // TextToDecode
            // 
            this.TextToDecode.Location = new System.Drawing.Point(7, 89);
            this.TextToDecode.Margin = new System.Windows.Forms.Padding(4);
            this.TextToDecode.Multiline = true;
            this.TextToDecode.Name = "TextToDecode";
            this.TextToDecode.Size = new System.Drawing.Size(360, 257);
            this.TextToDecode.TabIndex = 7;
            this.TextToDecode.Text = "Wpisz tekst do odkodowania";
            */
            // 
            // WczytajDoDekodowania
            // 
            this.WczytajDoDekodowania.FileName = "openFileDialog2";
            // 
            // CodeIt
            // 
            this.CodeIt.BackColor = System.Drawing.Color.Purple;
            this.CodeIt.Location = new System.Drawing.Point(392, 233);
            this.CodeIt.Margin = new System.Windows.Forms.Padding(4);
            this.CodeIt.Name = "CodeIt";
            this.CodeIt.Size = new System.Drawing.Size(135, 125);
            this.CodeIt.TabIndex = 8;
            this.CodeIt.Text = "Zakoduj";
            this.CodeIt.UseVisualStyleBackColor = false;
            this.CodeIt.Click += new System.EventHandler(this.CodeIt_Click);
            // 
            // DecodeIt
            // 
            this.DecodeIt.BackColor = System.Drawing.Color.Purple;
            this.DecodeIt.Location = new System.Drawing.Point(392, 367);
            this.DecodeIt.Margin = new System.Windows.Forms.Padding(4);
            this.DecodeIt.Name = "DecodeIt";
            this.DecodeIt.Size = new System.Drawing.Size(135, 125);
            this.DecodeIt.TabIndex = 9;
            this.DecodeIt.Text = "Odkoduj";
            this.DecodeIt.UseVisualStyleBackColor = false;
            this.DecodeIt.Click += new System.EventHandler(this.DecodeIt_Click);
            // 
            // ToDecodeGroup
            // 
            this.ToDecodeGroup.Controls.Add(this.SaveToDecode);
            this.ToDecodeGroup.Controls.Add(this.ReadToDecode);
            //this.ToDecodeGroup.Controls.Add(this.TextToDecode);
            this.ToDecodeGroup.Location = new System.Drawing.Point(535, 146);
            this.ToDecodeGroup.Margin = new System.Windows.Forms.Padding(4);
            this.ToDecodeGroup.Name = "ToDecodeGroup";
            this.ToDecodeGroup.Padding = new System.Windows.Forms.Padding(4);
            this.ToDecodeGroup.Size = new System.Drawing.Size(371, 444);
            this.ToDecodeGroup.TabIndex = 10;
            this.ToDecodeGroup.TabStop = false;
            this.ToDecodeGroup.Text = "Tekst zakodowany";
            // 
            // SaveToDecode
            // 
            this.SaveToDecode.BackColor = System.Drawing.Color.Purple;
            this.SaveToDecode.Location = new System.Drawing.Point(135, 374);
            this.SaveToDecode.Margin = new System.Windows.Forms.Padding(4);
            this.SaveToDecode.Name = "SaveToDecode";
            this.SaveToDecode.Size = new System.Drawing.Size(117, 41);
            this.SaveToDecode.TabIndex = 8;
            this.SaveToDecode.Text = "Zapisz plik";
            this.SaveToDecode.UseVisualStyleBackColor = false;
            this.SaveToDecode.Click += new System.EventHandler(this.SaveToDecode_Click);
            // 
            // ToCodeGroup
            // 
            this.ToCodeGroup.Controls.Add(this.SaveToCode);
            this.ToCodeGroup.Controls.Add(this.ReadToCode);
            //this.ToCodeGroup.Controls.Add(this.TextToCode);
            this.ToCodeGroup.Location = new System.Drawing.Point(14, 146);
            this.ToCodeGroup.Margin = new System.Windows.Forms.Padding(4);
            this.ToCodeGroup.Name = "ToCodeGroup";
            this.ToCodeGroup.Padding = new System.Windows.Forms.Padding(4);
            this.ToCodeGroup.Size = new System.Drawing.Size(371, 444);
            this.ToCodeGroup.TabIndex = 11;
            this.ToCodeGroup.TabStop = false;
            this.ToCodeGroup.Text = "Tekst do kodowania";
            // 
            // SaveToCode
            // 
            this.SaveToCode.BackColor = System.Drawing.Color.Purple;
            this.SaveToCode.Location = new System.Drawing.Point(127, 374);
            this.SaveToCode.Margin = new System.Windows.Forms.Padding(4);
            this.SaveToCode.Name = "SaveToCode";
            this.SaveToCode.Size = new System.Drawing.Size(117, 41);
            this.SaveToCode.TabIndex = 5;
            this.SaveToCode.Text = "Zapisz plik";
            this.SaveToCode.UseVisualStyleBackColor = false;
            this.SaveToCode.Click += new System.EventHandler(this.SaveToCode_Click);
            // 
            // Key1
            // 
            this.Key1.Location = new System.Drawing.Point(209, 29);
            this.Key1.Margin = new System.Windows.Forms.Padding(4);
            this.Key1.Name = "Key1";
            this.Key1.Size = new System.Drawing.Size(180, 26);
            this.Key1.TabIndex = 12;
            // 
            // Key2
            // 
            this.Key2.Location = new System.Drawing.Point(463, 29);
            this.Key2.Margin = new System.Windows.Forms.Padding(4);
            this.Key2.Name = "Key2";
            this.Key2.Size = new System.Drawing.Size(180, 26);
            this.Key2.TabIndex = 13;
            // 
            // Key3
            // 
            this.Key3.Location = new System.Drawing.Point(721, 29);
            this.Key3.Margin = new System.Windows.Forms.Padding(4);
            this.Key3.Name = "Key3";
            this.Key3.Size = new System.Drawing.Size(180, 26);
            this.Key3.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Klucz 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Klucz 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(718, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Klucz 3";
            // 
            // ReadKey
            // 
            this.ReadKey.BackColor = System.Drawing.Color.Purple;
            this.ReadKey.Location = new System.Drawing.Point(256, 78);
            this.ReadKey.Margin = new System.Windows.Forms.Padding(4);
            this.ReadKey.Name = "ReadKey";
            this.ReadKey.Size = new System.Drawing.Size(130, 41);
            this.ReadKey.TabIndex = 18;
            this.ReadKey.Text = "Wczytaj klucze";
            this.ReadKey.UseVisualStyleBackColor = false;
            this.ReadKey.Click += new System.EventHandler(this.ReadKey_Click);
            // 
            // WriteKey
            // 
            this.WriteKey.BackColor = System.Drawing.Color.Purple;
            this.WriteKey.Location = new System.Drawing.Point(526, 78);
            this.WriteKey.Margin = new System.Windows.Forms.Padding(4);
            this.WriteKey.Name = "WriteKey";
            this.WriteKey.Size = new System.Drawing.Size(130, 41);
            this.WriteKey.TabIndex = 19;
            this.WriteKey.Text = "Zapisz klucze";
            this.WriteKey.UseVisualStyleBackColor = false;
            this.WriteKey.Click += new System.EventHandler(this.WriteKey_Click);
            // 
            // WczytajKlucz
            // 
            this.WczytajKlucz.FileName = "openFileDialog1";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(919, 866);
            this.Controls.Add(this.WriteKey);
            this.Controls.Add(this.ReadKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Key3);
            this.Controls.Add(this.Key2);
            this.Controls.Add(this.Key1);
            this.Controls.Add(this.ToCodeGroup);
            this.Controls.Add(this.ToDecodeGroup);
            this.Controls.Add(this.DecodeIt);
            this.Controls.Add(this.CodeIt);
            this.Controls.Add(this.GenKey);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UI";
            this.Text = "DESX Code/Decode";
            this.Load += new System.EventHandler(this.UI_Load);
            this.ToDecodeGroup.ResumeLayout(false);
            this.ToDecodeGroup.PerformLayout();
            this.ToCodeGroup.ResumeLayout(false);
            this.ToCodeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenKey;
        private System.Windows.Forms.Button ReadToCode;
        private System.Windows.Forms.Button ReadToDecode;
        private System.Windows.Forms.OpenFileDialog WczytajDoKodowania;
        //private System.Windows.Forms.TextBox TextToCode;
        //private System.Windows.Forms.TextBox TextToDecode;
        private System.Windows.Forms.OpenFileDialog WczytajDoDekodowania;
        private System.Windows.Forms.Button CodeIt;
        private System.Windows.Forms.Button DecodeIt;
        private System.Windows.Forms.GroupBox ToDecodeGroup;
        private System.Windows.Forms.GroupBox ToCodeGroup;
        private System.Windows.Forms.Button SaveToDecode;
        private System.Windows.Forms.Button SaveToCode;
        private System.Windows.Forms.SaveFileDialog ZapiszDoKodowania;
        private System.Windows.Forms.SaveFileDialog ZapiszDoDekodowania;
        private System.Windows.Forms.TextBox Key1;
        private System.Windows.Forms.TextBox Key2;
        private System.Windows.Forms.TextBox Key3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ReadKey;
        private System.Windows.Forms.Button WriteKey;
        private System.Windows.Forms.OpenFileDialog WczytajKlucz;
        private System.Windows.Forms.SaveFileDialog ZapiszKlucz;
    }
}

