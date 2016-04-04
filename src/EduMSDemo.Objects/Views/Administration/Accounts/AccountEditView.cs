using System;
using System.ComponentModel.DataAnnotations;

namespace EduMSDemo.Objects
{
    public class AccountEditView : BaseView
    {
        [Required]
        [StringLength(128)]
        public String Name { get; set; }

        [Required]
        [Editable(false)]
        public String Username { get; set; }

        [Required]
        [Editable(false)]
        public String Email { get; set; }

        [StringLength(128)]
        public String Position { get; set; }

        [StringLength(32)]
        public String Phone { get; set; }

        public Boolean IsLocked { get; set; }

        public Int32? RoleId { get; set; }
    }
}
