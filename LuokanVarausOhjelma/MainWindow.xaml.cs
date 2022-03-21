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
        public int count = 0;

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

        private void Kaneli_Click(object sender, RoutedEventArgs e)
        {

            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");
            con.Open();
            if (count == 0)
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=1 WHERE LuokkaId=6", con);
                cmd = new SqlCommand ("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNImi= 'Kaneli'", con);
                count++;
                Kaneli.Fill = VarausBrush;
            }else
            {
                //cmd = new SqlCommand("UPDATE Luokat SET Is_Varattu=0 WHERE LuokkaId=6", con);
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNImi= 'Kaneli'", con);
                count--;
                Kaneli.Fill = VapaaBrush;
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
