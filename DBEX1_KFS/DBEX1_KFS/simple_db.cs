using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEX1_KFS
{
    class simple_db
    {
        Dictionary<int, string> database;

        public simple_db()
        {
            database = new Dictionary<int, string>();
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
                database.Add(0, input);
                //database.Add(database.Keys.Last<int>() + 1, input);
                succesReport("add person with default ID");
            }
            else if (id > 0)
            {
                string input = formatString(name, status);
                database.Add(id, input);
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
            string status = database.Keys.ToString();
            if (status != null)
            {
                if (id == 0)
                {
                    Console.WriteLine(database.ToString());
                }
                else
                {
                    Console.WriteLine(status);
                }
            }
            else
            {
                errorReport("CheckPerson");
            }
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
