using System.Diagnostics;
using System.Windows.Forms;

namespace MacchinaImparante
{
    public partial class Form1 : Form
    {
        private string imagePath = @"";

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
                    imagePath = fileNames[0];
                    Immagine.Image = Image.FromFile(imagePath);
                }
            }
        }

        private void Immagine_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Invia_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                string pythonScriptPath = "C:\\Users\\1\\Source\\Repos\\MachineLearningProgetto1\\model\\model.py";

                // Esegui lo script Python utilizzando subprocess
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python";
                start.Arguments = $"{pythonScriptPath} \"{imagePath}\"";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                start.CreateNoWindow = true;

                using (Process process = new Process { StartInfo = start })
                {
                    //Avvio il processo
                    process.Start();

                    //Leggo l'output standard dello script Python
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    //Attendo che lo script Python termini
                    process.WaitForExit();

                    //controllo se ci sono errori durante l'esecuzione dello script ed eventualmente stampo un messaggio
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error);
                    }
                    else
                    {
                        // Output ottenuto dallo script Python
                        string[] results = output.Split(',');
                        Output.Items.Add(results[0]);
                        Output.Items.Add(results[1]);

                    }
                }
            }
            else
            {
                Console.WriteLine("Nessuna immagine selezionata.");
            }
        }
    }
}