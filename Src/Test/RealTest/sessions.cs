using FTeam.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealTest
{
    public record UserSessions
    {
        public UserSessions()
        {

        }

        [FKey]
        [Key]
        public Guid Id { get; set; }

        [DefaultValue("Authorization")]
        [Required]
        public string Key { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string LocalIp { get; set; }

        [Required]
        public string RemoteIp { get; set; }

        [Required]
        public int LocalPort { get; set; }

        [Required]
        public int RemotePort { get; set; }

        [Required]
        public DateTime SetDate { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        //Navigation Property
        //Relationships 

        public virtual Users Users { get; set; }
    }

    public record Users
    {
        public Users()
        {

        }

        [FKey]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Password { get; set; }

        [Required]
        public string ActiveCode { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

       
        public virtual ICollection<UserSessions> UserSessions { get; set; }

    }
}
