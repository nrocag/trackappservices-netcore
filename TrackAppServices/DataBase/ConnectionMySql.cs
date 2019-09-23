using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TrackAppServices.DataBase
{
    public class Connection
    {
        public void Open()
        {
            using (var connection = new MySqlConnection("Server=myserver;User ID=mylogin;Password=mypass;Database=mydatabase"))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT field FROM table;", connection))
                {
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(0));
                }
            }
        }
    }
}
