using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Template10.Mvvm;
using Windows.UI.Xaml;

namespace ToDoList.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public void Add_View(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(Views.EditPage));
        }

        public void Edit_View(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(Views.EditPage));
        }

        public void Delete_Items(int _data)
        {
            
            using (SqliteConnection db = new SqliteConnection("Filename=sqlite.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand($"DELETE FROM Table1 WHERE Index={_data}", db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                }
                catch (SqliteException)
                {
                    //Handle error
                }
                
                db.Close();
            }
        }

        public List<String> Get_Items()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqlite.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from Table1", db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                }
                catch (SqliteException)
                {
                    //Handle error
                    return entries;
                }
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }
    }

    
}
