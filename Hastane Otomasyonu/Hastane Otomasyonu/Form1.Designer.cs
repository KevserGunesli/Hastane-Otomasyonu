namespace Hastane_Otomasyonu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewHastalar = new DataGridView();
            buttonHastalariYukle = new Button();
            buttonMuayeneyeBasla = new Button();
            listBoxMuayeneEdilenHastalar = new ListBox();
            labelSAAT = new Label();
            label1 = new Label();
            panelMuayene = new Panel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHastalar).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHastalar
            // 
            dataGridViewHastalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHastalar.Location = new Point(184, 212);
            dataGridViewHastalar.Name = "dataGridViewHastalar";
            dataGridViewHastalar.ReadOnly = true;
            dataGridViewHastalar.RowHeadersWidth = 62;
            dataGridViewHastalar.Size = new Size(1092, 730);
            dataGridViewHastalar.TabIndex = 0;
            // 
            // buttonHastalariYukle
            // 
            buttonHastalariYukle.BackColor = SystemColors.ActiveCaption;
            buttonHastalariYukle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            buttonHastalariYukle.Location = new Point(555, 66);
            buttonHastalariYukle.Name = "buttonHastalariYukle";
            buttonHastalariYukle.Size = new Size(224, 92);
            buttonHastalariYukle.TabIndex = 1;
            buttonHastalariYukle.Text = "Hastaları Yükle";
            buttonHastalariYukle.UseVisualStyleBackColor = false;
            buttonHastalariYukle.Click += buttonHastalariYukle_Click;
            // 
            // buttonMuayeneyeBasla
            // 
            buttonMuayeneyeBasla.BackColor = SystemColors.ActiveCaption;
            buttonMuayeneyeBasla.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            buttonMuayeneyeBasla.Location = new Point(965, 111);
            buttonMuayeneyeBasla.Name = "buttonMuayeneyeBasla";
            buttonMuayeneyeBasla.Size = new Size(311, 70);
            buttonMuayeneyeBasla.TabIndex = 2;
            buttonMuayeneyeBasla.Text = "Muayeneye Başla";
            buttonMuayeneyeBasla.UseVisualStyleBackColor = false;
            buttonMuayeneyeBasla.Click += buttonMuayeneyeBasla_Click;
            // 
            // listBoxMuayeneEdilenHastalar
            // 
            listBoxMuayeneEdilenHastalar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            listBoxMuayeneEdilenHastalar.FormattingEnabled = true;
            listBoxMuayeneEdilenHastalar.ItemHeight = 28;
            listBoxMuayeneEdilenHastalar.Location = new Point(20, 720);
            listBoxMuayeneEdilenHastalar.Name = "listBoxMuayeneEdilenHastalar";
            listBoxMuayeneEdilenHastalar.Size = new Size(1434, 200);
            listBoxMuayeneEdilenHastalar.TabIndex = 3;
            // 
            // labelSAAT
            // 
            labelSAAT.AutoSize = true;
            labelSAAT.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSAAT.Location = new Point(1039, 41);
            labelSAAT.Name = "labelSAAT";
            labelSAAT.Size = new Size(246, 47);
            labelSAAT.TabIndex = 4;
            labelSAAT.Text = "SAAT: 08:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(555, 91);
            label1.Name = "label1";
            label1.Size = new Size(241, 48);
            label1.TabIndex = 5;
            label1.Text = "Tüm Hastalar";
            // 
            // panelMuayene
            // 
            panelMuayene.BackColor = Color.AliceBlue;
            panelMuayene.Location = new Point(6, 186);
            panelMuayene.Margin = new Padding(4, 5, 4, 5);
            panelMuayene.Name = "panelMuayene";
            panelMuayene.Size = new Size(1475, 548);
            panelMuayene.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(436, 15);
            label2.Name = "label2";
            label2.Size = new Size(511, 48);
            label2.TabIndex = 9;
            label2.Text = "Muayene Sırasındaki Hastalar";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1494, 1028);
            Controls.Add(dataGridViewHastalar);
            Controls.Add(buttonMuayeneyeBasla);
            Controls.Add(listBoxMuayeneEdilenHastalar);
            Controls.Add(label2);
            Controls.Add(panelMuayene);
            Controls.Add(label1);
            Controls.Add(labelSAAT);
            Controls.Add(buttonHastalariYukle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHastalar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewHastalar;
        private Button buttonHastalariYukle;
        private Button buttonMuayeneyeBasla;
        private ListBox listBoxMuayeneEdilenHastalar;
        private Label labelSAAT;
        private Label label1;
        private Panel panelMuayene;
        private Label label2;
    }
}
