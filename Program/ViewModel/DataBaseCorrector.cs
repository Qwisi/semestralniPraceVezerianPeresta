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
                cmd.Parameters.Add(new OracleParameter(":val1", 1));
                cmd.Parameters.Add(new OracleParameter(":val2", user.Email));
                cmd.Parameters.Add(new OracleParameter(":val3", user.Password));

                cmd.ExecuteNonQuery();
            }
            _con.Close();
        }

        public bool UserExist(User user, ref bool isMeilProblem)
        {
            if(LineInTableExist("Users", "user_name", user.Email))
            {
                return LineInTableExist("Users", "password", user.Password);
            }
            else
            {
                isMeilProblem = true;
                return false;
            }
        }

        public bool LineInTableExist(string table, string attribute, string line)
        {
            _con = new OracleConnection(constr);
            _con.Open(); 
            string insertSql = $"SELECT 1 FROM {table.ToUpper()} WHERE {attribute} = :{attribute}";
            using (OracleCommand cmd = new OracleCommand(insertSql, _con))
            {
                cmd.Parameters.Add(new OracleParameter($":{attribute}", line));

                object result = cmd.ExecuteScalar();
                _con.Close();
                return result != null;
            }
        }
    }
}
