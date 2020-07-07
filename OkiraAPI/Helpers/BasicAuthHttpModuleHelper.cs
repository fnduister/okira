using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace OkiraAPI.Helpers
{
    public class BasicAuthHttpModuleHelper
    {
        private bool CheckPassword(string username, string password, string passwordEncrypted)
        {
            return true;
        }

        private string AuthenticateUserCredentials(string credentials)
        {
            try
            {
                var encoding = Encoding.UTF8;
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);
                string passwordEncrypted = "";

                if (!CheckPassword(name, password, passwordEncrypted))
                {
                    throw new Exception(string.Format("[{0}] {1}", HttpStatusCode.Unauthorized, "Authentication Failed"));
                }
                return name;
            }
            catch (FormatException)
            {
                // Credentials were not formatted correctly.
                throw new Exception(string.Format("[{0}] {1}", HttpStatusCode.Unauthorized, "Credentials were not formatted correctly"));
            }
        }

        public string AuthenticateUser(string authHeader)
        {
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    return AuthenticateUserCredentials(authHeaderVal.Parameter);
                }

                throw new Exception(string.Format("[{0}] {1}", HttpStatusCode.Unauthorized, "Authentication Failed"));
            }
            else
                throw new Exception(string.Format("[{0}] {1}", HttpStatusCode.Unauthorized, "Header autorisations cannot be empty"));
        }
    }
}