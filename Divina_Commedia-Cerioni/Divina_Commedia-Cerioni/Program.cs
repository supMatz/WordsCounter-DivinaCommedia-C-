using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Divina_Commedia_Cerioni
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        public static List<sParola> ParolePiuUsate = new List<sParola>();
        public static List<sParola> ParoleDaCaricare = new List<sParola>();
        public static char[] Separatori = new char[Properties.Settings.Default.separatori.Length];

        public enum eCantica
        {
            Inferno = 1,
            Purgatorio,
            Paradiso
        }

        public struct sParola
        {
            public int Ripetizioni { get; set; }
            public string Contenuto { get; set; }
            public bool InInferno { get; set; }
            public bool InPurgatorio { get; set; }
            public bool InParadiso { get; set; }

        }
    }
}
