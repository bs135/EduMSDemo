using EduMSDemo.Components.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace EduMSDemo.Objects
{
    public class AccountDeleteView : BaseView
    {
        [Required]
        [StringLength(128)]
        public String Name { get; set; }

        [Required]
        [StringLength(32)]
        public String Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public String Email { get; set; }

        [StringLength(128)]
        public String Position { get; set; }

        [StringLength(32)]
        public String Phone { get; set; }

        public Boolean IsLocked { get; set; }

        public String RoleTitle { get; set; }
    }
}
