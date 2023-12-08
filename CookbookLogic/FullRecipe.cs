using System.Security.Cryptography.X509Certificates;
using CookbookDataAccess.DataAccess;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace CookbookLogic
{

   
    public class FullRecipe
    {
        public string? Name { get; private set; }

        public string? score { get; private set; }

        public string? source { get; private set; }

        public int randomVal { get; private set; }

        public FullRecipe() 
        {
            SqlConnection SqlConn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CookbookWebDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            SqlConn.Open();
            randomVal = Random.Shared.Next(1,100);
        }
    }
}
