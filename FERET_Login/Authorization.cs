using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FERET_Login
{
    static class Authorization
    {

        //xml file's properties
        private static String folder = "User";
        private static String file = "Users.xml";
        private static String folderpath { get { return Application.StartupPath + "\\" + folder; } }
        private static String filepath { get { return folderpath + "\\" + file; } }

        private static Dictionary<String, String> Users = new Dictionary<string, string>();

        //current logged in user
        public static String username;

        public static int Login(String username, String password)
        {
            if (Users.ContainsKey(username))
            {
                if (Users[username].Equals(password))
                {
                    Authorization.username = username;
                    return 0;
                }
            }

            return -1;
        }

        public static int Register(String username, String password)
        {

            if (username.Equals("Username") && password.Equals("Password")) 
                //do nothing on default value                
                return -1;
            else if (!Users.ContainsKey(username))
            {
                SaveUser(username, password);
                return 0;
            }
            return -1;
        }



        public static void SaveUser(String username, String password)
        {
            //add to current dictionary
            Users.Add(username, password);

            //write to file
            XMLManager.WriteXMLForAuth(folderpath, file, username, password);
        }


        public static void LoadUsers()
        {

            //read from file
            List<String> usernames = new List<String>();
            List<String> passwords = new List<String>();
            XMLManager.ReadXMLForAuth(filepath, usernames, passwords);


            //add to current dictionary
            Users.Clear();
            int counter = 0;
            foreach (String user in usernames)
                Users.Add(user, passwords[counter++]);
        }


        public static bool Logout()
        {
            username = "";
            return true;
        }


    }
}
