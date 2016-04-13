using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class ScoreRecordView : BaseView
    {
        public DateTime RegigterDate { get; set; }

        // [ForeignKey("Student")]
        public Int32 StudentId { get; set; }
        public virtual Student Student { get; set; }
        public String StudentName { get; set; }
        public String StudentCode { get; set; }

        // [ForeignKey("SubjectClass")]
        public Int32 SubjectClassId { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }

        // [ForeignKey("Subject")]
        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public String SubjectName { get; set; }

        // List ScoreRecordDetail
        //public virtual IList<ScoreRecordDetail> ScoreRecordDetails { get; set; }
    }
}










