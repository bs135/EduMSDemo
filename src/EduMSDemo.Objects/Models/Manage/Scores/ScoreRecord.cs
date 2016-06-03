using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class ScoreRecord : BaseModel
    {
        public DateTime RegigterDate { get; set; }

        // [ForeignKey("Student")]
        public Int32 StudentId { get; set; }
        public virtual Student Student { get; set; }

        // [ForeignKey("SubjectClass")]
        public Int32 SubjectClassId { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }

        //// [ForeignKey("Subject")]
        //public Int32 SubjectId { get; set; }
        //public virtual Subject Subject { get; set; }

        // List ScoreRecordDetail
        public virtual IList<ScoreRecordDetail> ScoreRecordDetails { get; set; }


        public Double? MidTermScore { get; set; }
        public Double? TermScore { get; set; }
        public Double? FinalScore { get; set; }
        public DateTime? DateOfScore { get; set; }

    }
}










