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

namespace ToinenNakyma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Get_Data_SQL();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            //tätä methodia käytetään päivittämään tietoja ja tätä kutsutaan kun timerista loppuu aika ja aloitetaan uusi timer
            void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Luokien_Vaihto();
                    Number_Reset();
                }));
            }
        }

        public SqlConnection con;
        public SqlCommand cmd;

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
        public int PelastusCount = 0;
        public int SiivoCount = 0;
        public int VirtaCount = 0;
        public int TehoCount = 0;
        public int DiiliCount = 0;
        public int KVCount = 0;
        public int PKCount = 0;
        public int TKCount = 0;
        public int HaikuCount = 0;
        public int MainioCount = 0;

        public int LuokkaNumero = 0;

        SolidColorBrush VarausBrush = new SolidColorBrush(Colors.Red);
        SolidColorBrush VapaaBrush = new SolidColorBrush(Colors.Green);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //avataan yhteys tietokantaan
            //skripti katossoo onko varaus nappia painettu vai ei ja mikä luokka numero on tällä hetkellä käytöss
            //luokat näytetään numeroina jotta neiitä voidaan käyttää if lausekkeissa booleanien kanssa
            //jos luokka on varattu niin luokka asetetaan vapaaksi ja jos se on vapaana niin se asetetaan varatuksi
            //jokainen komento on sama jokaiselle luokalle ainoa ero on se että jos luokka on varattu niin se asetetaan vapaksi eli 0 ja jos se on varattu niin tilan numeroksi tulee 1

            //tämä on tiimin oma sql addressi jos käytätte samalla taval tiedon hakua niin asettakaa oman sql servun addressi
            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");
            con.Open();
            if (AmadeusCount == 0 && LuokkaNumero == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Amadeus'", con);
                AmadeusCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (AmadeusCount == 1 && LuokkaNumero == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Amadeus'", con);
                AmadeusCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (ArvoCount == 0 && LuokkaNumero == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Arvo'", con);
                ArvoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (ArvoCount == 1 && LuokkaNumero == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Arvo'", con);
                ArvoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (BittiCount == 0 && LuokkaNumero == 2)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Bitti'", con);
                BittiCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (BittiCount == 1 && LuokkaNumero == 2)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Bitti'", con);
                BittiCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (DigiLuolaCount == 0 && LuokkaNumero == 3)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'DigiLuola'", con);
                DigiLuolaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (DigiLuolaCount == 1 && LuokkaNumero == 3)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'DigiLuola'", con);
                DigiLuolaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (DiiliCount == 0 && LuokkaNumero == 4)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Diili'", con);
                DiiliCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (DiiliCount == 1 && LuokkaNumero == 4)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Diili'", con);
                DiiliCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (FaktaCount == 0 && LuokkaNumero == 5)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Fakta'", con);
                FaktaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (FaktaCount == 1 && LuokkaNumero == 5)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Fakta'", con);
                FaktaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (FiktioCount == 0 && LuokkaNumero == 6)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Fiktio'", con);
                FiktioCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (FiktioCount == 1 && LuokkaNumero == 6)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Fiktio'", con);
                FiktioCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (HaikuCount == 0 && LuokkaNumero == 7)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Haiku'", con);
                HaikuCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (HaikuCount == 1 && LuokkaNumero == 7)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Haiku'", con);
                HaikuCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (IdeaCount == 0 && LuokkaNumero == 8)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Idea'", con);
                IdeaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (IdeaCount == 1 && LuokkaNumero == 8)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Idea'", con);
                IdeaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (ImagoCount == 0 && LuokkaNumero == 9)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Imago'", con);
                ImagoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (ImagoCount == 1 && LuokkaNumero == 9)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Imago'", con);
                ImagoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (IntoCount == 0 && LuokkaNumero == 10)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Into'", con);
                IntoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (IntoCount == 1 && LuokkaNumero == 10)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Into'", con);
                IntoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (KaneliCount == 0 && LuokkaNumero == 11)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Kaneli'", con);
                KaneliCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (KaneliCount == 1 && LuokkaNumero == 11)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Kaneli'", con);
                KaneliCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (KVCount == 0 && LuokkaNumero == 12)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Kaupingin_Vallot'", con);
                KVCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (KVCount == 1 && LuokkaNumero == 12)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Kaupingin_Vallot'", con);
                KVCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (MainioCount == 0 && LuokkaNumero == 13)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Mainio'", con);
                MainioCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (MainioCount == 1 && LuokkaNumero == 13)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Mainio'", con);
                MainioCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (MediaCount == 0 && LuokkaNumero == 14)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Media'", con);
                MediaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (MediaCount == 1 && LuokkaNumero == 14)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Media'", con);
                MediaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (MissioCount == 0 && LuokkaNumero == 15)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Missio'", con);
                MissioCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (MissioCount == 1 && LuokkaNumero == 15)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Missio'", con);
                MissioCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (OivaCount == 0 && LuokkaNumero == 16)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Oiva'", con);
                OivaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (OivaCount == 1 && LuokkaNumero == 16)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Oiva'", con);
                OivaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            else if (PKCount == 0 && LuokkaNumero == 17)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Päivien_Kimallus'", con);
                PKCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (PKCount == 1 && LuokkaNumero == 17)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Päivien_Kimallus'", con);
                PKCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (PelastusCount == 0 && LuokkaNumero == 18)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Pelastus'", con);
                PelastusCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (PelastusCount == 1 && LuokkaNumero == 18)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Pelastus'", con);
                PelastusCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (SiivoCount == 0 && LuokkaNumero == 19)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Siivo'", con);
                SiivoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (SiivoCount == 1 && LuokkaNumero == 19)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Siivo'", con);
                SiivoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (StudyOCount == 0 && LuokkaNumero == 20)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'StudyO'", con);
                StudyOCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (StudyOCount == 1 && LuokkaNumero == 20)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'StudyO'", con);
                StudyOCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (TaitoCount == 0 && LuokkaNumero == 21)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Taito'", con);
                TaitoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (TaitoCount == 1 && LuokkaNumero == 21)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Taito'", con);
                TaitoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (TehoCount == 0 && LuokkaNumero == 22)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Teho'", con);
                TehoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (TehoCount == 1 && LuokkaNumero == 22)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Teho'", con);
                TehoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (TietoCount == 0 && LuokkaNumero == 23)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tieto'", con);
                TietoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (TietoCount == 1 && LuokkaNumero == 23)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tieto'", con);
                TietoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (TiliCount == 0 && LuokkaNumero == 24)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tili'", con);
                TiliCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (TiliCount == 1 && LuokkaNumero == 24)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tili'", con);
                TiliCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (TohtoriCount == 0 && LuokkaNumero == 25)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tohtori'", con);
                TohtoriCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (TohtoriCount == 1 && LuokkaNumero == 25)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tohtori'", con);
                TohtoriCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (ToimiCount == 0 && LuokkaNumero == 26)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Toimi'", con);
                ToimiCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (ToimiCount == 1 && LuokkaNumero == 26)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Toimi'", con);
                ToimiCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (TKCount == 0 && LuokkaNumero == 27)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tsaarin_Kuriiri'", con);
                TKCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (TKCount == 1 && LuokkaNumero == 27)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tsaarin_Kuriiri'", con);
                TKCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (TuumaCount == 0 && LuokkaNumero == 28)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tuuma'", con);
                TuumaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (TuumaCount == 1 && LuokkaNumero == 28)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Tuuma'", con);
                TuumaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (VirnaCount == 0 && LuokkaNumero == 29)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Virna'", con);
                VirnaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (VirnaCount == 1 && LuokkaNumero == 29)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Virna'", con);
                VirnaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (VirtaCount == 0 && LuokkaNumero == 30)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Virta'", con);
                VirtaCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (VirtaCount == 1 && LuokkaNumero == 30)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Virta'", con);
                VirtaCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (VisioCount == 0 && LuokkaNumero == 31)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Visio'", con);
                VisioCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (VisioCount == 1 && LuokkaNumero == 31)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Visio'", con);
                VisioCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (VoittoCount == 0 && LuokkaNumero == 32)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Voitto'", con);
                VoittoCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (VoittoCount == 1 && LuokkaNumero == 32)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Voitto'", con);
                VoittoCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }

            else if (VolttiCount == 0 && LuokkaNumero == 33)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Voltti'", con);
                VolttiCount++;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if (VolttiCount == 1 && LuokkaNumero == 33)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Voltti'", con);
                VolttiCount--;

                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            cmd.ExecuteNonQuery();
            con.Close();
            //komento suorittetaan
            //ja yhteys suljetaan
        }

        private void Luokien_Vaihto()
        {
            //riippuen mikä numero on niin luokkan nimi näytetään varaus näkymässä
            //numero vaihtuu kun nappieja painetaan
            if(LuokkaNumero == 0)
            {
                VaratttavaLuokkaTxt.Text = "Amadeus";
            }
            else if (LuokkaNumero == 1)
            {
                VaratttavaLuokkaTxt.Text = "Arvo";
            }
            else if (LuokkaNumero == 2)
            {
                VaratttavaLuokkaTxt.Text = "Bitti";
            }
            else if (LuokkaNumero == 3)
            {
                VaratttavaLuokkaTxt.Text = "DigiLuola";
            }
            else if (LuokkaNumero == 4)
            {
                VaratttavaLuokkaTxt.Text = "Diili";
            }
            else if (LuokkaNumero == 5)
            {
                VaratttavaLuokkaTxt.Text = "Fakta";
            }
            else if (LuokkaNumero == 6)
            {
                VaratttavaLuokkaTxt.Text = "Fiktio";
            }
            else if (LuokkaNumero == 7)
            {
                VaratttavaLuokkaTxt.Text = "Haiku";
            }
            else if (LuokkaNumero == 8)
            {
                VaratttavaLuokkaTxt.Text = "Idea";
            }
            else if (LuokkaNumero == 9)
            {
                VaratttavaLuokkaTxt.Text = "Imago";
            }
            else if (LuokkaNumero == 10)
            {
                VaratttavaLuokkaTxt.Text = "Into";
            }
            else if (LuokkaNumero == 11)
            {
                VaratttavaLuokkaTxt.Text = "Kaneli";
            }
            else if (LuokkaNumero == 12)
            {
                VaratttavaLuokkaTxt.Text = "Kaupingin_Vallot";
            }
            else if (LuokkaNumero == 13)
            {
                VaratttavaLuokkaTxt.Text = "Mainio";
            }
            else if (LuokkaNumero == 14)
            {
                VaratttavaLuokkaTxt.Text = "Media";
            }
            else if (LuokkaNumero == 15)
            {
                VaratttavaLuokkaTxt.Text = "Missio";
            }
            else if (LuokkaNumero == 16)
            {
                VaratttavaLuokkaTxt.Text = "Oiva";
            }
            else if (LuokkaNumero == 17)
            {
                VaratttavaLuokkaTxt.Text = "Päivien_Kimallus";
            }
            else if (LuokkaNumero == 18)
            {
                VaratttavaLuokkaTxt.Text = "Pelastus";
            }
            else if (LuokkaNumero == 19)
            {
                VaratttavaLuokkaTxt.Text = "Siivo";
            }
            else if (LuokkaNumero == 20)
            {
                VaratttavaLuokkaTxt.Text = "StudyO";
            }
            else if (LuokkaNumero == 21)
            {
                VaratttavaLuokkaTxt.Text = "Taito";
            }
            else if (LuokkaNumero == 22)
            {
                VaratttavaLuokkaTxt.Text = "Teho";
            }
            else if (LuokkaNumero == 23)
            {
                VaratttavaLuokkaTxt.Text = "Tieto";
            }
            else if (LuokkaNumero == 24)
            {
                VaratttavaLuokkaTxt.Text = "Tili";
            }
            else if (LuokkaNumero == 25)
            {
                VaratttavaLuokkaTxt.Text = "Tohtori";
            }
            else if (LuokkaNumero == 26)
            {
                VaratttavaLuokkaTxt.Text = "Toimi";
            }
            else if (LuokkaNumero == 27)
            {
                VaratttavaLuokkaTxt.Text = "Tsaarin_Kuriiri";
            }
            else if (LuokkaNumero == 28)
            {
                VaratttavaLuokkaTxt.Text = "Tuuma";
            }
            else if (LuokkaNumero == 29)
            {
                VaratttavaLuokkaTxt.Text = "Virna";
            }
            else if (LuokkaNumero == 30)
            {
                VaratttavaLuokkaTxt.Text = "Virta";
            }
            else if (LuokkaNumero == 31)
            {
                VaratttavaLuokkaTxt.Text = "Visio";
            }
            else if (LuokkaNumero == 32)
            {
                VaratttavaLuokkaTxt.Text = "Voitto";
            }
            else if (LuokkaNumero == 33)
            {
                VaratttavaLuokkaTxt.Text = "Voltti";
            }
        }

        public void Number_Reset()
        {
            if(LuokkaNumero == -1)
            {
                LuokkaNumero = 34;
            }
            else if(LuokkaNumero == 35)
            {
                LuokkaNumero = 0;
            }
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            //vaihtaa luokkia
            LuokkaNumero--;
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            //vaihtaa luokkia
            LuokkaNumero++;
        }

        public void Get_Data_SQL()
        {

            //tämän methodin ideana on tarkistaa luokkien varausten tila kun ohjelma käynnistetään tai kun ohjelman tiedot päivitetään(joka 30 sekuntti)
            //methodin alussa asetetaan SqlDataReader funktiolle rdr nimi ja se asetetaan null:iksi koskak un sitä kutsutaan niin sen pitää olla null
            //ja kuten Nappi_painettu methodissa niin kerrotaan mihin tietokantaan ohjelma yhdistaa kun yhteytta avataan
            SqlDataReader rdr = null;
            //tämä on tiimin oma sql addressi jos käytätte samalla taval tiedon hakua niin asettakaa oman sql servun addressi
            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");

            //yhteys avataan
            //asetetaan mitä komento tekee kun sitä käytetään (komento hakee Is_Varattu sarakkeen tietokannasta)
            //komento satetaan texti muotoon jotta SqlDataReader pystyy lukemaan sen
            //komento suoritetaan ja sen jälkeen rdr lukee mitä se on löytänyt
            //jos rdr löytää että Is_Varattu on true(eli siis varatttu) niin asetetaan luokkka varatuksi(1) ja väriksi laitetaan VarausBrush(Punainen)
            //jos rdr löytää että Is_Varattu on False(eli siis vapaa) niin aseteaan luokkka vapaaksi(0) ja väriksi VapaaBrush(Vihreä)
            //ja lopussa suljetaan yhteys tietokantaan(yhteyksen sulkeminen on sitä varten että kukaan jolla on tietoa sql:stä ei voi suorittaa SQL Injectionia ja päästä käsiksi tietokantaan)
            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Amadeus'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 0)
            {
                AmadeusCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 0)
            {
                AmadeusCount = 0;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "vapauta";
                Varaus_nappi.Content = "Varattu";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Arvo'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 1)
            {
                ArvoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 1)
            {
                ArvoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Bitti'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 2)
            {
                BittiCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 2)
            {
                BittiCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='DigiLuola'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 3)
            {
                DigiLuolaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 3)
            {
                DigiLuolaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Diili'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 4)
            {
                DiiliCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 4)
            {
                DiiliCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Fakta'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 5)
            {
                FaktaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 5)
            {
                FaktaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Fiktio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 6)
            {
                FiktioCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 6)
            {
                FiktioCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Haiku'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 7)
            {
                HaikuCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 7)
            {
                HaikuCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Idea'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 8)
            {
                IdeaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 8)
            {
                IdeaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Imago'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 9)
            {
                ImagoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 9)
            {
                ImagoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Into'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 10)
            {
                IntoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 10)
            {
                IntoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Kaneli'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 11)
            {
                KaneliCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 11)
            {
                KaneliCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Kaupingin_Vallot'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 12)
            {
                KVCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 12)
            {
                KVCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Mainio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 13)
            {
                MainioCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 13)
            {
                MainioCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Media'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 14)
            {
                MediaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 14)
            {
                MediaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Missio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 15)
            {
                MissioCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 15)
            {
                MissioCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Oiva'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 16)
            {
                OivaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 16)
            {
                OivaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Päivien_Kimallus'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 17)
            {
                PKCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 17)
            {
                PKCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Pelastus'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 18)
            {
                PelastusCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 18)
            {
                PelastusCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Siivo'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 19)
            {
                SiivoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 19)
            {
                SiivoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='StudyO'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 20)
            {
                StudyOCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 20)
            {
                StudyOCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Taito'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 21)
            {
                TaitoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 21)
            {
                TaitoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Teho'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 22)
            {
                TehoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 22)
            {
                TehoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tieto'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 23)
            {
                TietoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 23)
            {
                TietoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tili'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 24)
            {
                TiliCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 24)
            {
                TiliCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tohtori'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 25)
            {
                TohtoriCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 25)
            {
                TohtoriCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Toimi'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 26)
            {
                ToimiCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 26)
            {
                ToimiCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tsaarin_Kuriiri'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 27)
            {
                TKCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 27)
            {
                TKCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Tuuma'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 28)
            {
                TuumaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 28)
            {
                TuumaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Virna'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 29)
            {
                VirnaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 29)
            {
                VirnaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Virta'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 30)
            {
                VirtaCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 30)
            {
                VirtaCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Visio'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 31)
            {
                VisioCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 31)
            {
                VisioCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();


            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Voitto'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 32)
            {
                VoittoCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 32)
            {
                VoittoCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();

            con.Open();
            cmd = new SqlCommand("Select Is_Varattu from Luokat Where LuokkaNimi ='Voltti'", con);
            cmd.CommandType = System.Data.CommandType.Text;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if ((bool)rdr["Is_Varattu"] == true && LuokkaNumero == 33)
            {
                VolttiCount = 1;
                Varattu_rct.Fill = VarausBrush;

                VarausSts_Txtblk.Text = "Varattu";
                Varaus_nappi.Content = "Vapauta";
            }
            else if ((bool)rdr["Is_Varattu"] == false && LuokkaNumero == 33)
            {
                VolttiCount = 0;
                Varattu_rct.Fill = VapaaBrush;

                VarausSts_Txtblk.Text = "Vapaa";
                Varaus_nappi.Content = "Varaa";
            }
            con.Close();
        }

        private void VaratttavaLuokkaTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ainakun teksti vaihtuu niin tarkisteaan onko luokka johon teksti vaihtui varattu
            Get_Data_SQL();
        }
    }
}
