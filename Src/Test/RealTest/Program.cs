using FTeam.Orm.Attributes;
using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly DbConnectionInfo _dbConnectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            TableInfoResult table = _dbConnectionInfo.Table("News", typeof(News));
            //IEnumerable<News> news = table.GetAll<News>(nameof(News.NewsId), 0, 10);
            Console.WriteLine(table.Count());

        }

        static void InsertNews()
        {
            TableInfoResult table = _dbConnectionInfo.Table("News", typeof(News));
            Console.WriteLine($"Start = {DateTime.Now}");
            for (int i = 0; i < 2000000; i++)
            {
                bool isFalse = i % 2 == 0;
                News news = new()
                {
                    NewsId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    ImageName = "null",
                    IsPublic = isFalse,
                    ShortDescription = "test",
                    ShowInSlider = isFalse,
                    Text = i + "Hello " + i,
                    Title = "Title " + i
                };
                Console.WriteLine(table.Insert(news));
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

        public record Groups
        {
            public Groups()
            {

            }

            [FKey]
            [Key]
            public Guid Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Title { get; set; }

            public string Icon { get; set; }

            public Guid? GroupId { get; set; }

            public virtual ICollection<Groups> Group { get; set; }
        }
    }
}
