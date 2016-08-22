using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqlite_Functions.Properties;

namespace Sqlite_Functions.SqliteFunctions
{
    public class AppSettingsGetters
    {
        //This class libary uses internal application settings to get the info from the database.
        //This class returns the application settings lists so they can be used externally.

        Settings appSettings = new Settings();

        public void resetMeals()
        {
            Reset reset = new Reset();
            reset.reset();
        }

        private List<string> _selectedMeals = new List<string>();
        public List<string> SelectedMeals
        {
            get { return appSettings.selectedMeals; } //Returns the 7 selected meals.
            set
            {
                appSettings.selectedMeals = value;
                appSettings.Save();
            }
        }

        public List<double> SelectedMealCosts
        {
            get { return appSettings.selectedMealCosts; } //Returns the 7 selected meals' costs.
        }

        public List<string> SelectedMealIngredientFileName
        {
            get { return appSettings.selectedMealIngredientFileName; } //Returns the 7 selected meals' ingredient file names. This will be opened in the main program.
            set
            {
                appSettings.selectedMealIngredientFileName = value;
                appSettings.Save();
            }
        }

        public List<string> SelectedMealMethodFileName
        {
            get { return appSettings.selectedMealMethodFileName; } //Returns the 7 selected meals' method file names. This will be opened in the main program.
        }

        public double CumulativeCost
        {
            get { return appSettings.cumulativeCost; }
        }

    }
}