using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class Department : BaseModel
    {
        [Required]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public String Abbreviation { get; set; }

        [Required]
        [StringLength(128)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        [StringLength(512)]
        public String Address { get; set; }

        [StringLength(256)]
        [EmailAddress]
        public String Email { get; set; }

        [StringLength(256)]
        [Phone]
        public String PhoneNumber { get; set; }

        // [ForeignKey("Faculty")]
        public Int32 FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

        // List Subject
        public virtual IList<Subject> Subjects { get; set; }

        // Staff
        public virtual IList<Staff> Staffs { get; set; }
    }
}
