using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class Course : BaseModel
    {
        [Required]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public String Code { get; set; }

        [Required]
        [StringLength(128)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //[ForeignKey("Faculty")]
        public Int32 FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

        //// List Curriculum
        //public virtual IList<Curriculum> Curriculums { get; set; }

        // List StudentClass
        public virtual IList<StudentClass> StudentClasses { get; set; }
    }
}










