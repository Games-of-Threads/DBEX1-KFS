using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBEX1_KFS
{
    class simple_db
    {
        Dictionary<int, string> database;
        const string dataFile = "DatabaseFile.dat";

        public simple_db()
        {
            database = new Dictionary<int, string>();
            LoadDatabase();
        }

        /// <summary>
        /// function to add people to the database, id can be specified or choosen as 0 for default placement.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        public void AddPerson(int id, string name, string status)   
        {
            if (id == 0)
            {
                string input = formatString(name, status);
                for (int i = 0; i < database.Count; i++)
                {
                    try
                    {
                        if (!database.ContainsKey(i))
                        {
                            database.Add(i, input);
                            SaveDatabase(i, input);
                        }
                        else
                        {
                            errorReport("AddPerson");
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                //database.Add(database.Keys.Last<int>() + 1, input);
                succesReport("add person with default ID");
            }
            else if (id > 0)
            {
                string input = formatString(name, status);
                database.Add(id, input);

                SaveDatabase(id, input);
                succesReport(string.Format("add person with ID {0}", id));
            }
            else
            {
                errorReport("AddPerson");
            }
        }

        /// <summary>
        /// function to check for information in the database.
        /// </summary>
        /// <param name="id"></param>
        public void CheckPerson(int id)
        {
            if (id == 0)
            {
                foreach (var item in database)
                {
                    string status = database[item.Key];
                    Console.WriteLine("key: {0} value: {1}",item.Key,status);
                    Console.WriteLine(item.Key.ToString());
                }
            }
            else if (id > 0 && database.ContainsKey(id))
            {
                string status = database[id];
                Console.WriteLine("key: {0} value: {1}", id, status);
            }
            else
            {
                errorReport("CheckPerson");
            }
        }

        public void test()
        {

        }

        /// <summary>
        /// saves the current data in a binary file
        /// </summary>
        public void SaveDatabase(int id, string input)
        {
            try
            {
                BinaryWriter writer = new BinaryWriter(File.Open(dataFile, FileMode.Append));
                //writer.Write(string.Format(id + ";" + input));
                //char[] text = string.Format(id + ";" + input).ToCharArray();
                byte[] data = Encoding.UTF8.GetBytes(string.Format(id + ";" + input));

                writer.Write(data.GetHashCode());

                //using (SHA512 shaM = new SHA512Managed())
                //{
                //    byte[] result = shaM.ComputeHash(data);
                //    writer.Write(Convert.ToBase64String(result));
                //}
                //message = Encoding.UTF8.GetBytes(text);
                //for (int i = 0; i < text.Length; i++)
                //{
                //    message = Encoding.UTF8.GetBytes(text);
                //}
                //string message = string.Format(id + ";" + input);
                //writer.Write(message);
                succesReport(string.Format(id + ";" + input + " has been succesfully saved to the database"));
                writer.Dispose();
                writer.Close();
            }
            catch (Exception)
            {
                errorReport("SaveDatabase");
            }
        }

        /// <summary>
        /// loads the local binary data file into keyvalue memory
        /// </summary>
        public void LoadDatabase()
        {
            BinaryReader reader = new BinaryReader(File.Open(dataFile, FileMode.OpenOrCreate));

            string allData = "";
            //string allData = reader.ReadString();
            //for (int i = 0; i < reader.BaseStream.Length / sizeof(int); i++)
            //{
            //    allData += reader.ReadString();
            //}
            Console.WriteLine(allData);
            //sbyte[] allData = new sbyte[reader.BaseStream.Length];
            //for (int i = 0; i < reader.BaseStream.Length; i++)
            //{
            //    try
            //    {
            //        allData[i] = reader.ReadSByte();
            //        Console.WriteLine(allData[i].ToString());
            //    }
            //    catch (Exception)
            //    {
            //        errorReport("LoadDatabase");
            //    }
            //}
            Console.WriteLine();
            reader.Close();
        }

        /// <summary>
        /// formats the string for ease of use
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private string formatString(string name, string status)
        {
            return string.Format("[Name:{0},Status:{1}]",name,status);
        }

        /// <summary>
        /// error reporter for ease of bugfixing
        /// </summary>
        /// <param name="state"></param>
        private void errorReport(string state)
        {
            Console.WriteLine("Sorry sir I encountered a error in processing your {0} request", state);
        }

        /// <summary>
        /// succes reporter for ease of troubleshooting
        /// </summary>
        /// <param name="state"></param>
        private void succesReport(string state)
        {
            Console.WriteLine("SUCCES! I finished processing your {0} request", state);
        }
    }
}
