using System.Net.Http.Headers;
using Tietokannat_hyödyntäminen_1.Models;

namespace Tietokannat_hyödyntäminen_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var databaseReporisity = new DataBaseReporisity("server=(localdb)\\MSSQLLocalDB;" +
                                       "Trusted_Connection=true;" +
                                       "database=library;");
            var result = databaseReporisity.IsDbConnectionEstablished();
            Console.WriteLine(result);
            var books = databaseReporisity.GetAllBookFromLastFiveYears();
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }

            var age = databaseReporisity.GetAverageAge();
            Console.WriteLine(age);
         }
        
        
       

    }
}
