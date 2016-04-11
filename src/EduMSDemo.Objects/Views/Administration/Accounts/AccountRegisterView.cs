﻿using EduMSDemo.Components.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace EduMSDemo.Objects
{
    public class AccountRegisterView : BaseView
    {
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

    }
}
