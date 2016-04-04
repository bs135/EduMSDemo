﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EduMSDemo.Objects
{
    public class Account : BaseModel
    {
        [Required]
        [StringLength(128)]
        public String Name { get; set; }

        [StringLength(128)]
        public String Position { get; set; }

        [StringLength(32)]
        public String Phone { get; set; }

        [Required]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public String Username { get; set; }

        [Required]
        [StringLength(64)]
        public String Passhash { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        [Index(IsUnique = true)]
        public String Email { get; set; }

        public Boolean IsLocked { get; set; }

        [StringLength(36)]
        public String RecoveryToken { get; set; }
        public DateTime? RecoveryTokenExpirationDate { get; set; }

        public Int32? RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
