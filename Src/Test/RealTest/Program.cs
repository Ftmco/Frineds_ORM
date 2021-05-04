using FTeam.Orm.Attributes;
using FTeam.Orm.Domains.Connection;
using FTeam.Orm.Domains.Connection.SqlServer;
using FTeam.Orm.Extentions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly SqlServerDbConnectionInfo _SqlServerDbConnectionInfo = new(".", "Orm_Test", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var entity = _SqlServerDbConnectionInfo.Table("Entity", typeof(Entity)).GetAll<Entity>();
            Console.WriteLine(entity.First().Name);
            Insert().Wait();
        }

        public static async Task Insert()
        {
            var table = await _SqlServerDbConnectionInfo.TableAsync("Entity", typeof(Entity));
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

        [FKey]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public int Age { get; set; }
    }
}
