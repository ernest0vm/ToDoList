using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;

namespace ToDoList
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
            RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Light;

            SqliteEngine.UseWinSqlite3(); //Configuring library to use SDK version of SQLite
            using (SqliteConnection db = new SqliteConnection("Filename=sqlite.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT EXISTS Table1 (" +
                    "Primary_Key INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Index INTEGER NULL" +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                try
                {
                    createTable.ExecuteReader();
                }
                catch (SqliteException)
                {
                    //Do nothing
                }
            }
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}
