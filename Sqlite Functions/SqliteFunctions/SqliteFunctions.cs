using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Sqlite_Functions.Properties;

using System.Windows.Forms;

namespace Sqlite_Functions.SqliteFunctions
{
    /*  Main sqlite database class. 
     *   Functions:

      * connectToDataBase() - Connects to database, connection will be kept open.
      * disconnectDatabase() - Disconnects the database.
      * createNewTable() - Creates a new table within the database.
      * addMealInfoToDatabase() - Checks if the database file exists through DatabaseValidation class. If it doesn't create and add meal info.
      * addToDatabase(string mealName, double cost, string ingredientFileName, string methodFileName) - Used in AddMealInfoToDB class to add meal info to database.
      * selectDataFromDB() - Selects data from the database.
      * initialiseLists() - Initialises the application setting lists used to hold the randomly selected meal info so they can be written to and read from.
      * updateItemInDB(string itemToUpdate, params string[] dbItemsToUpdate) - Updates a record in the database.
      * deleteIteemFromDB(string itemToDelete) - Deletes a record from the database.
     
     */

    public class SqliteFunctions
    {
        public SqliteFunctions(string dbName, string tbName)
        {
            this._databaseName = dbName;
            this._tableName = tbName;
        }

        private string _databaseName;
        private string _tableName;
        private SQLiteConnection _sqlConnection;
        private Settings _appSettings = new Settings();


        public void connectToDatabase() //Connection will be kept open to save from opening and closing the database constantly.
        {
            try
            {
                _sqlConnection = new SQLiteConnection(@"Data Source=" + _databaseName + ".sqlite;Version=3;"); //Creates new connection.
                _sqlConnection.Open(); //Opens the connection to the database. This will stay open until closed in the mainWindow so the connection won't keep opening and closing.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void disconnectDatabase() //Closing the connection
        {
            try
            {
                _sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void createNewTable() //Creates a new table within the database.
        {
            try
            {
                string sqlQuery = "CREATE TABLE IF NOT EXISTS " + _tableName + "(_id INTEGER PRIMARY KEY, Meal_Name text, Cost real, IngredientsFileName, MethodFileName)";
                //Creates the table if it doesn't exist with headers: id, Meal_Name, Cost, IngredientsFileName and MethodFileName.

                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, _sqlConnection);
                cmd.ExecuteNonQuery();              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void addMealInfoToDatabase() //Adds all the meal info into the database.
        {
            try
            {
                DatabaseValidation dbValidation = new DatabaseValidation();
                if (dbValidation.fileValidation(_databaseName) == false) //If the database file can not be found in the current directory.
                {
                    //Create new database and table and add all the meal info into it.
                    connectToDatabase();
                    createNewTable();
                    AddMealInfoToDB addMealInfoToDB = new AddMealInfoToDB(_databaseName, _tableName);
                    addMealInfoToDB.stuffToAddToDB();
                }
                else
                    connectToDatabase();
                //If file exists we don't need to add the meal info in, it's already there so just connect to it.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void addToDatabase(string mealName, double cost, string ingredientFileName, string methodFileName)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(string.Format("INSERT INTO " + _tableName + "(Meal_Name, Cost, IngredientsFileName, MethodFileName) VALUES('" + mealName + "', '" + cost + "', '" + ingredientFileName + "', '" + methodFileName + "');")))
                {
                    cmd.Connection = _sqlConnection;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //Adds item to database.

        public void resetMeals()
        {
            Reset reset = new Reset();
            reset.reset();
        }

        public void selectDataFromDB()
        {
            try
            {
                _appSettings.cumulativeCost = 0;
                _appSettings.Save();

                initialiseLists(); //Initialise application settings lists.
                using (SQLiteConnection con = new SQLiteConnection(_sqlConnection))
                {
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandText = "SELECT * FROM " + _tableName + " ORDER BY RANDOM() LIMIT 7;"; //Selects 7 random entries.
                    cmd.Connection = con;
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        //Set random data to the relevant lists.
                        _appSettings.selectedMeals.Add(reader["Meal_Name"].ToString());
                        _appSettings.selectedMealCosts.Add(double.Parse(reader["Cost"].ToString())); //Parse double.
                        _appSettings.selectedMealIngredientFileName.Add(reader["IngredientsFileName"].ToString());
                        _appSettings.selectedMealMethodFileName.Add(reader["MethodFileName"].ToString());

                        _appSettings.Save();
                    }

                    foreach (double cumulativeCost in _appSettings.selectedMealCosts)
                    {
                        _appSettings.cumulativeCost += cumulativeCost;
                        _appSettings.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void initialiseLists()
        {
            _appSettings.selectedMeals = new List<string>();
            _appSettings.selectedMealCosts = new List<double>();
            _appSettings.selectedMealIngredientFileName = new List<string>();
            _appSettings.selectedMealMethodFileName = new List<string>();
        }

        public void updateItemInDB(string itemToUpdate, params string[] dbItemsToUpdate) //This function isn't used in the meal app, but here for future use.
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(string.Format("UPDATE" + _tableName + "SET(Meal_Name, Cost, IngredientsFileName, MethodFileName) VALUES('" + dbItemsToUpdate[0] + "', '" + double.Parse(dbItemsToUpdate[1]) + "', '" + dbItemsToUpdate[2] + "', '" + dbItemsToUpdate[3] + "') WHERE Meal_Name=" + itemToUpdate + ";")))
                {
                    cmd.Connection = _sqlConnection;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void deleteIteemFromDB(string itemToDelete) //This function isn't used in the meal app, but here for future use.
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(string.Format("DELETE FROM "+ _tableName + " WHERE Meal_Name=" + itemToDelete + ";")))
                {
                    cmd.Connection = _sqlConnection;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
