namespace MacchinaImparante
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
            tableLayoutPanel2 = new TableLayoutPanel();
            Invia = new Button();
            Output = new ListBox();
            Immagine = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Immagine).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.AppWorkspace;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(Invia, 0, 1);
            tableLayoutPanel2.Controls.Add(Output, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(912, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(219, 743);
            tableLayoutPanel2.TabIndex = 2;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // Invia
            // 
            Invia.BackColor = Color.Red;
            Invia.Dock = DockStyle.Fill;
            Invia.FlatStyle = FlatStyle.Flat;
            Invia.Font = new Font("Snap ITC", 28.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            Invia.ForeColor = Color.FromArgb(128, 255, 128);
            Invia.Location = new Point(3, 598);
            Invia.Margin = new Padding(3, 4, 3, 4);
            Invia.Name = "Invia";
            Invia.Size = new Size(213, 141);
            Invia.TabIndex = 2;
            Invia.Text = "INVIA";
            Invia.UseVisualStyleBackColor = false;
            Invia.Click += Invia_Click_1;
            // 
            // Output
            // 
            Output.BackColor = Color.FromArgb(224, 224, 224);
            Output.Dock = DockStyle.Fill;
            Output.Font = new Font("Stencil", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            Output.FormattingEnabled = true;
            Output.ItemHeight = 35;
            Output.Items.AddRange(new object[] { "Output:" });
            Output.Location = new Point(3, 3);
            Output.Name = "Output";
            Output.Size = new Size(213, 588);
            Output.TabIndex = 3;
            // 
            // Immagine
            // 
            Immagine.BackColor = Color.White;
            Immagine.Cursor = Cursors.Hand;
            Immagine.Dock = DockStyle.Fill;
            Immagine.Image = Properties.Resources.SFONDO_MACCHINA_IMPARANTE;
            Immagine.Location = new Point(3, 4);
            Immagine.Margin = new Padding(3, 4, 3, 4);
            Immagine.Name = "Immagine";
            Immagine.Size = new Size(903, 741);
            Immagine.SizeMode = PictureBoxSizeMode.StretchImage;
            Immagine.TabIndex = 1;
            Immagine.TabStop = false;
            Immagine.Click += Immagine_Click;
            Immagine.DragDrop += Immagine_DragDrop;
            Immagine.DragEnter += Immagine_DragEnter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.2001F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.7999F));
            tableLayoutPanel1.Controls.Add(Immagine, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1134, 749);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 749);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Immagine).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Button Invia;
        private PictureBox Immagine;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox Output;
    }
}