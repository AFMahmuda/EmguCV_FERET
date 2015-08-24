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

        private static Dictionary<String, String> Users = new Dictionary<string, string>();
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
                
                else
                    return -1;
            }
            else
                return -1;
        }

        public static int Register(String username, String password)
        {
            if (username.Equals("Username") && password.Equals("Password"))
                return -1;
            if (!Users.ContainsKey(username))
            {
                SaveUsers(username, password);
                return 0;
            }
            else
                return -1;
        }

        private static void WriteXML(String name, String filename)
        {
            if (!Directory.Exists(Application.StartupPath + "\\User\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\User\\");

            XmlDocument xmlFile = new XmlDocument();
            if (File.Exists(Application.StartupPath + "\\User\\Users.xml"))
            {

                bool loading = true;
                while (loading)
                {
                    try
                    {
                        xmlFile.Load(Application.StartupPath + "\\User\\Users.xml");
                        loading = false;
                    }
                    catch
                    {
                        xmlFile = null;
                        xmlFile = new XmlDocument();
                        Thread.Sleep(10);
                    }
                }

                XmlElement root = xmlFile.DocumentElement;

                XmlElement face_D = xmlFile.CreateElement("USER");
                XmlElement name_D = xmlFile.CreateElement("USERNAME");
                XmlElement file_D = xmlFile.CreateElement("PASSWORD");


                name_D.InnerText = name;
                file_D.InnerText = filename;

                face_D.AppendChild(name_D);
                face_D.AppendChild(file_D);
                root.AppendChild(face_D);

                xmlFile.Save(Application.StartupPath + "\\User\\Users.xml");
            }

            else
            {
                FileStream fileStream = File.OpenWrite(Application.StartupPath + "\\User\\Users.xml");
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("User_Database");

                    xmlWriter.WriteStartElement("USER");
                    xmlWriter.WriteElementString("USERNAME", name);
                    xmlWriter.WriteElementString("PASSWORD", filename);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
                fileStream.Dispose();

            }

        }

        public static void SaveUsers(String username, String password)
        {
            Users.Add(username, password);
            WriteXML(username, password);
        }


        public static void LoadUsers()
        {
            List<String> usernames = new List<String>();
            List<String> passwords = new List<String>();

            ReadXML(usernames, passwords);

            int counter = 0;
            foreach (String user in usernames)
                Users.Add(user, passwords[counter++]);
        }

        private static void ReadXML(List<String> usernames, List<String> passwords)
        {

            if (File.Exists(Application.StartupPath + "\\User\\Users.xml"))
            {
                FileStream filestream = File.OpenRead(Application.StartupPath + "\\User\\Users.xml");
                long fileLength = filestream.Length;
                byte[] xmlBytes = new byte[fileLength];
                filestream.Read(xmlBytes, 0, (int)fileLength);
                filestream.Close();
                filestream.Dispose();

                MemoryStream xmlStream = new MemoryStream(xmlBytes);
                using (XmlReader xmlReader = XmlTextReader.Create(xmlStream))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.IsStartElement())
                        {
                            switch (xmlReader.Name)
                            {
                                case "USERNAME":
                                    if (xmlReader.Read())
                                        usernames.Add(xmlReader.Value.Trim());
                                    break;
                                case "PASSWORD":
                                    if (xmlReader.Read())

                                        passwords.Add(xmlReader.Value.Trim());
                                    break;
                            }
                        }
                    }
                }
                xmlStream.Dispose();
                filestream.Dispose();
            }
        }

    }
}
