using Oracle.ManagedDataAccess.Client;
using Program.Model;

namespace Program.ViewModel
{
    public class DataBaseCorrector
    {
        private readonly string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA=(SID=BDAS)));" +
                        "user id=st64533;password=skladPass;" +
                        "Connection Timeout=120;Validate connection=true;Min Pool Size=4;";

        private OracleConnection _con { get; set; } 

        public void AddUser(User user)
        {
            _con = new OracleConnection(constr);
            _con.Open();
            string insertSql = "INSERT INTO USERS (id_user, user_name, password) VALUES (:val1, :val2, :val3)";
            using (OracleCommand cmd = new OracleCommand(insertSql, _con))
            {
                cmd.Parameters.Add(new OracleParameter(":val1", 3));
                cmd.Parameters.Add(new OracleParameter(":val2", user.Email));
                cmd.Parameters.Add(new OracleParameter(":val3", user.Password));

                cmd.ExecuteNonQuery();
            }
            _con.Close();
        }

        public bool UserExist(User user, ref bool isMeilProblem)
        {
            _con = new OracleConnection(constr);
            _con.Open();
            string selectSql = "SELECT 1 FROM USERS WHERE user_name = :email";
            using (OracleCommand cmd = new OracleCommand(selectSql, _con))
            {
                cmd.Parameters.Add(new OracleParameter(":user_name", user.Email));

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // Email exists, check password
                    selectSql = "SELECT 1 FROM USERS WHERE user_name = :user_name AND password = :password";

                    cmd.CommandText = selectSql;
                    cmd.Parameters.Add(new OracleParameter(":user_name", user.Password));

                    result = cmd.ExecuteScalar();

                    _con.Close();
                    return result != null;
                }
                else
                {
                    _con.Close();
                    isMeilProblem = true;
                    return false;
                }

            }
        }

        /*public bool DoesLineInTableExist(string line)
        {
            _con = new OracleConnection(constr);
            _con.Open();ф
            string insertSql = $"SELECT 1 FROM Table WHERE {line} = :{line}";
            using (OracleCommand cmd = new OracleCommand(insertSql, _con))
            {
                cmd.Parameters.Add(new OracleParameter($":{line}", line));

                object result = cmd.ExecuteScalar();
                _con.Close();
                return result != null;
            }

        }*/
    }
}
