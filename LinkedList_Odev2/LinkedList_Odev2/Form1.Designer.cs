namespace LinkedList_Odev2
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TxtOgrNo = new TextBox();
            TxtDersKodu = new TextBox();
            TxtHarfNotu = new TextBox();
            listBox1 = new ListBox();
            BtnDersEkle = new Button();
            BtnOgrenciEkle = new Button();
            BtnOgrenciSil = new Button();
            BtnDersSil = new Button();
            BtnDersListele = new Button();
            BtnOgrList = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(107, 41);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 24);
            label1.TabIndex = 0;
            label1.Text = "Öğrenci No:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Corbel", 12F, FontStyle.Bold);
            label2.Location = new Point(116, 85);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 24);
            label2.TabIndex = 1;
            label2.Text = "Ders Kodu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Corbel", 12F, FontStyle.Bold);
            label3.Location = new Point(118, 133);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 24);
            label3.TabIndex = 2;
            label3.Text = "Harf Notu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Corbel", 12F, FontStyle.Bold);
            label4.Location = new Point(129, 190);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(92, 24);
            label4.TabIndex = 3;
            label4.Text = "Sonuçlar:";
            // 
            // TxtOgrNo
            // 
            TxtOgrNo.Location = new Point(237, 38);
            TxtOgrNo.Name = "TxtOgrNo";
            TxtOgrNo.Size = new Size(125, 32);
            TxtOgrNo.TabIndex = 4;
            // 
            // TxtDersKodu
            // 
            TxtDersKodu.Location = new Point(237, 82);
            TxtDersKodu.Name = "TxtDersKodu";
            TxtDersKodu.Size = new Size(125, 32);
            TxtDersKodu.TabIndex = 5;
            // 
            // TxtHarfNotu
            // 
            TxtHarfNotu.Location = new Point(237, 125);
            TxtHarfNotu.Name = "TxtHarfNotu";
            TxtHarfNotu.Size = new Size(125, 32);
            TxtHarfNotu.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 24;
            listBox1.Location = new Point(237, 190);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(418, 100);
            listBox1.TabIndex = 7;
            // 
            // BtnDersEkle
            // 
            BtnDersEkle.Location = new Point(45, 355);
            BtnDersEkle.Name = "BtnDersEkle";
            BtnDersEkle.Size = new Size(122, 60);
            BtnDersEkle.TabIndex = 8;
            BtnDersEkle.Text = "Ders Ekle";
            BtnDersEkle.UseVisualStyleBackColor = true;
            BtnDersEkle.Click += BtnDersEkle_Click;
            // 
            // BtnOgrenciEkle
            // 
            BtnOgrenciEkle.Location = new Point(323, 355);
            BtnOgrenciEkle.Name = "BtnOgrenciEkle";
            BtnOgrenciEkle.Size = new Size(122, 60);
            BtnOgrenciEkle.TabIndex = 9;
            BtnOgrenciEkle.Text = "Öğrenci Ekle";
            BtnOgrenciEkle.UseVisualStyleBackColor = true;
            BtnOgrenciEkle.Click += BtnOgrenciEkle_Click;
            // 
            // BtnOgrenciSil
            // 
            BtnOgrenciSil.Location = new Point(461, 355);
            BtnOgrenciSil.Name = "BtnOgrenciSil";
            BtnOgrenciSil.Size = new Size(122, 60);
            BtnOgrenciSil.TabIndex = 10;
            BtnOgrenciSil.Text = "Öğrenci Sil";
            BtnOgrenciSil.UseVisualStyleBackColor = true;
            BtnOgrenciSil.Click += BtnOgrenciSil_Click;
            // 
            // BtnDersSil
            // 
            BtnDersSil.Location = new Point(185, 355);
            BtnDersSil.Name = "BtnDersSil";
            BtnDersSil.Size = new Size(122, 60);
            BtnDersSil.TabIndex = 11;
            BtnDersSil.Text = "Ders Sil";
            BtnDersSil.UseVisualStyleBackColor = true;
            BtnDersSil.Click += BtnDersSil_Click;
            // 
            // BtnDersListele
            // 
            BtnDersListele.Location = new Point(600, 355);
            BtnDersListele.Name = "BtnDersListele";
            BtnDersListele.Size = new Size(122, 60);
            BtnDersListele.TabIndex = 12;
            BtnDersListele.Text = "Ders Listele";
            BtnDersListele.UseVisualStyleBackColor = true;
            BtnDersListele.Click += BtnDersListele_Click;
            // 
            // BtnOgrList
            // 
            BtnOgrList.Location = new Point(744, 355);
            BtnOgrList.Name = "BtnOgrList";
            BtnOgrList.Size = new Size(122, 60);
            BtnOgrList.TabIndex = 13;
            BtnOgrList.Text = "Öğrenci Listele";
            BtnOgrList.UseVisualStyleBackColor = true;
            BtnOgrList.Click += BtnOgrList_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 524);
            Controls.Add(BtnOgrList);
            Controls.Add(BtnDersListele);
            Controls.Add(BtnDersSil);
            Controls.Add(BtnOgrenciSil);
            Controls.Add(BtnOgrenciEkle);
            Controls.Add(BtnDersEkle);
            Controls.Add(listBox1);
            Controls.Add(TxtHarfNotu);
            Controls.Add(TxtDersKodu);
            Controls.Add(TxtOgrNo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TxtOgrNo;
        private TextBox TxtDersKodu;
        private TextBox TxtHarfNotu;
        private ListBox listBox1;
        private Button BtnDersEkle;
        private Button BtnOgrenciEkle;
        private Button BtnOgrenciSil;
        private Button BtnDersSil;
        private Button BtnDersListele;
        private Button BtnOgrList;
    }
}
