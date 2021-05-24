using FTeam.Orm.Attributes;
using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using RealTest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly DbConnectionInfo _dbConnectionInfo = new(".", "Orm_Test", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            TableInfoResult table = _dbConnectionInfo.Table("Entity", typeof(Entity));
            List<Entity> sessions = new();

            for (int i = 0; i < 2; i++)
            {
                sessions.Add(new()
                {
                    Age = 10,
                    Family = "TEst"
                });
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine($"{table.InsertRange(sessions).Where(s => s == QueryStatus.Success).Count()}");
            Console.WriteLine(DateTime.Now);
        }

    }

    public record Entity
    {
        public Entity()
        {

        }

        [FKey]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public int Age { get; set; }
    }
}
