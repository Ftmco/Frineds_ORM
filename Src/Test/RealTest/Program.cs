using FTeam.Orm.Attributes;
using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using System;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly DbConnectionInfo _dbConnectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            TableInfoResult table = _dbConnectionInfo.Table("News", typeof(News));
            News news = new()
            {
                CreateDate = DateTime.Now,
                ImageName = "null.png",
                IsPublic = false,
                NewsId = Guid.Parse("6C0A3D2E-35F1-4591-A00C-295EA70B42E0"),
                ShortDescription = "Short Desc",
                ShowInSlider = true,
                Text = "Text",
                Title = "Title"
            };

            Console.WriteLine($"{table.Delete(news)}");

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
