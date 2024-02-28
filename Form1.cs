using System.Diagnostics;
using System.Windows.Forms;

namespace MacchinaImparante
{
    public partial class Form1 : Form
    {
        private string imagePath;

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

            Console.WriteLine(imagePath);
        }

        private void Immagine_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Invia_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                Console.WriteLine(imagePath);
                string pythonScriptPath = "C:\\Users\\1\\source\\repos\\MachineLearningProgetto\\ml.py";

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
                        Console.WriteLine($"Errore: {error}");
                    }
                    else
                    {
                        // Output ottenuto dallo script Python
                        string[] righeOutput = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        AggiungiRisultatiAlTableLayoutPanel(righeOutput.ToList(), tableLayoutPanel2);
                    }
                }
            }
            else
            {
                Console.WriteLine("Nessuna immagine selezionata.");
            }
        }

        private void AggiungiRisultatiAlTableLayoutPanel(List<string> listaCapiVestiario, TableLayoutPanel t)
        {

            for (int i = 0; i < listaCapiVestiario.Count; i++)
            {
                Label label = new Label();
                label.Text = listaCapiVestiario[i];
                label.Dock = DockStyle.Fill;

                t.Controls.Add(label, 0, i);
            }
        }
    }
}