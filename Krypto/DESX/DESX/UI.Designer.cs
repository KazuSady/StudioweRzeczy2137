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
            this.Generated = new System.Windows.Forms.CheckBox();
            this.ReadToCode = new System.Windows.Forms.Button();
            this.ReadToDecode = new System.Windows.Forms.Button();
            this.WczytajDoKodowania = new System.Windows.Forms.OpenFileDialog();
            this.TextToCode = new System.Windows.Forms.TextBox();
            this.TextToDecode = new System.Windows.Forms.TextBox();
            this.WczytajDoDekodowania = new System.Windows.Forms.OpenFileDialog();
            this.CodeIt = new System.Windows.Forms.Button();
            this.DecodeIt = new System.Windows.Forms.Button();
            this.ToDecodeGroup = new System.Windows.Forms.GroupBox();
            this.ToCodeGroup = new System.Windows.Forms.GroupBox();
            this.ZapiszDoKodowania = new System.Windows.Forms.SaveFileDialog();
            this.ZapiszDoDekodowania = new System.Windows.Forms.SaveFileDialog();
            this.SaveToCode = new System.Windows.Forms.Button();
            this.SaveToDecode = new System.Windows.Forms.Button();
            this.ToDecodeGroup.SuspendLayout();
            this.ToCodeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenKey
            // 
            this.GenKey.Location = new System.Drawing.Point(12, 12);
            this.GenKey.Name = "GenKey";
            this.GenKey.Size = new System.Drawing.Size(150, 33);
            this.GenKey.TabIndex = 0;
            this.GenKey.Text = "Generuj klucze";
            this.GenKey.UseVisualStyleBackColor = true;
            this.GenKey.Click += new System.EventHandler(this.button1_Click);
            // 
            // Generated
            // 
            this.Generated.AutoCheck = false;
            this.Generated.AutoSize = true;
            this.Generated.Location = new System.Drawing.Point(196, 19);
            this.Generated.Name = "Generated";
            this.Generated.Size = new System.Drawing.Size(152, 20);
            this.Generated.TabIndex = 1;
            this.Generated.Text = "Czy wygenerowano?";
            this.Generated.UseVisualStyleBackColor = true;
            // 
            // ReadToCode
            // 
            this.ReadToCode.Location = new System.Drawing.Point(113, 30);
            this.ReadToCode.Name = "ReadToCode";
            this.ReadToCode.Size = new System.Drawing.Size(104, 33);
            this.ReadToCode.TabIndex = 2;
            this.ReadToCode.Text = "Wczytaj plik";
            this.ReadToCode.UseVisualStyleBackColor = true;
            this.ReadToCode.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReadToDecode
            // 
            this.ReadToDecode.Location = new System.Drawing.Point(120, 32);
            this.ReadToDecode.Name = "ReadToDecode";
            this.ReadToDecode.Size = new System.Drawing.Size(104, 33);
            this.ReadToDecode.TabIndex = 3;
            this.ReadToDecode.Text = "Wczytaj plik";
            this.ReadToDecode.UseVisualStyleBackColor = true;
            this.ReadToDecode.Click += new System.EventHandler(this.ReadToDecode_Click);
            // 
            // WczytajDoKodowania
            // 
            this.WczytajDoKodowania.FileName = "openFileDialog1";
            // 
            // TextToCode
            // 
            this.TextToCode.Location = new System.Drawing.Point(6, 69);
            this.TextToCode.Multiline = true;
            this.TextToCode.Name = "TextToCode";
            this.TextToCode.Size = new System.Drawing.Size(320, 208);
            this.TextToCode.TabIndex = 4;
            this.TextToCode.Text = "Wpisz tekst do zakodowania";
            // 
            // TextToDecode
            // 
            this.TextToDecode.Location = new System.Drawing.Point(6, 71);
            this.TextToDecode.Multiline = true;
            this.TextToDecode.Name = "TextToDecode";
            this.TextToDecode.Size = new System.Drawing.Size(320, 206);
            this.TextToDecode.TabIndex = 7;
            this.TextToDecode.Text = "Wpisz tekst do odkodowania";
            // 
            // WczytajDoDekodowania
            // 
            this.WczytajDoDekodowania.FileName = "openFileDialog2";
            // 
            // CodeIt
            // 
            this.CodeIt.Location = new System.Drawing.Point(349, 186);
            this.CodeIt.Name = "CodeIt";
            this.CodeIt.Size = new System.Drawing.Size(120, 100);
            this.CodeIt.TabIndex = 8;
            this.CodeIt.Text = "Zakoduj";
            this.CodeIt.UseVisualStyleBackColor = true;
            // 
            // DecodeIt
            // 
            this.DecodeIt.Location = new System.Drawing.Point(348, 294);
            this.DecodeIt.Name = "DecodeIt";
            this.DecodeIt.Size = new System.Drawing.Size(120, 100);
            this.DecodeIt.TabIndex = 9;
            this.DecodeIt.Text = "Odkoduj";
            this.DecodeIt.UseVisualStyleBackColor = true;
            // 
            // ToDecodeGroup
            // 
            this.ToDecodeGroup.Controls.Add(this.SaveToDecode);
            this.ToDecodeGroup.Controls.Add(this.ReadToDecode);
            this.ToDecodeGroup.Controls.Add(this.TextToDecode);
            this.ToDecodeGroup.Location = new System.Drawing.Point(475, 117);
            this.ToDecodeGroup.Name = "ToDecodeGroup";
            this.ToDecodeGroup.Size = new System.Drawing.Size(330, 355);
            this.ToDecodeGroup.TabIndex = 10;
            this.ToDecodeGroup.TabStop = false;
            this.ToDecodeGroup.Text = "Tekst zakodowany";
            // 
            // ToCodeGroup
            // 
            this.ToCodeGroup.Controls.Add(this.SaveToCode);
            this.ToCodeGroup.Controls.Add(this.ReadToCode);
            this.ToCodeGroup.Controls.Add(this.TextToCode);
            this.ToCodeGroup.Location = new System.Drawing.Point(12, 117);
            this.ToCodeGroup.Name = "ToCodeGroup";
            this.ToCodeGroup.Size = new System.Drawing.Size(330, 355);
            this.ToCodeGroup.TabIndex = 11;
            this.ToCodeGroup.TabStop = false;
            this.ToCodeGroup.Text = "Tekst do kodowania";
            // 
            // SaveToCode
            // 
            this.SaveToCode.Location = new System.Drawing.Point(113, 299);
            this.SaveToCode.Name = "SaveToCode";
            this.SaveToCode.Size = new System.Drawing.Size(104, 33);
            this.SaveToCode.TabIndex = 5;
            this.SaveToCode.Text = "Zapisz plik";
            this.SaveToCode.UseVisualStyleBackColor = true;
            this.SaveToCode.Click += new System.EventHandler(this.SaveToCode_Click);
            // 
            // SaveToDecode
            // 
            this.SaveToDecode.Location = new System.Drawing.Point(120, 299);
            this.SaveToDecode.Name = "SaveToDecode";
            this.SaveToDecode.Size = new System.Drawing.Size(104, 33);
            this.SaveToDecode.TabIndex = 8;
            this.SaveToDecode.Text = "Zapisz plik";
            this.SaveToDecode.UseVisualStyleBackColor = true;
            this.SaveToDecode.Click += new System.EventHandler(this.SaveToDecode_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 693);
            this.Controls.Add(this.ToCodeGroup);
            this.Controls.Add(this.ToDecodeGroup);
            this.Controls.Add(this.DecodeIt);
            this.Controls.Add(this.CodeIt);
            this.Controls.Add(this.Generated);
            this.Controls.Add(this.GenKey);
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
        private System.Windows.Forms.CheckBox Generated;
        private System.Windows.Forms.Button ReadToCode;
        private System.Windows.Forms.Button ReadToDecode;
        private System.Windows.Forms.OpenFileDialog WczytajDoKodowania;
        private System.Windows.Forms.TextBox TextToCode;
        private System.Windows.Forms.TextBox TextToDecode;
        private System.Windows.Forms.OpenFileDialog WczytajDoDekodowania;
        private System.Windows.Forms.Button CodeIt;
        private System.Windows.Forms.Button DecodeIt;
        private System.Windows.Forms.GroupBox ToDecodeGroup;
        private System.Windows.Forms.GroupBox ToCodeGroup;
        private System.Windows.Forms.Button SaveToDecode;
        private System.Windows.Forms.Button SaveToCode;
        private System.Windows.Forms.SaveFileDialog ZapiszDoKodowania;
        private System.Windows.Forms.SaveFileDialog ZapiszDoDekodowania;
    }
}

