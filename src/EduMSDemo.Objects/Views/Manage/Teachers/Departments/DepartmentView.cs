using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class DepartmentView : BaseView
    {
        [Required]
        [StringLength(128)]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        [StringLength(512)]
        public String Address { get; set; }

        [StringLength(256)]
        [EmailAddress]
        public String Email { get; set; }

        [StringLength(256)]
        //[Phone]
        public String PhoneNumber { get; set; }

        [StringLength(256)]
        //[Phone]
        public String FaxNumber { get; set; }

        // [ForeignKey("Faculty")]
        public Int32 FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public String FacultyName { get; set; }

        // List Subject
        //public virtual IList<Subject> Subjects { get; set; }

        // Staff
        //public virtual IList<Staff> Staffs { get; set; }
    }
}
