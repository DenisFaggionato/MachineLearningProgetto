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
            tableLayoutPanel1 = new TableLayoutPanel();
            Invia = new Button();
            Immagine = new PictureBox();
            listBox1 = new ListBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Immagine).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.2001F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.7999F));
            tableLayoutPanel1.Controls.Add(Invia, 1, 1);
            tableLayoutPanel1.Controls.Add(Immagine, 0, 0);
            tableLayoutPanel1.Controls.Add(listBox1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Size = new Size(992, 562);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Invia
            // 
            Invia.Dock = DockStyle.Fill;
            Invia.Location = new Point(798, 480);
            Invia.Name = "Invia";
            Invia.Size = new Size(191, 79);
            Invia.TabIndex = 0;
            Invia.Text = "button1";
            Invia.UseVisualStyleBackColor = true;
            // 
            // Immagine
            // 
            Immagine.BackColor = Color.White;
            Immagine.Cursor = Cursors.Hand;
            Immagine.Dock = DockStyle.Fill;
            Immagine.Location = new Point(3, 3);
            Immagine.Name = "Immagine";
            Immagine.Size = new Size(789, 471);
            Immagine.TabIndex = 1;
            Immagine.TabStop = false;
            Immagine.DragDrop += Immagine_DragDrop;
            Immagine.DragEnter += Immagine_DragEnter;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(798, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 562);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Immagine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button Invia;
        private PictureBox Immagine;
        private ListBox listBox1;
    }
}