using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class SubjectClass : BaseModel
    {
        //[Required]
        //[StringLength(128)]
        //public String Name { get; set; }

        //[ForeignKey("Subject")]
        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        //[ForeignKey("Staff")]
        public Int32 StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [ForeignKey("RoomOfMidtermExam")]
        public Int32 RoomOfMidtermExamId { get; set; }
        public virtual ClassRoom RoomOfMidtermExam { get; set; }

        [ForeignKey("RoomOfTermExam")]
        public Int32 RoomOfTermExamId { get; set; }
        public virtual ClassRoom RoomOfTermExam { get; set; }

        [ForeignKey("RoomOfClass")]
        public Int32 RoomOfClassId { get; set; }
        public virtual ClassRoom RoomOfClass { get; set; }

        //[ForeignKey("Semester")]
        public Int32 SemesterId { get; set; }
        public virtual Semester Semester { get; set; }

        // List ScoreRecord
        public virtual IList<ScoreRecord> ScoreRecords { get; set; }
    }
}










