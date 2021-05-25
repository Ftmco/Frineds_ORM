﻿using FTeam.Orm.Attributes;
using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using RealTest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FriendsOrmStarter
{
    class Program
    {
        static readonly DbConnectionInfo _dbConnectionInfo = new(".", "Fstore_Db", Authentication.WindowsAuthentication);

        static void Main(string[] args)
        {
            TableInfoResult table = _dbConnectionInfo.Table("Groups", typeof(Groups));
            Groups groups = new()
            {
                //GroupId = Guid.Empty,
                //Icon = "",
                Name = "createGroupViewModel.Name",
                Title = "createGroupViewModel.Title"
            };

            Console.WriteLine(DateTime.Now);
            Console.WriteLine($"{table.InsertAsync(groups).Result}");
            Console.WriteLine(groups.Id);
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
