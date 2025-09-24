using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace konyvtar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		StreamReader sr = new StreamReader("olvasok.txt");
		StreamWriter sw = new StreamWriter("olvasok.txt", false);
		List<Olvaso> olvasok = new List<Olvaso>();
		public MainWindow()
        {
            InitializeComponent();
        }

        private void  fajlbeolvasas()
        {
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Olvaso o = new Olvaso(adatok[0], int.Parse(adatok[1]), adatok[2], bool.Parse(adatok[3]), bool.Parse(adatok[4]), adatok[5]);
                olvasok.Add(o);
			}
		}

        private void fajliras()
        {

        }


    }
}