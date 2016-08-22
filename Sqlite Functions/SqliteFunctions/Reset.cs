using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqlite_Functions.Properties;

namespace Sqlite_Functions.SqliteFunctions
{
    internal class Reset
    {
        public void reset()
        {
            Settings _appSettings = new Settings();

            _appSettings.selectedMeals.Clear();
            _appSettings.selectedMealCosts.Clear();
            _appSettings.selectedMealIngredientFileName.Clear();
            _appSettings.selectedMealMethodFileName.Clear();
            _appSettings.cumulativeCost = 0.0;
        }
    }
}
