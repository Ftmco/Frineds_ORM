﻿using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using System;
using System.Threading.Tasks;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly DbConnectionInfo _dbConnectionInfo = new(".", "Orm_Test", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Insert().Wait();
        }

        public static async Task Insert()
        {
            var table = await _dbConnectionInfo.TableAsync("Entity");
            var result = await table.UpdateAsync(new Entity()
            {
                Age = 10,
                Family = "update",
                Name = "update",
                Id = Guid.Parse("24740D17-80E6-4D00-9674-A2EA78D28CAA")
            });

            Console.WriteLine(result);
        }

    }

    public record Entity
    {
        public Entity()
        {

        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public int Age { get; set; }
    }
}