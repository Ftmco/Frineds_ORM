using FTeam.Orm.Attributes;
using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using RealTest;
using System;
using System.Collections.Generic;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly DbConnectionInfo _dbConnectionInfo = new(".", "FStore_db", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            TableInfoResult table = _dbConnectionInfo.Table("UserSessions", typeof(UserSessions));
            List<UserSessions> sessions = new();

            for (int i = 0; i < 1000; i++)
            {
                sessions.Add(new()
                {
                    Key = "Authorization",
                    SetDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(10),
                    Token = Guid.NewGuid().ToString(),
                    UserId = Guid.Parse("16E405BA-E002-4D7F-9D00-0BCD6BB27EBF"),
                    LocalIp = "127.0.0.0",
                    LocalPort = 2020,
                    RemoteIp = "127.0.0.0",
                    RemotePort = 2020,
                    Id = Guid.NewGuid(),
                });
            }

            Console.WriteLine(DateTime.Now);
            Console.WriteLine($"{table.InsertRange(sessions)}");
            Console.WriteLine(DateTime.Now);
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
