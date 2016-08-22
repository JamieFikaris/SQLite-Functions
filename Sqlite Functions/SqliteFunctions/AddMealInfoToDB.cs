using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;

namespace Sqlite_Functions.SqliteFunctions
{
    internal class AddMealInfoToDB
    {
        //Adds all the meal info into the sqlite database.

        public AddMealInfoToDB(string dbName, string tbName)
        {
            this._databaseName = dbName;
            this._tableName = tbName;
        }

        private string _databaseName;
        private string _tableName;


        public void stuffToAddToDB()
        {

            SqliteFunctions databaseFunctions = new SqliteFunctions(_databaseName, _tableName);
            databaseFunctions.connectToDatabase();

            databaseFunctions.addToDatabase("Asparagus And Crab Salad", 4.0, "Meals\\Asparagus_And_Crab_Salad_1.txt", "Meals\\Asparagus_And_Crab_Salad_2.txt");
            databaseFunctions.addToDatabase("Asparagus Cream Pasta", 3.0, "Meals\\Asparagus_Cream_Pasta_1.txt", "Meals\\Asparagus_Cream_Pasta_2.txt");
            databaseFunctions.addToDatabase("Baked Mushrooms with Ricotta and Pesto", 2.0, "Meals\\Baked_Mushrooms_with_Ricotta_and_Pesto_1.txt", "Meals\\Baked_Mushrooms_with_Ricotta_and_Pesto_2.txt");
            databaseFunctions.addToDatabase("Bangers and Beans in a Pan", 2.0, "Meals\\Bangers_and_Beans_in_a_Pan_1.txt", "Meals\\Bangers_and_Beans_in_a_Pan_2.txt");
            databaseFunctions.addToDatabase("Beef And Lentil Cottage Pie with Cauliflower Potato Topping", 3.0, "Meals\\Beef_And_Lentil_Cottage_Pie_with_Cauliflower_Potato_Topping_1.txt", "Meals\\Beef_And_Lentil_Cottage_Pie_with_Cauliflower_Potato_Topping_2.txt");
            databaseFunctions.addToDatabase("Braised Bacon with Colcannon Cakes", 2.0, "Meals\\Braised_Bacon_with_Colcannon_Cakes_1.txt", "Meals\\Braised_Bacon_with_Colcannon_Cakes_2.txt");
            databaseFunctions.addToDatabase("Buffalo Wings with Blue Cheese Dip", 2.0, "Meals\\Buffalo_Wings_with_Blue_Cheese_Dip_1.txt", "Meals\\Buffalo_Wings_with_Blue_Cheese_Dip_2.txt");
            databaseFunctions.addToDatabase("Cheesy Fish Grills", 2.0, "Meals\\Cheesy_Fish_Grills_1.txt", "Meals\\Cheesy_Fish_Grills_2.txt");
            databaseFunctions.addToDatabase("Cheesy Leeks and Ham", 2.0, "Meals\\Cheesy_Leeks_and_Ham_1.txt", "Meals\\Cheesy_Leeks_and_Ham_2.txt");
            databaseFunctions.addToDatabase("Chicken and Cider Fricassee with Parsley Croutes", 3.0, "Meals\\Chicken_and_Cider_Fricassee_with_Parsley_Croutes_1.txt", "Meals\\Chicken_and_Cider_Fricassee_with_Parsley_Croutes_2.txt");
            databaseFunctions.addToDatabase("Chicken and Mushroom Potato Pies", 2.0, "Meals\\Chicken_and_Mushroom_Potato_Pies_1.txt", "Meals\\Chicken_and_Mushroom_Potato_Pies_2.txt");
            databaseFunctions.addToDatabase("Chicken and Vegetable Curry", 4.0, "Meals\\Chicken_and_Vegetable_Curry_1.txt", "Meals\\Chicken_and_Vegetable_Curry_2.txt");
            databaseFunctions.addToDatabase("Winter Minestrone with Pesto Croutes", 4.0, "Meals\\Winter_Minestrone_with_Pesto_Croutes_1.txt", "Meals\\Winter_Minestrone_with_Pesto_Croutes_2.txt");
            databaseFunctions.addToDatabase("Wild Mushroom Tartlets", 2.0, "Meals\\Wild_Mushroom_Tartlets_1.txt", "Meals\\Wild_Mushroom_Tartlets_2.txt");
            databaseFunctions.addToDatabase("Whip Round The Fridge Rice", 2.0, "Meals\\Whip_Round_The_Fridge_Rice_1.txt", "Meals\\Whip_Round_The_Fridge_Rice_2.txt");
            databaseFunctions.addToDatabase("Warm Chickpea Chorizo and Pepper Salad", 3.0, "Meals\\Warm_Chickpea_Chorizo_and_Pepper_Salad_1.txt", "Meals\\Warm_Chickpea_Chorizo_and_Pepper_Salad_2.txt");
            databaseFunctions.addToDatabase("Warm Chicken Noodle Salad", 4.0, "Meals\\Warm_Chicken_Noodle_Salad_1.txt", "Meals\\Warm_Chicken_Noodle_Salad_2.txt");
            databaseFunctions.addToDatabase("Twice Baked Potatoes with Goats Cheese", 2.0, "Meals\\Twice_Baked_Potatoes_with_Goats_Cheese_1.txt", "Meals\\Twice_Baked_Potatoes_with_Goats_Cheese_2.txt");
            databaseFunctions.addToDatabase("Turkey Chilli Jacket Potatoes", 3.0, "Meals\\Turkey_Chilli_Jacket_Potatoes_1.txt", "Meals\\Turkey_Chilli_Jacket_Potatoes_2.txt");
            databaseFunctions.addToDatabase("Turkey Burgers", 2.0, "Meals\\Turkey_Burgers_1.txt", "Meals\\Turkey_Burgers_2.txt");
        }
    }
}
