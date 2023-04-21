namespace Xmodem
{
    partial class Xmodem
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
            this.Rola = new System.Windows.Forms.GroupBox();
            this.Sender = new System.Windows.Forms.RadioButton();
            this.Receiver = new System.Windows.Forms.RadioButton();
            this.StartButton = new System.Windows.Forms.Button();
            this.COM = new System.Windows.Forms.GroupBox();
            this.CheckCOMs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WyborCOM = new System.Windows.Forms.TextBox();
            this.Dostepne = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Wczytaj = new System.Windows.Forms.OpenFileDialog();
            this.XmodemType = new System.Windows.Forms.GroupBox();
            this.CRCOpt = new System.Windows.Forms.RadioButton();
            this.BaseOpt = new System.Windows.Forms.RadioButton();
            this.Rola.SuspendLayout();
            this.COM.SuspendLayout();
            this.XmodemType.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rola
            // 
            this.Rola.Controls.Add(this.Sender);
            this.Rola.Controls.Add(this.Receiver);
            this.Rola.Location = new System.Drawing.Point(13, 13);
            this.Rola.Name = "Rola";
            this.Rola.Size = new System.Drawing.Size(209, 100);
            this.Rola.TabIndex = 0;
            this.Rola.TabStop = false;
            this.Rola.Text = "Rola";
            // 
            // Sender
            // 
            this.Sender.AutoSize = true;
            this.Sender.Location = new System.Drawing.Point(126, 46);
            this.Sender.Name = "Sender";
            this.Sender.Size = new System.Drawing.Size(72, 20);
            this.Sender.TabIndex = 1;
            this.Sender.TabStop = true;
            this.Sender.Text = "Sender";
            this.Sender.UseVisualStyleBackColor = true;
            // 
            // Receiver
            // 
            this.Receiver.AutoSize = true;
            this.Receiver.Location = new System.Drawing.Point(6, 46);
            this.Receiver.Name = "Receiver";
            this.Receiver.Size = new System.Drawing.Size(83, 20);
            this.Receiver.TabIndex = 0;
            this.Receiver.TabStop = true;
            this.Receiver.Text = "Receiver";
            this.Receiver.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(13, 311);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(130, 63);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // COM
            // 
            this.COM.Controls.Add(this.CheckCOMs);
            this.COM.Controls.Add(this.label2);
            this.COM.Controls.Add(this.label1);
            this.COM.Controls.Add(this.WyborCOM);
            this.COM.Controls.Add(this.Dostepne);
            this.COM.Location = new System.Drawing.Point(13, 119);
            this.COM.Name = "COM";
            this.COM.Size = new System.Drawing.Size(431, 139);
            this.COM.TabIndex = 2;
            this.COM.TabStop = false;
            this.COM.Text = "COM";
            // 
            // CheckCOMs
            // 
            this.CheckCOMs.Location = new System.Drawing.Point(126, 55);
            this.CheckCOMs.Name = "CheckCOMs";
            this.CheckCOMs.Size = new System.Drawing.Size(86, 48);
            this.CheckCOMs.TabIndex = 6;
            this.CheckCOMs.Text = "Sprawdź COMy";
            this.CheckCOMs.UseVisualStyleBackColor = true;
            this.CheckCOMs.Click += new System.EventHandler(this.CheckCOMs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wybór";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dostępne";
            // 
            // WyborCOM
            // 
            this.WyborCOM.Location = new System.Drawing.Point(298, 68);
            this.WyborCOM.Name = "WyborCOM";
            this.WyborCOM.Size = new System.Drawing.Size(72, 22);
            this.WyborCOM.TabIndex = 4;
            // 
            // Dostepne
            // 
            this.Dostepne.Location = new System.Drawing.Point(6, 49);
            this.Dostepne.Multiline = true;
            this.Dostepne.Name = "Dostepne";
            this.Dostepne.Size = new System.Drawing.Size(100, 73);
            this.Dostepne.TabIndex = 3;
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(170, 331);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(274, 22);
            this.Status.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status";
            // 
            // Wczytaj
            // 
            this.Wczytaj.FileName = "openFileDialog1";
            // 
            // XmodemType
            // 
            this.XmodemType.Controls.Add(this.CRCOpt);
            this.XmodemType.Controls.Add(this.BaseOpt);
            this.XmodemType.Location = new System.Drawing.Point(244, 13);
            this.XmodemType.Name = "XmodemType";
            this.XmodemType.Size = new System.Drawing.Size(200, 100);
            this.XmodemType.TabIndex = 6;
            this.XmodemType.TabStop = false;
            this.XmodemType.Text = "Typ Xmodem";
            // 
            // CRCOpt
            // 
            this.CRCOpt.AutoSize = true;
            this.CRCOpt.Location = new System.Drawing.Point(124, 46);
            this.CRCOpt.Name = "CRCOpt";
            this.CRCOpt.Size = new System.Drawing.Size(56, 20);
            this.CRCOpt.TabIndex = 1;
            this.CRCOpt.TabStop = true;
            this.CRCOpt.Text = "CRC";
            this.CRCOpt.UseVisualStyleBackColor = true;
            // 
            // BaseOpt
            // 
            this.BaseOpt.AutoSize = true;
            this.BaseOpt.Location = new System.Drawing.Point(22, 46);
            this.BaseOpt.Name = "BaseOpt";
            this.BaseOpt.Size = new System.Drawing.Size(60, 20);
            this.BaseOpt.TabIndex = 0;
            this.BaseOpt.TabStop = true;
            this.BaseOpt.Text = "Base";
            this.BaseOpt.UseVisualStyleBackColor = true;
            // 
            // Xmodem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 453);
            this.Controls.Add(this.XmodemType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.COM);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Rola);
            this.Name = "Xmodem";
            this.Text = "Xmodem";
            this.Rola.ResumeLayout(false);
            this.Rola.PerformLayout();
            this.COM.ResumeLayout(false);
            this.COM.PerformLayout();
            this.XmodemType.ResumeLayout(false);
            this.XmodemType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Rola;
        private System.Windows.Forms.RadioButton Sender;
        private System.Windows.Forms.RadioButton Receiver;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox COM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WyborCOM;
        private System.Windows.Forms.TextBox Dostepne;
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog Wczytaj;
        private System.Windows.Forms.Button CheckCOMs;
        private System.Windows.Forms.GroupBox XmodemType;
        private System.Windows.Forms.RadioButton CRCOpt;
        private System.Windows.Forms.RadioButton BaseOpt;
    }
}

