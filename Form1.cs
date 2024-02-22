namespace MacchinaImparante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Immagine.AllowDrop = true;
        }

        private void Immagine_DragDrop(object sender, DragEventArgs e)
        {

            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];

                if (fileNames.Length > 0)
                {
                    Immagine.Image = Image.FromFile(fileNames[0]);

                }
            }

        }

        private void Immagine_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}