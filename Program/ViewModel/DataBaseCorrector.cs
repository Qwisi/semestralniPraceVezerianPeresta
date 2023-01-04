using Oracle.ManagedDataAccess.Client;
using Program.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

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
            if(LineInTableExist(TablesEnum.USER, "user_name", user.Email))
            {
                return LineInTableExist(TablesEnum.USER, "password", user.Password);
            }
            else
            {
                isMeilProblem = true;
                return false;
            }
        }

        public bool LineInTableExist(TablesEnum table, string attribute, string line)
        {
            _con = new OracleConnection(constr);
            _con.Open(); 
            string queryString = $"SELECT 1 FROM {GetEnumDescription(TablesEnum.USER)} WHERE {attribute} = :{attribute}";
            using (OracleCommand cmd = new OracleCommand(queryString, _con))
            {
                cmd.Parameters.Add(new OracleParameter($":{attribute}", line));

                object result = cmd.ExecuteScalar();
                _con.Close();
                return result != null;
            }
        }

        public ObservableCollection<Goods> GetTable(TablesEnum table)
        {
            OracleDataReader reader = GetDataReader(table);
            ObservableCollection<Goods> someList = new ObservableCollection<Goods>();
            switch (table)
            {
                case TablesEnum.ADRESS:
                    //someList = new ObservableCollection<Adress>();
                    /*while (reader.Read())
                    {
                        someList.Add(new Adress(
                            reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.CARD:
                    //someList = new ObservableCollection<Card>();
                    /*while (reader.Read())
                    {
                        someList.Add(new Card(PaymentsEnum.CARD, reader.GetString(1)));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.GOODS:
                    //someList = new ObservableCollection<Goods>();
                    while (reader.Read())
                    {
                        someList.Add(new Goods(
                            reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4)));
                    }
                    _con.Close();
                    return someList;
                case TablesEnum.INSURANCE:
                    //someList = new ObservableCollection<Insurance>();
                    /*while (reader.Read())
                    {
                        someList.Add(new Insurance(
                            reader.GetString(1), reader.GetString(2)));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.PAYMENT:
                    //someList = new ObservableCollection<Payment>();
                    /*while (reader.Read())
                    {
                        someList.Add(new Payment(GetStringDescription(reader.GetString(1))));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.STORAGE:
                    //someList = new ObservableCollection<Storage>();
                    /*while (reader.Read())
                    {
                        someList.Add(new Storage(reader.GetString(1), reader.GetString(2)));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.USER:
                    //someList = new ObservableCollection<User>();
                    /*while (reader.Read())
                    {
                        someList.Add(new User(reader.GetString(1), reader.GetString(2)));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.WORKER:
                    //someList = new ObservableCollection<Worker>();
                    /*while (reader.Read())
                    {
                        someList.Add(new Worker(
                            reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.WORK_POSITION:
                    //someList = new ObservableCollection<WorkPosition>();
                    /*while (reader.Read())
                    {
                        someList.Add(new WorkPosition(reader.GetString(1), reader.GetInt32(2)));
                    }
                    _con.Close();*/
                    return someList;
                case TablesEnum.CLIENT:
                    //someList = new ObservableCollection<Сlient>();
                    /*while (reader.Read())
                    {
                        someList.Add(new Сlient(
                            reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                    }
                    _con.Close();*/
                    return someList;
            }
            return null;
        }

        private OracleDataReader GetDataReader(TablesEnum table)
        {
            _con = new OracleConnection(constr);
            _con.Open();
            string queryString = $"SELECT * FROM {GetEnumDescription(table)}";
            using (OracleCommand cmd = new OracleCommand(queryString, _con))
            {
                OracleDataReader reader = cmd.ExecuteReader();
                return reader;
            }
        }



        public static PaymentsEnum GetStringDescription(string value)
        {
            return (PaymentsEnum)Enum.Parse(typeof(PaymentsEnum), value, true);
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
