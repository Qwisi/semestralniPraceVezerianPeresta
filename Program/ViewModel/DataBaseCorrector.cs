using Microsoft.Data.SqlClient;
using System;

namespace semestralniPraceVezerianPeresta.ViewModel
{
    internal class DataBaseCorrector
    {
        private string data_Source = "Data Source=fei-sql1.upceucebny.cz;";
        private string initial_Catalog = "Initial Catalog=st64165;";
        private string user_ID = "User ID=st64165;";
        private string password = "Password=nemocnicePass";

        public bool Connect()
        {
            /*using (SqlConnection connection = new SqlConnection(data_Source + initial_Catalog + user_ID + password))
            {
                connection.Open();
            }*/
            SqlConnection connection = new SqlConnection(data_Source + initial_Catalog + user_ID + password);
            try
            {
                connection.Open();
                connection.Close(); 
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
