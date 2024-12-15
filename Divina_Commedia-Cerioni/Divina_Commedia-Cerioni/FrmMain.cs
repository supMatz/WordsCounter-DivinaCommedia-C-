using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Divina_Commedia_Cerioni
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InizializzaSeparatori();
        }

        /// <summary>
        /// Inizzializzamento array di separatori dai settings dell'applicazione
        /// </summary>
        private void InizializzaSeparatori()
        {
            Program.Separatori = Properties.Settings.Default.separatori.ToCharArray();
        }

        #region Eventi Form

        private void btCaricaFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.CheckFileExists = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Thread trd = new Thread(() => LeggiDaFile(ofd));
                trd.Start();
            }

            pbScansionamentoFile.Value = 0;
            btSalva.Enabled = true;
        }    

        private void btSalva_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); //uso della finestra di dialogo salva file
            sfd.FileName = "Classifica_Parole.csv";
            sfd.Filter = "File di testo (*.csv)|*.txt|Tutti i file (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.OverwritePrompt = true; //chiedo all'utente di sovrascrivere il file
            sfd.CheckFileExists = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Thread trd = new Thread(() => ScriviSuFile(sfd, Program.ParoleDaCaricare));
                trd.Start();
            }
        }

        #endregion

        #region Subroutine

        /// <summary>
        /// Metodo per scrivere sul file .csv ogni parola selezionata con i suoi parametri
        /// </summary>
        /// <param name="sfd"></param>
        /// <param name="lista"></param>
        private void ScriviSuFile(SaveFileDialog sfd, List<Program.sParola> lista)
        {
            StreamWriter sw = new StreamWriter(sfd.FileName, false); //false per sovrascrittura o true per accodamento 

            //scrittura sul file
            for (int i = 0; i < lista.Count; i++)
            {
                sw.Write(lista[i].Contenuto + ", " + lista[i].Ripetizioni + ", ");

                if (lista[i].InInferno)
                    sw.Write("Inferno ");

                if (lista[i].InPurgatorio)
                    sw.Write("Purgatorio ");

                if (lista[i].InParadiso)
                    sw.Write("Paradiso");

                sw.WriteLine(" ");
            }
            
            sw.Close(); //chiusura del file obbligatoria
        }

        /// <summary>
        /// Metodo per leggere dal file e salvare ogni parola
        /// </summary>
        /// <param name="ofd"></param>
        private void LeggiDaFile(OpenFileDialog ofd)
        {
            Program.ParolePiuUsate.Clear(); //reset parole per un nuovo file

            StreamReader sr = new StreamReader(ofd.FileName);
            int NumLettereMin = (int)nudLettereMin.Value; //popolamento lv con controllo lunghezza parole
            Program.eCantica? Cantica = null;

            while (!sr.EndOfStream) //da fare
            {
                string Riga = sr.ReadLine(); //devo splittare le parole con tot lettere con i diversi separatori
                string[] Parole = Riga.Split(Program.Separatori);

                switch(Riga)
                {
                    case "CANTICA INFERNO": Cantica = Program.eCantica.Inferno; break;
                    case "CANTICA PURGATORIO": Cantica = Program.eCantica.Purgatorio; break;
                    case "CANTICA PARADISO": Cantica = Program.eCantica.Paradiso; break;
                }

                ControlloParola(Parole, Cantica);
            }
            sr.Close(); //chiusura stream reader

            SelezioneParole(NumLettereMin);
            
            Invoke((MethodInvoker)delegate //per modificare oggetto grafico in thread main
            {
                PopolaListView(NumLettereMin);
            });
        }

        /// <summary>
        /// Inserimento delle parole con il minimo di lettere all'interno di una lista che verrà poi stampata in ListView
        /// </summary>
        /// <param name="NumLettereMin"></param>
        private void SelezioneParole(int NumLettereMin)
        {
            foreach (Program.sParola p in Program.ParolePiuUsate)
            {
                if (p.Contenuto.Length >= NumLettereMin)
                    Program.ParoleDaCaricare.Add(p);
            }

            OrdinaLista(Program.ParoleDaCaricare);
        }

        /// <summary>
        /// Controllo della validità della parola da inserire nella lista di tutte le parole
        /// </summary>
        /// <param name="parole"></param>
        private void ControlloParola(string[] parole, Program.eCantica? cantica) //da finire
        {
            foreach (string p in parole)
            {
                string parolaMinuscola = p.ToLower(); //non differenzio maiuscolo e minuscolo

                int index = Program.ParolePiuUsate.FindIndex(parola => parola.Contenuto == p);

                if(index != -1)
                {
                    var temp = Program.ParolePiuUsate[index]; //variabile temporanea per assegnazioni
                    ControlloCantica(cantica, ref temp); //trova la cantica
                    temp.Ripetizioni++;
                    Program.ParolePiuUsate[index] = temp; //riassegno temp alla parola nella lista
                }
                else
                {
                    Program.sParola parola = new Program.sParola()
                    {
                        Contenuto = parolaMinuscola,
                        Ripetizioni = 1
                    };

                    ControlloCantica(cantica, ref parola);

                    Program.ParolePiuUsate.Add(parola);
                }
            }
        }

        /// <summary>
        /// Popolo la list view con il controllo sulla lunghezza minima delle parole da inserire
        /// </summary>
        private void PopolaListView(int NumLettereMin)
        {
            lvParole.Items.Clear();
            InitializeProgressBar(pbScansionamentoFile, Program.ParoleDaCaricare.Count);
            
            foreach (Program.sParola p in Program.ParoleDaCaricare)
            {
                if (p.Contenuto.Length >= NumLettereMin)
                {
                    CreaLvi(p, lvParole);
                    pbScansionamentoFile.Value++;
                    pbScansionamentoFile.Refresh();
                }
            }
        }

        /// <summary>
        /// Procedura per ordinare la lista in base ad un parametro presente nelle struct
        /// </summary>
        /// <param name="parole"></param>
        private void OrdinaLista(List<Program.sParola> parole)
        {
            parole.Sort((x, y) => y.Ripetizioni.CompareTo(x.Ripetizioni)); //possibilità di cambiare il tipo di sort
        }

        /// <summary>
        /// Inizializzamento delle proprietà necessarie della list view
        /// </summary>
        /// <param name="progressBar"></param>
        private void InitializeProgressBar(ProgressBar progressBar, int vMax)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = vMax;
            progressBar.Value = 0;
        }

        /// <summary>
        /// Metodo che assegna la cantica alla parola
        /// </summary>
        private void ControlloCantica(Program.eCantica? cantica, ref Program.sParola p)
        {
            switch (cantica)
            {
                case Program.eCantica.Inferno: p.InInferno = true; break;
                case Program.eCantica.Purgatorio: p.InPurgatorio = true; break;
                case Program.eCantica.Paradiso: p.InParadiso = true; break;
            }
        }

        /// <summary>
        /// Procedura per creare un Lv item. Da inserire nelle procedure tipo PopolaListView
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ListView"></param>
        private void CreaLvi(Program.sParola p, ListView ListView)
        {
            ListViewItem lvi = new ListViewItem(p.Contenuto);
            lvi.SubItems.Add(p.Ripetizioni.ToString());
            lvi.SubItems.Add(TrovaCantiche(lvi, p));

            lvParole.Items.Add(lvi);
        }

        /// <summary>
        /// Funzione per stampare le cantiche in cui è presente la parola
        /// </summary>
        /// <param name="lvi"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private string TrovaCantiche(ListViewItem lvi, Program.sParola p)
        {
            string cantiche = null;

            if (p.InInferno)
                cantiche += "Inferno ";
            if (p.InPurgatorio)
                cantiche += "Purgatorio ";
            if (p.InParadiso)
                cantiche += "Paradiso";

            return cantiche;
        }

        #endregion
    }
}
