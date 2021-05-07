using FTeam.Orm.Attributes;
using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly DbConnectionInfo _dbConnectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            TableInfoResult table = _dbConnectionInfo.Table("News", typeof(News));
            string path = "E:/Logs.txt";

            Console.WriteLine("St Get");
            var allNews = table.GetAllAsync<News>().Result;
            Console.WriteLine("Fn Get");

            File.WriteAllText(path, $"Start Update {DateTime.Now}");


            foreach (var news in allNews)
            {
                news.Title = "Updated News";
                Console.Write($"{ table.TryDelete(news)} \t");
            }
            Console.WriteLine($"End Insert {DateTime.Now}");

        }

    }

    public record Entity
    {
        public Entity()
        {

        }

        [FKey]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public int Age { get; set; }
    }
}
