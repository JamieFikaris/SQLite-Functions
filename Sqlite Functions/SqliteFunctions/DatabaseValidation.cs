using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Sqlite_Functions.SqliteFunctions
{
    internal class DatabaseValidation
    {
        public bool fileValidation(string databaseName) //Checks if the database file exists in the directory, if it doesn't it will be created.
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            bool foundDatabase = false;
            foreach (string fn in Directory.GetFiles(path, ".", SearchOption.TopDirectoryOnly)) //Searches all file types in current directory.
            {
                if (fn.Contains(databaseName +".sqlite")) //If current file name contains the database name.
                {
                    foundDatabase = true;
                    return true; //The database exists, no need to create it again.
                }
            }
            if (foundDatabase == false)
            {
                return false; //Database will be created.
            }
            return false;
        }
    }
}
