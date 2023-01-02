using Oracle.ManagedDataAccess.Client;
using Program.Model;

namespace Program.ViewModel
{
    public class DataBaseCorrector
    {
        private static readonly string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64533;password=skladPass;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

        private OracleConnection _con { get; set; } = new OracleConnection(constr);

        public void CorrectUsers(User user)
        {
            _con.Open();
            string insertSql = "INSERT INTO USERS (id_user, user_name, password) VALUES (:val1, :val2, :val3)";
            using (OracleCommand cmd = new OracleCommand(insertSql, _con))
            {
                cmd.Parameters.Add(new OracleParameter(":val1", 2));
                cmd.Parameters.Add(new OracleParameter(":val2", user.Email));
                cmd.Parameters.Add(new OracleParameter(":val3", user.Password));

                cmd.ExecuteNonQuery();
            }
            _con.Close();
        }
    }
}
