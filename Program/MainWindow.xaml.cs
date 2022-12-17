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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
