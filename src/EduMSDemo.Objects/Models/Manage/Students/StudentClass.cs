using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class StudentClass : BaseModel
    {
        [Required]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public String Abbreviation { get; set; }

        [Required]
        [StringLength(128)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        //[ForeignKey("Course")]
        public Int32 CourseId { get; set; }
        public virtual Course Course { get; set; }

        //[ForeignKey("Staff")]
        public Int32 StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        // List Student
        public virtual IList<Student> Students { get; set; }

    }
}










