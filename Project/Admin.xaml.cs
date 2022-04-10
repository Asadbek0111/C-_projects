using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace Project
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        SqlConnection con;
        String database;

        public Admin()
        {
            InitializeComponent();
            database = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\b2005081\Desktop\Project\Project\Bookstore.mdf;Integrated Security=True";
            con = new SqlConnection(database);
            con.ConnectionString = database;
            con.Open();
            load_data();
        }

        private void AddStaff_Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Add_Staff.Visibility = Visibility.Visible;
            View_Staff.Visibility = Visibility.Hidden;
        }

        private void ViewAll_Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View_Staff.Visibility = Visibility.Visible;
            Add_Staff.Visibility = Visibility.Hidden;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public void load_data()
        {
            String query = "SELECT * FROM Staff";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dategredview1.ItemsSource = dt.DefaultView;
        }

        private void dategredview1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            String staffid = ((DataRowView)dategredview1.SelectedItem).Row[0].ToString();
            String password = ((DataRowView)dategredview1.SelectedItem).Row[1].ToString();
            String role = ((DataRowView)dategredview1.SelectedItem).Row[3].ToString();

            sid.Text = staffid;
            spassword.Text = password;
            srole.Text = role;

           // MessageBox.Show(""+staffid);
        }
    }
}
