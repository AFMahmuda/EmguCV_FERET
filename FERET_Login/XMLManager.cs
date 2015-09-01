using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace FERET_Login
{
    class XMLManager
    {
        public static void WriteXMLForTraining(String filepath, String userName, String imageFilename)
        {
            XmlDocument xmlFile = new XmlDocument();
            if (File.Exists(filepath))
            {
                bool loading = true;
                while (loading)
                {
                    try
                    {
                        xmlFile.Load(filepath);
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

                XmlElement face_D = xmlFile.CreateElement("FACE");
                XmlElement name_D = xmlFile.CreateElement("NAME");
                XmlElement file_D = xmlFile.CreateElement("FILE");


                name_D.InnerText = userName;
                file_D.InnerText = imageFilename;

                face_D.AppendChild(name_D);
                face_D.AppendChild(file_D);
                root.AppendChild(face_D);

                xmlFile.Save(filepath);
            }

            else
            {
                FileStream fileStream = File.OpenWrite(filepath);
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Faces_For_Training");

                    xmlWriter.WriteStartElement("FACE");
                    xmlWriter.WriteElementString("NAME", userName);
                    xmlWriter.WriteElementString("FILE", imageFilename);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
                fileStream.Dispose();

            }

        }

        public static bool ReadXMLForTraining(String folder, String filename, List<int> labelsID, List<String> labels, List<Image<Gray, byte>> trainingImages)
        {
            String filepath = folder + "\\" + filename;
            if (File.Exists(filepath))
            {
                labels.Clear();
                labelsID.Clear();
                trainingImages.Clear();

                FileStream filestream = File.OpenRead(filepath);
                long fileLength = filestream.Length;
                byte[] xmlBytes = new byte[fileLength];
                filestream.Read(xmlBytes, 0, (int)fileLength);
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
                                case "NAME":
                                    if (xmlReader.Read())
                                    {
                                        labelsID.Add(labels.Count);
                                        labels.Add(xmlReader.Value.Trim());
                                    }
                                    break;
                                case "FILE":
                                    if (xmlReader.Read())

                                        trainingImages.Add(new Image<Gray, byte>(folder + "\\" + xmlReader.Value.Trim()));

                                    break;
                            }
                        }
                    }
                }
                xmlStream.Dispose();
                filestream.Dispose();
                return true;
            }
            else
                return false;

        }

        public static void ReadXMLForAuth(String filepath, List<String> usernames, List<String> passwords)
        {

            if (File.Exists(filepath))
            {
                FileStream filestream = File.OpenRead(filepath);
                long fileLength = filestream.Length;
                byte[] xmlBytes = new byte[fileLength];
                filestream.Read(xmlBytes, 0, (int)fileLength);
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

        public static void WriteXMLForAuth(String folder, String filename, String username, String password)
        {
            filename = folder + "\\" + filename;
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            XmlDocument xmlFile = new XmlDocument();
            if (File.Exists(filename))
            {

                bool loading = true;
                while (loading)
                {
                    try
                    {
                        xmlFile.Load(filename);
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


                name_D.InnerText = username;
                file_D.InnerText = password;

                face_D.AppendChild(name_D);
                face_D.AppendChild(file_D);
                root.AppendChild(face_D);

                xmlFile.Save(filename);
            }

            else
            {
                FileStream fileStream = File.OpenWrite(filename);
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("User_Database");

                    xmlWriter.WriteStartElement("USER");
                    xmlWriter.WriteElementString("USERNAME", username);
                    xmlWriter.WriteElementString("PASSWORD", password);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
                fileStream.Dispose();
            }
        }
    }
}
