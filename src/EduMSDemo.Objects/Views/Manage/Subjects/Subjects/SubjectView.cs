using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class SubjectView : BaseView
    {
        [Required]
        [StringLength(32)]
        //[Index(IsUnique = true)]
        public String Code { get; set; }

        [Required]
        [StringLength(128)]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        public Int32 Credits { get; set; }

        public Int32 AcademicCredits { get; set; }

        //[ForeignKey("Department")]
        public Int32 DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public String DepartmentName { get; set; }

        // List CurriculumDetail
        //public virtual IList<CurriculumDetail> CurriculumDetails { get; set; }

        // List PreSubject
        //[InverseProperty("PreOfSubject")]
        //public virtual IList<PreSubject> PreOfSubjects { get; set; }

        // List PreSubject
        //[InverseProperty("SubjectOfPre")]
        //public virtual IList<PreSubject> SubjectOfPres { get; set; }

        // List PreSubject
        //public virtual IList<ScoreRecord> ScoreRecords { get; set; }

    }
}










