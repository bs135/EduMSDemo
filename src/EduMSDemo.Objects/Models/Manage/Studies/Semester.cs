using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class Semester : BaseModel
    {
        [Required]
        [StringLength(128)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        //[Required]
        //[StringLength(32)]
        //public String SchoolYear { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // List SubjectClass
        public virtual IList<SubjectClass> SubjectClasses { get; set; }
    }
}










