using EduMSDemo.Components.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Datalist;
namespace EduMSDemo.Objects
{
    public class AccountCreateView : BaseView
    {
        [Required]
        [StringLength(128)]        
        public String Name { get; set; }

        [Required]
        [StringLength(32)]
        public String Username { get; set; }

        [Required]
        [NotTrimmed]
        [StringLength(32)]
        public String Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public String Email { get; set; }

        [StringLength(128)]
        public String Position { get; set; }

        [StringLength(32)]
        public String Phone { get; set; }

        public Int32? RoleId { get; set; }
    }
}
