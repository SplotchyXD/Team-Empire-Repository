using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Windows.Threading;

namespace LuokanVarausOhjelma
{
    public partial class MainWindow : Window
    {
        //Asetetaan parametrit SQL yhteyden ja kommentojen käyttöön 
        public SqlConnection con;
        public SqlCommand cmd;
        
        //Asetetaan kaikille luokille Count funktioit joita käytetään varauksen yhteydessä
        public int KaneliCount = 0;
        public int BittiCount = 0;
        public int StudyOCount = 0;
        public int VirnaCount = 0;
        public int VisioCount = 0;
        public int TuumaCount = 0;
        public int AmadeusCount = 0;
        public int ToimiCount = 0;
        public int TaitoCount = 0;
        public int DigiLuolaCount = 0;
        public int VoittoCount = 0;
        public int ArvoCount = 0;
        public int FiktioCount = 0;
        public int MissioCount = 0;
        public int IdeaCount = 0;
        public int ImagoCount = 0;
        public int VolttiCount = 0;
        public int TiliCount = 0;
        public int TohtoriCount = 0;
        public int TietoCount = 0;
        public int MediaCount = 0;
        public int IntoCount = 0;
        public int FaktaCount = 0;
        public int OivaCount = 0;

        //Värit mitä käytetään kun luokka varataan tai vapautetaan
        SolidColorBrush VarausBrush = new SolidColorBrush(Colors.Red);
        SolidColorBrush VapaaBrush = new SolidColorBrush(Colors.Green);

        public MainWindow()
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

        private void Nappi_painettu(object sender, KeyEventArgs e)
        {
            //Tämän methodin ideana on ottaa kaikista luokista varaus inputit(eli napin painallukset) ja sen mukaan asettaa varaukset ja vapautukset
            //methodin alussa kerrotaan mihin tietokantaan yhteys avataaan
            //yhteys avataan
            //riippuen mitä nappia painetaan niin haetaan sen mukaan luokka ja katsotaan onko se varattu tai ei
            //jos luokka on varattu niin luokka asetetaan vapaaksi ja jos se on vapaana niin se asetetaan varatuksi
            //jokainen komento on sama jokaiselle luokalle ainoa ero on se että jos luokka on varattu niin se asetetaan vapaksi eli 0 ja jos se on varattu niin tilan numeroksi tulee 1
            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");
            con.Open();
            if (e.Key == Key.Space && BittiCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Bitti'", con);
                BittiCount++;
                Bitti.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && BittiCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Bitti'", con);
                BittiCount--;
                Bitti.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Enter && KaneliCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Kaneli'", con);
                KaneliCount++;
                Kaneli.Fill = VarausBrush;
            }
            else if (e.Key == Key.Enter && KaneliCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Kaneli'", con);
                KaneliCount--;
                Kaneli.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Q && StudyOCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'StudyO'", con);
                StudyOCount++;
                StudyO.Fill = VarausBrush;
            }
            else if (e.Key == Key.Q && StudyOCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'StudyO'", con);
                StudyOCount--;
                StudyO.Fill = VapaaBrush;
            }
            else if (e.Key == Key.W && VirnaCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Virna'", con);
                VirnaCount++;
                Virna.Fill = VarausBrush;
            }
            else if (e.Key == Key.W && VirnaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Virna'", con);
                VirnaCount--;
                Virna.Fill = VapaaBrush;
            }
            else if (e.Key == Key.E && VisioCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Visio'", con);
                VisioCount++;
                Visio.Fill = VarausBrush;
            }
            else if (e.Key == Key.E && VisioCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Visio'", con);
                VisioCount--;
                Visio.Fill = VapaaBrush;
            }
            else if (e.Key == Key.R && TuumaCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Tuuma'", con);
                TuumaCount++;
                Tuuma.Fill = VarausBrush;
            }
            else if (e.Key == Key.R && TuumaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tuuma'", con);
                TuumaCount--;
                Tuuma.Fill = VapaaBrush;
            }
            else if (e.Key == Key.T && AmadeusCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Amadeus'", con);
                AmadeusCount++;
                Amadeus.Fill = VarausBrush;
            }
            else if (e.Key == Key.T && AmadeusCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Amadeus'", con);
                AmadeusCount--;
                Amadeus.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Y && ToimiCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Toimi'", con);
                ToimiCount++;
                Toimi.Fill = VarausBrush;
            }
            else if (e.Key == Key.Y && ToimiCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Toimi'", con);
                ToimiCount--;
                Toimi.Fill = VapaaBrush;
            }
            else if (e.Key == Key.U && TaitoCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Taito'", con);
                TaitoCount++;
                Taito.Fill = VarausBrush;
            }
            else if (e.Key == Key.U && TaitoCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Taito'", con);
                TaitoCount--;
                Taito.Fill = VapaaBrush;
            }
            else if (e.Key == Key.A && DigiLuolaCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'DigiLuola'", con);
                DigiLuolaCount++;
                DigiLuola.Fill = VarausBrush;
            }
            else if (e.Key == Key.A && DigiLuolaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'DigiLuola'", con);
                DigiLuolaCount--;
                DigiLuola.Fill = VapaaBrush;
            }
            else if (e.Key == Key.I && VoittoCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Voitto'", con);
                VoittoCount++;
                Voitto.Fill = VarausBrush;
            }
            else if (e.Key == Key.I && VoittoCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Voitto'", con);
                VoittoCount--;
                Voitto.Fill = VapaaBrush;
            }
            else if (e.Key == Key.S && ArvoCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Arvo'", con);
                ArvoCount++;
                Arvo.Fill = VarausBrush;
            }
            else if (e.Key == Key.S && ArvoCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Arvo'", con);
                ArvoCount--;
                Arvo.Fill = VapaaBrush;
            }
            else if (e.Key == Key.D && FiktioCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Fiktio'", con);
                FiktioCount++;
                Fiktio.Fill = VarausBrush;
            }
            else if (e.Key == Key.D && FiktioCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Fiktio'", con);
                FiktioCount--;
                Fiktio.Fill = VapaaBrush;
            }
            else if (e.Key == Key.F && MissioCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Missio'", con);
                MissioCount++;
                Missio.Fill = VarausBrush;
            }
            else if (e.Key == Key.F && MissioCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Missio'", con);
                MissioCount--;
                Missio.Fill = VapaaBrush;
            }
            else if (e.Key == Key.G && IdeaCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Idea'", con);
                IdeaCount++;
                Idea.Fill = VarausBrush;
            }
            else if (e.Key == Key.G && IdeaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Idea'", con);
                IdeaCount--;
                Idea.Fill = VapaaBrush;
            }
            else if (e.Key == Key.H && ImagoCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Imago'", con);
                ImagoCount++;
                Imago.Fill = VarausBrush;
            }
            else if (e.Key == Key.H && ImagoCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Imago'", con);
                ImagoCount--;
                Imago.Fill = VapaaBrush;
            }
            else if (e.Key == Key.J && VolttiCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Voltti'", con);
                VolttiCount++;
                Voltti.Fill = VarausBrush;
            }
            else if (e.Key == Key.J && VolttiCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Voltti'", con);
                VolttiCount--;
                Voltti.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Z && TiliCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Tili'", con);
                TiliCount++;
                Tili.Fill = VarausBrush;
            }
            else if (e.Key == Key.Z && TiliCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tili'", con);
                TiliCount--;
                Tili.Fill = VapaaBrush;
            }
            else if (e.Key == Key.X && TohtoriCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Tohtori'", con);
                TohtoriCount++;
                Tohtori.Fill = VarausBrush;
            }
            else if (e.Key == Key.X && TohtoriCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tohtori'", con);
                TohtoriCount--;
                Tohtori.Fill = VapaaBrush;
            }
            else if (e.Key == Key.C && TietoCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Tieto'", con);
                TietoCount++;
                Tieto.Fill = VarausBrush;
            }
            else if (e.Key == Key.C && TietoCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tieto'", con);
                TietoCount--;
                Tieto.Fill = VapaaBrush;
            }
            else if (e.Key == Key.V && MediaCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Media'", con);
                MediaCount++;
                Media.Fill = VarausBrush;
            }
            else if (e.Key == Key.V && MediaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Media'", con);
                MediaCount--;
                Media.Fill = VapaaBrush;
            }
            else if (e.Key == Key.B && IntoCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Into'", con);
                IntoCount++;
                Into.Fill = VarausBrush;
            }
            else if (e.Key == Key.B && IntoCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Into'", con);
                IntoCount--;
                Into.Fill = VapaaBrush;
            }
            else if (e.Key == Key.N && FaktaCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Fakta'", con);
                FaktaCount++;
                Fakta.Fill = VarausBrush;
            }
            else if (e.Key == Key.N && FaktaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Fakta'", con);
                FaktaCount--;
                Fakta.Fill = VapaaBrush;
            }
            else if (e.Key == Key.M && OivaCount == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Oiva'", con);
                OivaCount++;
                Oiva.Fill = VarausBrush;
            }
            else if (e.Key == Key.M && OivaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Oiva'", con);
                OivaCount--;
                Oiva.Fill = VapaaBrush;
            }
            //tässä kohdassa valittu komento suoritetaan
            //ja sen jälkeen yhteys suljetaan((yhteyksen sulkeminen on sitä varten että kukaan jolla on tietoa sql:stä ei voi suorittaa SQL Injectionia ja päästä käsiksi tietokantaan))
            cmd.ExecuteNonQuery();
            con.Close();
        }

     

        public void Get_Data_SQL()
        {
            //tämän methodin ideana on tarkistaa luokkien varausten tila kun ohjelma käynnistetään tai kun ohjelman tiedot päivitetään(joka 30 sekuntti)
            //methodin alussa asetetaan SqlDataReader funktiolle rdr nimi ja se asetetaan null:iksi koskak un sitä kutsutaan niin sen pitää olla null
            //ja kuten Nappi_painettu methodissa niin kerrotaan mihin tietokantaan ohjelma yhdistaa kun yhteytta avataan
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
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='StudyO'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                StudyOCount = 1;
                StudyO.Fill = VarausBrush;
            }
            else
            {
                StudyOCount = 0;
                StudyO.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Virna'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                VirnaCount = 1;
                Virna.Fill = VarausBrush;
            }
            else
            {
                VirnaCount = 0;
                Virna.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Visio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if((bool)rdr["Is_Varattu"] == true)
            {
                VisioCount = 1;
                Visio.Fill = VarausBrush;
            }else
            {
                VisioCount = 0;
                Visio.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Bitti'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                BittiCount = 1;
                Bitti.Fill = VarausBrush;
            }
            else
            {
                BittiCount = 0;
                Bitti.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Kaneli'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                KaneliCount = 1;
                Kaneli.Fill = VarausBrush;
            }
            else
            {
                KaneliCount = 0;
                Kaneli.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tuuma'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                TuumaCount = 1;
                Tuuma.Fill = VarausBrush;
            }
            else
            {
                TuumaCount = 0;
                Tuuma.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Amadeus'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                AmadeusCount = 1;
                Amadeus.Fill = VarausBrush;
            }
            else
            {
                AmadeusCount = 0;
                Amadeus.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Toimi'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                ToimiCount = 1;
                Toimi.Fill = VarausBrush;
            }
            else
            {
                ToimiCount = 0;
                Toimi.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Taito'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                TaitoCount = 1;
                Taito.Fill = VarausBrush;
            }
            else
            {
                TaitoCount = 0;
                Taito.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='DigiLuola'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                DigiLuolaCount = 1;
                DigiLuola.Fill = VarausBrush;
            }
            else
            {
                DigiLuolaCount = 0;
                DigiLuola.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Voitto'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                VoittoCount = 1;
                Voitto.Fill = VarausBrush;
            }
            else
            {
                VoittoCount = 0;
                Voitto.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Arvo'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                ArvoCount = 1;
                Arvo.Fill = VarausBrush;
            }
            else
            {
                ArvoCount = 0;
                Arvo.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Fiktio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                FiktioCount = 1;
                Fiktio.Fill = VarausBrush;
            }
            else
            {
                FiktioCount = 0;
                Fiktio.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Missio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                MissioCount = 1;
                Missio.Fill = VarausBrush;
            }
            else
            {
                MissioCount = 0;
                Missio.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Idea'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                IdeaCount = 1;
                Idea.Fill = VarausBrush;
            }
            else
            {
                IdeaCount = 0;
                Idea.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Imago'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                ImagoCount = 1;
                Imago.Fill = VarausBrush;
            }
            else
            {
                ImagoCount = 0;
                Imago.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Voltti'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                VolttiCount = 1;
                Voltti.Fill = VarausBrush;
            }
            else
            {
                VolttiCount = 0;
                Voltti.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tili'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                TiliCount = 1;
                Tili.Fill = VarausBrush;
            }
            else
            {
                TiliCount = 0;
                Tili.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tohtori'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                TohtoriCount = 1;
                Tohtori.Fill = VarausBrush;
            }
            else
            {
                TohtoriCount = 0;
                Tohtori.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tieto'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                TietoCount = 1;
                Tieto.Fill = VarausBrush;
            }
            else
            {
                TietoCount = 0;
                Tieto.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Media'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                MediaCount = 1;
                Media.Fill = VarausBrush;
            }
            else
            {
                MediaCount = 0;
                Media.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Into'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                IntoCount = 1;
                Into.Fill = VarausBrush;
            }
            else
            {
                IntoCount = 0;
                Into.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Fakta'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                FaktaCount = 1;
                Fakta.Fill = VarausBrush;
            }
            else
            {
                FaktaCount = 0;
                Fakta.Fill = VapaaBrush;
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Oiva'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true)
            {
                OivaCount = 1;
                Oiva.Fill = VarausBrush;
            }
            else
            {
                OivaCount = 0;
                Oiva.Fill = VapaaBrush;
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


        // Buttonit kerroksen näkymä vaihtelulle
        private void KolmasKerros_btn_Click(object sender, RoutedEventArgs e)
        {
            KolmasKerros KolmasKerros = new KolmasKerros();
            KolmasKerros.ShowDialog();

            //Actions

            KolmasKerros.Close();
        }

        private void KellariKerros_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
