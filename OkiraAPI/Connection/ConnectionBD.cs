using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OkiraAPI.Connection
{
    public class ConnectionBD
    {
        public MySqlConnection connection;
        public MySqlCommand command;
        public MySqlTransaction transaction;
        private string server;
        private string database;
        private string uid;
        private string password;
        string port;

        public ConnectionBD()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "mysql5022.site4now.net";
            uid = "a648a5_okira";
            password = "okira2020";
            database = "db_a648a5_okira";

            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password;

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();


                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //      MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //       MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            connection.Close();
            return true;
        }

        //Insert statement
        public int InsertOrUpdate(string query, Dictionary<string, string> param, int id)
        {
            int t = 0;
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (param != null)
                {
                    foreach (KeyValuePair<string, string> entry in param)
                    {
                        cmd.Parameters.Add(new MySqlParameter(entry.Key, entry.Value));
                    }
                }
                cmd.ExecuteNonQuery();
                //si insertion reussit
                if (id == 0)
                    t = (int)cmd.LastInsertedId;
                else
                    t = id;
            }
            CloseConnection();
            return t;
        }

        public int InsertOrUpdate(string query, Dictionary<string, string> param)
        {
            int t = 0;
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                if (param != null)
                {
                    foreach (KeyValuePair<string, string> entry in param)
                    {
                        cmd.Parameters.Add(new MySqlParameter(entry.Key, entry.Value));
                    }
                }
                cmd.ExecuteNonQuery();
                //si insertion reussit
                t = (int)cmd.LastInsertedId;
            }
            CloseConnection();

            //si insertion echoue
            return t;
        }

        //Update statement
        public int Update(string query, Dictionary<string, string> param, int id = 0)
        {
            int t = 0;
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                foreach (KeyValuePair<string, string> entry in param)
                {
                    cmd.Parameters.Add(new MySqlParameter(entry.Key, entry.Value));
                }

                //si insertion reussit
                if (cmd.ExecuteNonQuery() > 0)
                    t = id;
            }

            //si insertion echoue
            return t;
        }

        //Delete statement
        public int Delete(string query, Dictionary<string, string> param)
        {
            int retour = 0;
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                foreach (KeyValuePair<string, string> entry in param)
                {
                    cmd.Parameters.Add(new MySqlParameter(entry.Key, entry.Value));
                }
                retour = cmd.ExecuteNonQuery();
                //si insertion reussit
            }
            CloseConnection();

            return retour;
        }

        //Select statement
        public MySqlDataReader Select(string query, Dictionary<string, string> param = null)
        {

            MySqlDataReader dataReader = null;
            //Open connection
            if (OpenConnection() == true)
            {

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 300;

                //loop insert params
                if (param != null)
                    foreach (KeyValuePair<string, string> entry in param)
                    {
                        cmd.Parameters.Add(new MySqlParameter(entry.Key, entry.Value));
                    }
                dataReader = cmd.ExecuteReader();

            }
            //   CloseConnection();
            return dataReader;
        }

        //Select statement
        public int InsertOrUpdate(string query, bool isStoredProcedures, Dictionary<string, string> param = null)
        {
            int ret = 0;
            //Open connection
            if (OpenConnection() == true)
            {

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //loop insert params
                if (param != null)
                    foreach (KeyValuePair<string, string> entry in param)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                ret = cmd.ExecuteNonQuery();
            }
            //   CloseConnection();
            return ret;
        }

        //Select statement
        public MySqlDataReader Select2(string query, Dictionary<string, string> param = null, MySqlCommand cmd = null)
        {
            MySqlDataReader dataReader = null;
            //Open connection
            if (OpenConnection() == true)
            {

                //Create Command

                //MySqlCommand cmd = new MySqlCommand(query, connection);
                //loop insert params
                if (param != null)
                    foreach (KeyValuePair<string, string> entry in param)
                    {
                        cmd.Parameters.Add(new MySqlParameter(entry.Key, entry.Value));
                    }
                dataReader = cmd.ExecuteReader();

            }
            //   CloseConnection();
            return dataReader;
        }

        //Count statement
        public int Count()
        {
            return 0;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }

        /// <summary>
        /// Retourne un objet T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public T Serialize<T>(MySqlDataReader reader) where T : new()
        {
            var results = new T();
            var cols = new List<string>();
            //for (var i = 0; i < reader.FieldCount; i++)
            //    cols.Add(reader.GetName(i));

            while (reader.Read())
                results = SerializeRow<T>(reader);

            return results;
        }

        /// <summary>
        /// Retourne une liste de T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<T> Serializes<T>(MySqlDataReader reader) where T : new()
        {
            var results = new List<T>();
            //for (var i = 0; i < reader.FieldCount; i++)
            //    cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow<T>(reader));

            return results;
        }

        public T SerializeRow<T>(MySqlDataReader reader) where T : new()
        {
            T result = new T();
            foreach (PropertyInfo d in result.GetType().GetProperties())
            {
                try
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(d.Name)))
                        d.SetValue(result, reader[d.Name]);
                }
                catch (Exception e)
                {
                }
            }

            return result;
        }
    }
}