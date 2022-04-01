﻿using System;
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


namespace LuokanVarausOhjelma
{
    /// <summary>
    /// Interaction logic for Class_nappi_näkymä.xaml
    /// </summary>
    public partial class Class_nappi_näkymä : Window
    {

        public SqlConnection con;
        public SqlCommand cmd;

        public int Varaus = 0;


       

        public Class_nappi_näkymä()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            con = new SqlConnection(@"Data Source = teamempiresrv.database.windows.net; Initial Catalog = LuokkaVaraus; Persist Security Info = True; User ID = Empire; Password = Nice1234");
            con.Open();
            if (Varaus == 0)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=1 WHERE LuokkaNimi= 'Bitti'", con);
                Varaus++;
                
            }
            else if (Varaus == 1)
            {
                cmd = new SqlCommand("UPDATE Luokat Set Is_Varattu=0 WHERE LuokkaNimi= 'Bitti'", con);
                Varaus--;
              
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
