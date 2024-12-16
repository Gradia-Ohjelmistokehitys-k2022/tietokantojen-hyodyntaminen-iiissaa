using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Tietokannat_hyödyntäminen_1.Models;

namespace Tietokannat_hyödyntäminen_1.Models
{
    internal class DataBaseReporisity
    {
        private string _connectionString;

        public DataBaseReporisity(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string IsDbConnectionEstablished()
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                return "Connection established!";
            }
            catch (SqlException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Book> GetAllBookFromLastFiveYears()
        {
            List<Book> Books = new();

            using var dbConnection = new SqlConnection(_connectionString); // uusi tapa käyttää using-ominaisuutta. Tämä huolehtii yhteyden sulkemisesta.

            dbConnection.Open(); //avataan yhteys tietokantaan

            using var command = new SqlCommand("SELECT * FROM Book where PublicationYear > YEAR(GETDATE()) - 5", dbConnection); // kysely ja tietokannan osoite
            using var reader = command.ExecuteReader(); // olio, jolla luetaan tietoja kannasta
            while (reader.Read()) // silmukka, joka lukee kantaa niin kauan kuin siellä on rivejä, joital lukea
            {
                Book book = new() // jokaiselle riville luodaan uusi olio, johon tiedot tallennetaan
                {
                    BookId = Convert.ToInt32(reader["BookId"]),
                    Title = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                    AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])

                };
                Books.Add(book);
            }

            return Books;
        }


        public int GetAverageAge()
        {

            using var dbConnection = new SqlConnection(_connectionString); // uusi tapa käyttää using-ominaisuutta. Tämä huolehtii yhteyden sulkemisesta.

            dbConnection.Open(); //avataan yhteys tietokantaan

            using var command = new SqlCommand("(SELECT AVG(YEAR(RegistrationDate)) AS AvgAge FROM Member)", dbConnection); // kysely ja tietokannan osoite
            using var reader = command.ExecuteReader(); // olio, jolla luetaan tietoja kannasta
            reader.Read();// silmukka, joka lukee kantaa niin kauan kuin siellä on rivejä, joital lukea

            return Convert.ToInt32(reader["AvgAge"]);
        }


        public Book GetMostAvailableBook()
        {
            using var dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            using var command = new SqlCommand("(SELECT * FROM Book where (select MAX(AvailableCopies) from Book) = AvailableCopies)", dbConnection);
            using var reader = command.ExecuteReader();


            if (reader.Read())
            {
                Book book = new()
                {
                    BookId = Convert.ToInt32(reader["BookId"]),
                    Title = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                    AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
                };

            }
                return null;
        }


    }
}


