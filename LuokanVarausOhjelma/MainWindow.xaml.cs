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

namespace LuokanVarausOhjelma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection con;
        private SqlCommand cmd;
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

        SolidColorBrush VarausBrush = new SolidColorBrush(Colors.Red);
        SolidColorBrush VapaaBrush = new SolidColorBrush(Colors.Green);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fakta_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("XD TOIMII LOL");
        }

        /*private void Kaneli_Click(object sender, RoutedEventArgs e)
        {

            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");
            con.Open();
            if (KaneliCount == 0)
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=1 WHERE LuokkaId=6", con);
                cmd = new SqlCommand ("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Kaneli'", con);
                KaneliCount++;
                Kaneli.Fill = VarausBrush;
            }else
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=0 WHERE LuokkaId=6", con);
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Kaneli'", con);
                KaneliCount--;
                Kaneli.Fill = VapaaBrush;
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }*/


        private void Nappi_painettu(object sender, KeyEventArgs e)
        {
            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");
            con.Open();
            /*if (e.Key != Key.Space && e.Key != Key.Enter)
            {
                MessageBox.Show("unassigned button pressed");
            }*/
            if (e.Key == Key.Space && BittiCount == 0)
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=1 WHERE LuokkaId=6", con);
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Bitti'", con);
                BittiCount++;
                Bitti.Fill = VarausBrush;
            }
            else if (e.Key == Key.Space && BittiCount == 1)
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=0 WHERE LuokkaId=6", con);
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Bitti'", con);
                BittiCount--;
                Bitti.Fill = VapaaBrush;
            }
            else if (e.Key == Key.Enter && KaneliCount == 0)
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=0 WHERE LuokkaId=6", con);
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Kaneli'", con);
                KaneliCount++;
                Kaneli.Fill = VarausBrush;
            }
            else if (e.Key == Key.Enter && KaneliCount == 1)
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=0 WHERE LuokkaId=6", con);
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
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Vima'", con);
                VirnaCount++;
                Virna.Fill = VarausBrush;
            }
            else if (e.Key == Key.W && VirnaCount == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Vima'", con);
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

            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
