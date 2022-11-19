using semestralniPraceVezerianPeresta.ViewModel;
using System;
using System.Windows;

namespace semestralniPraceVezerianPeresta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBaseCorrector dataBaseCorrector = new DataBaseCorrector();
            if (dataBaseCorrector.Connect())
            {
                MessageBox.Show("Connection Open ! ");
            }
            else
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void Button_Exit(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button_Guest(object sender, EventArgs e)
        {

        }
        private void Button_SignUp(object sender, EventArgs e)
        {

        }
        private void Button_SignIn(object sender, EventArgs e)
        {

        }
        private void Button_Password(object sender, EventArgs e)
        {
        }

        private void Button_Email(object sender, EventArgs e)
        {

        }
    }
        
}
