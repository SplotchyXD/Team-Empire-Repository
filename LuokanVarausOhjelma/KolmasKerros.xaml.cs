using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LuokanVarausOhjelma
{
    /// <summary>
    /// Interaction logic for KolmasKerros.xaml
    /// </summary>
    public partial class KolmasKerros : Window
    {
        //Asetetaan parametrit SQL yhteyden ja kommentojen käyttöön 
        public SqlConnection con;
        public SqlCommand cmd;

        //Asetetaan kaikille luokille Count funktioit joita käytetään varauksen yhteydessä
        public int KVCount;
        public int PKCount;
        public int TKCount;
        public int HaikuCount;
        public int MainioCount;
        public int DiiliCount;

        //Värit mitä käytetään kun luokka varataan tai vapautetaan
        SolidColorBrush VarausBrush = new SolidColorBrush(Colors.Red);
        SolidColorBrush VapaaBrush = new SolidColorBrush(Colors.Green);

        public KolmasKerros()
        {
            //tässä kohdassa kutsutaan kaikkia methodeja joita tässä projektissa käytetään
            /*
             * Get_Data_SQL methodi tarkistaa kaikkien luokkien varausten tilat
             * StartKello methodi aloittaa ohjelman sisäisin kellon toiminnon
             * Startkellosta 4 riviä on tarkoitettu tietojen päivitykselle jotta ohjelmalla on aina tiedot oikeani(koska tätä pyöritetään aulassa), tämä suoritetään timer:ia käyttäen
             * timer:ille on asetettu aikaväli millä se toimii(30 sekunttia), mitä tapahtuu kun timerin aika on loppu(aloitetaan uusi) ja lopussa kerrotaan aloitetaan timer
            */
            InitializeComponent();
            Get_Data_SQL();
            StartKello();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 20000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            //tätä methodia käytetään päivittämään tietoja ja tätä kutsutaan kun timerista loppuu aika ja aloitetaan uusi timer
            void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Get_Data_SQL();
                }));
            }
        }

        /*private void Nappi_painettu(object sender, KeyEventArgs e)
        {
            //Tämän methodin ideana on ottaa kaikista luokista varaus inputit(eli napin painallukset) ja sen mukaan asettaa varaukset ja vapautukset
            //methodin alussa kerrotaan mihin tietokantaan yhteys avataaan
            //yhteys avataan
            //riippuen mitä nappia painetaan niin haetaan sen mukaan luokka ja katsotaan onko se varattu tai ei
            //jos luokka on varattu niin luokka asetetaan vapaaksi ja jos se on vapaana niin se asetetaan varatuksi
            //jokainen komento on sama jokaiselle luokalle ainoa ero on se että jos luokka on varattu niin se asetetaan vapaksi eli 0 ja jos se on varattu niin tilan numeroksi tulee 1
            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");
            con.Open();
            if (e.Key == Key.Space && KVCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Kaupingin_Vallot'", con);
                KVCount++;
                KaupunginValot.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && KVCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Kaupingin_Vallot'", con);
                KVCount--;
                KaupunginValot.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Space && KVCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Tsaarin_Kuriiri'", con);
                TKCount++;
                TsaarinKuriiri.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && KVCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tsaarin_Kuriiri'", con);
                TKCount--;
                TsaarinKuriiri.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Space && KVCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Päivien_Kimallus'", con);
                PKCount++;
                PäivienKimallus.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && KVCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Päivien_Kimallus'", con);
                PKCount--;
                PäivienKimallus.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Space && KVCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Haiku'", con);
                HaikuCount++;
                Haiku.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && KVCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Haiku'", con);
                HaikuCount--;
                Haiku.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Space && KVCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Diili'", con);
                DiiliCount++;
                Diili.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && KVCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Diili'", con);
                DiiliCount--;
                Diili.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Space && KVCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Mainio'", con);
                MainioCount++;
                Mainio.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && KVCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Mainio'", con);
                MainioCount--;
                Mainio.Fill = VapaaBrush;
            }
            //tässä kohdassa valittu komento suoritetaan
            //ja sen jälkeen yhteys suljetaan((yhteyksen sulkeminen on sitä varten että kukaan jolla on tietoa sql:stä ei voi suorittaa SQL Injectionia ja päästä käsiksi tietokantaan))
            cmd.ExecuteNonQuery();
            con.Close();
        }*/

        public void Get_Data_SQL()
        {
            SqlDataReader rdr = null;
            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");

            //yhteys avataan
            //asetetaan mitä komento tekee kun sitä käytetään (komento hakee Is_Varattu sarakkeen tietokannasta)
            //komento satetaan texti muotoon jotta SqlDataReader pystyy lukemaan sen
            //komento suoritetaan ja sen jälkeen rdr lukee mitä se on löytänyt
            //jos rdr löytää että Is_Varattu on true(eli siis varatttu) niin asetetaan luokkka varatuksi(1) ja väriksi laitetaan VarausBrush(Punainen)
            //jos rdr löytää että Is_Varattu on False(eli siis vapaa) niin aseteaan luokkka vapaaksi(0) ja väriksi VapaaBrush(Vihreä)
            //ja lopussa suljetaan yhteys tietokantaan(yhteyksen sulkeminen on sitä varten että kukaan jolla on tietoa sql:stä ei voi suorittaa SQL Injectionia ja päästä käsiksi tietokantaan)
            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Kaupingin_Vallot'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                KVCount = 1;
                KaupunginValot.Fill = VarausBrush;
            }
            else
            {
                KVCount = 0;
                KaupunginValot.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tsaarin_Kuriiri'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                TKCount = 1;
                TsaarinKuriiri.Fill = VarausBrush;
            }
            else
            {
                TKCount = 0;
                TsaarinKuriiri.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='päivien_Kimallus'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                PKCount = 1;
                PäivienKimallus.Fill = VarausBrush;
            }
            else
            {
                PKCount = 0;
                PäivienKimallus.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Diili'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                DiiliCount = 1;
                Diili.Fill = VarausBrush;
            }
            else
            {
                DiiliCount = 0;
                Diili.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Mainio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                MainioCount = 1;
                Mainio.Fill = VarausBrush;
            }
            else
            {
                MainioCount = 0;
                Mainio.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Haiku'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                HaikuCount = 1;
                Haiku.Fill = VarausBrush;
            }
            else
            {
                HaikuCount = 0;
                Haiku.Fill = VapaaBrush;
            }
            con.Close();
        }
        public void StartKello()
        {
            //asetetaan DispatcherTimer:ille timeksi timer
            //tämän jälkeen asetettaan timerille parametrit jotta se toimisi kuin kello
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            //asetetaan teksti elementtin teksti kellon ajaksi 
            kellolbl.Text = DateTime.Now.ToString();
        }

        private void TokaKerros1_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();

            MainWindow.Close();
        }
    }
}