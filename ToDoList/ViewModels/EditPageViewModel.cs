using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.ViewModels
{
    class EditPageViewModel
    {
        private int index = 0;
        public void AddtoDataBase(String _data)
        {
            
            using (SqliteConnection db = new SqliteConnection("Filename=sqlite.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand
                {
                    Connection = db,

                    //Use parameterized query to prevent SQL injection attacks
                    CommandText = "INSERT INTO Table1 VALUES (NULL, @Entry1, @Entry2);"
                };
                

                insertCommand.Parameters.AddWithValue("@Entry1",  );
                insertCommand.Parameters.AddWithValue("@Entry2", _data);
                
                try
                {
                    insertCommand.ExecuteReader();
                }
                catch (SqliteException)
                {
                    //Handle error
                    return;
                }
                db.Close();
            }


        }

    }
}
