using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class CurriculumView : BaseView
    {

        [Required]
        [StringLength(256)]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        // [ForeignKey("Faculty")]
        public Int32 FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public String FacultyName { get; set; }

        // [ForeignKey("Course")]
        public Int32 CourseId { get; set; }
        public virtual Course Course { get; set; }
        public String CourseName { get; set; }

        // List CurriculumDetail
        //public virtual IList<CurriculumDetail> CurriculumDetails { get; set; }

    }
}
