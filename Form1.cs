using System.Diagnostics;

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

        private void Immagine_Click(object sender, EventArgs e)
        {

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Invia_Click_1(object sender, EventArgs e)
        {
            string pythonScriptPath = "path_al_tuo_script_python.py";

            // Eseguire lo script Python utilizzando subprocess
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = $"{pythonScriptPath} arg1 arg2";  // Passa gli argomenti del tuo script Python
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    // Manipola il risultato come necessario
                    Console.WriteLine(result);
                }
            }
        }
    }
}