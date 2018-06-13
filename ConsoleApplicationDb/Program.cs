using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationDb {
    class Program {

        public void AddToDB(SqlConnection connection) {
            string name, email;

            Console.Write("Enter name: ");
            name = Console.ReadLine();

            Console.Write("Enter email: ");
            email = Console.ReadLine();

            string queryString = $"INSERT INTO sexxTable(Name, Email) " +
                $"VALUES ('{name}','{email}');";

            SqlCommand command = new SqlCommand(queryString, connection);

            try {
                int res = command.ExecuteNonQuery();

                if (res > 0)
                    Console.WriteLine("Succses");
                else
                    Console.WriteLine("eror");

            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
        public void ShowDBState(SqlConnection connection) {
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT id, Name, Email FROM sexxTable";
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            try {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    Console.WriteLine("\t{0}\t{1}\t{2}",
                        reader["id"], reader["Name"], reader["Email"]);
                }
                reader.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

       public static void Main(string[] args) {

            string connectionString = "Data Source=92.52.130.3;Initial Catalog=sexx;User ID=test;Password=qwe123";

            using(SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                
            }

        }

    }
}
