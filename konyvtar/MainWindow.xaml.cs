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
		List<Olvaso> olvasok = new List<Olvaso>();
        List<string> mufajok = new List<string>() { "regény", "vers", "tudományos", "ismeretterjesztő", "szakácskönyv", "mese" };
        List<string> kiiras = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            Fajlbeolvasas();
            LBbox.ItemsSource = kiiras;
            cmb_mufaj.ItemsSource = mufajok;
        }

        private void  Fajlbeolvasas()
        {
            StreamReader sr = new StreamReader("olvasok.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                Olvaso o = new Olvaso(adatok[0], int.Parse(adatok[1]), adatok[2], bool.Parse(adatok[3]), bool.Parse(adatok[4]), adatok[5]);
                olvasok.Add(o);
                
			}
            Iras();
            sr.Close();
        }

        private void Iras()
        {
            kiiras.Clear();
            foreach (Olvaso o in olvasok)
            {
                kiiras.Add(o.Nev + ";" + o.Eletkor + ";" + o.Mufaj + ";" + o.Hirlevel + ";" + o.Sms + ";" + o.Tagsag);
            }
            LBbox.Items.Refresh();
        }

        private void Fajliras()
        {
            StreamWriter sw = new StreamWriter("olvasok.txt", false);

            foreach (Olvaso o in olvasok)
            {
                sw.WriteLine(o.Nev + ";" + o.Eletkor + ";" + o.Mufaj + ";" + o.Hirlevel + ";" + o.Sms + ";" + o.Tagsag);
            }
            Iras();
            sw.Close();
        }

        private void btn_ment_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nev.Text != "" && txt_kor.Text != null && cmb_mufaj.Text != "")
            {
                if (rb_diak.IsChecked == true || rb_norm.IsChecked == true || rb_nyug.IsChecked == true)
                {
                    Mentes();
                }
                else
                {
                    MessageBox.Show(this, "Kötelező minden mezőt kitölteni a szolgáltatásokon kívűl!", "Hiányos adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(this, "Kötelező minden mezőt kitölteni a szolgáltatásokon kívűl!", "Hiányos adat", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Mentes()
        {
            string nev = txt_nev.Text;
            int eletkor = int.Parse(txt_kor.Text);
            string mufaj = cmb_mufaj.Text;
            bool hirlevel;
            bool sms;
            string tagsag;
            if (chb_hir.IsChecked == true)
            {
                hirlevel = true;
            }
            else
            {
                hirlevel = false;
            }
            if (chb_sms.IsChecked == true)
            {
                sms = true;
            }
            else
            {
                sms = false;
            }
            if (rb_diak.IsChecked == true)
            {
                tagsag = "diák";
            }
            else if (rb_norm.IsChecked == true)
            {
                tagsag = "felnőtt";
            }
            else
            {
                tagsag = "nyugdíjas";
            }

            Olvaso o = new Olvaso(nev, eletkor, mufaj, hirlevel, sms, tagsag);
            olvasok.Add(o);
            txtbox.Text = "Sikeres regisztráció!";
            Fajliras();
        }
    }
}