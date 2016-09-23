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
using System.Data;


namespace ProjetoEstacionamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string type;



        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Cristiano\Documents\Visual Studio 2015\Projects\ProjetoEstacionamento\ProjetoEstacionamento\LOGIN.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login where Username='" + Usuariotxt.Text + "' and Password ='" + Senhatxt.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("Select Count(*) From Login where Username='" + Usuariotxt.Text + "' and Password ='" + Senhatxt.Text + "'", con);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                if (dt.Rows[0][0].ToString() == "A")
                {
                    this.Hide();



                    Administrador adminform = new Administrador();
                    adminform.Show();
                }
                if (dt.Rows[0][0].ToString() == "B")
                {
                    this.Hide();




                    Funcionario adminform = new Funcionario();
                    adminform.Show();
                }
            }
            else
            {
                MessageBox.Show("Confira seu Usuario ou Senha");
            }


        }
    }
}

