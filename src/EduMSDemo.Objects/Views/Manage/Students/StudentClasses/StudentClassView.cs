using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class StudentClassView : BaseView
    {
        [Required]
        [StringLength(32)]
        //[Index(IsUnique = true)]
        public String Abbreviation { get; set; }

        [Required]
        [StringLength(128)]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        //[ForeignKey("Course")]
        public Int32 CourseId { get; set; }
        public virtual Course Course { get; set; }
        public String CourseName { get; set; }

        //[ForeignKey("Staff")]
        public Int32 StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public String StaffName { get; set; }

        //[ForeignKey("Curriculum")]
        public Int32 CurriculumId { get; set; }
        public virtual Curriculum Curriculum { get; set; }
        public String CurriculumName { get; set; }

        // List Student
        //public virtual IList<Student> Students { get; set; }

    }
}










