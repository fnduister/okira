using MySql.Data.MySqlClient;
using OkiraAPI.Connection;
using OkiraEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkiraAPI.DAL
{
    public class UserDataAcces
    {
        public static User Login(string username, string password)
        {
            User membre = null;

            try
            {
                ConnectionBD db = new ConnectionBD();
                string query;

                query = "select * from user WHERE username = @username AND password = @password";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("username", username);
                param.Add("password", password);

                MySqlDataReader reader = db.Select(query, param);
                membre = db.Serialize<User>(reader);

                db.CloseConnection();
            }
            catch (Exception e)
            {
            }
            return membre;
        }
    }
}