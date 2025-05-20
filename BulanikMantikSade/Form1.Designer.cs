
namespace BulanikMantikSade
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
            trackBarHassaslik = new TrackBar();
            trackBarKirlilik = new TrackBar();
            label2 = new Label();
            trackBarMiktar = new TrackBar();
            label3 = new Label();
            button1 = new Button();
            listBoxSonuc = new ListBox();
            btnTemizle = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            listBox1 = new ListBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarHassaslik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarKirlilik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMiktar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 29);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 0;
            label1.Text = "hassaslık";
            // 
            // trackBarHassaslik
            // 
            trackBarHassaslik.LargeChange = 2;
            trackBarHassaslik.Location = new Point(59, 88);
            trackBarHassaslik.Margin = new Padding(3, 4, 3, 4);
            trackBarHassaslik.Maximum = 100;
            trackBarHassaslik.Name = "trackBarHassaslik";
            trackBarHassaslik.Size = new Size(219, 56);
            trackBarHassaslik.TabIndex = 1;
            trackBarHassaslik.TickFrequency = 5;
            trackBarHassaslik.Scroll += trackBarHassaslik_Scroll;
            // 
            // trackBarKirlilik
            // 
            trackBarKirlilik.Location = new Point(336, 88);
            trackBarKirlilik.Margin = new Padding(3, 4, 3, 4);
            trackBarKirlilik.Maximum = 100;
            trackBarKirlilik.Name = "trackBarKirlilik";
            trackBarKirlilik.Size = new Size(226, 56);
            trackBarKirlilik.TabIndex = 3;
            trackBarKirlilik.TickFrequency = 5;
            trackBarKirlilik.Scroll += trackBarKirlilik_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(325, 29);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 2;
            label2.Text = "kirlilik";
            // 
            // trackBarMiktar
            // 
            trackBarMiktar.Location = new Point(595, 88);
            trackBarMiktar.Margin = new Padding(3, 4, 3, 4);
            trackBarMiktar.Maximum = 100;
            trackBarMiktar.Name = "trackBarMiktar";
            trackBarMiktar.Size = new Size(224, 56);
            trackBarMiktar.TabIndex = 5;
            trackBarMiktar.TickFrequency = 5;
            trackBarMiktar.Scroll += trackBarMiktar_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(584, 29);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 4;
            label3.Text = "miktar";
            // 
            // button1
            // 
            button1.Location = new Point(688, 16);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(103, 51);
            button1.TabIndex = 6;
            button1.Text = "hesapla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBoxSonuc
            // 
            listBoxSonuc.FormattingEnabled = true;
            listBoxSonuc.Location = new Point(18, 305);
            listBoxSonuc.Margin = new Padding(3, 4, 3, 4);
            listBoxSonuc.Name = "listBoxSonuc";
            listBoxSonuc.Size = new Size(266, 184);
            listBoxSonuc.TabIndex = 7;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(798, 16);
            btnTemizle.Margin = new Padding(3, 4, 3, 4);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(103, 51);
            btnTemizle.TabIndex = 8;
            btnTemizle.Text = "temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 29);
            label4.Name = "label4";
            label4.Size = new Size(17, 20);
            label4.TabIndex = 9;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(389, 29);
            label5.Name = "label5";
            label5.Size = new Size(17, 20);
            label5.TabIndex = 10;
            label5.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(638, 29);
            label6.Name = "label6";
            label6.Size = new Size(17, 20);
            label6.TabIndex = 11;
            label6.Text = "0";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(296, 305);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(266, 184);
            listBox1.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 647);
            label7.Name = "label7";
            label7.Size = new Size(44, 20);
            label7.TabIndex = 13;
            label7.Text = "Devir";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(389, 647);
            label8.Name = "label8";
            label8.Size = new Size(66, 20);
            label8.TabIndex = 14;
            label8.Text = "Deterjan";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(715, 647);
            label9.Name = "label9";
            label9.Size = new Size(38, 20);
            label9.TabIndex = 15;
            label9.Text = "Süre";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1810, 961);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(listBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnTemizle);
            Controls.Add(listBoxSonuc);
            Controls.Add(button1);
            Controls.Add(trackBarMiktar);
            Controls.Add(label3);
            Controls.Add(trackBarKirlilik);
            Controls.Add(label2);
            Controls.Add(trackBarHassaslik);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Burak AKKOÇ-(Bulanık Mantık)";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarHassaslik).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarKirlilik).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMiktar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TrackBar trackBarHassaslik;
        private TrackBar trackBarKirlilik;
        private Label label2;
        private TrackBar trackBarMiktar;
        private Label label3;
        private Button button1;
        private ListBox listBoxSonuc;
        private Button btnTemizle;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListBox listBox1;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}
