using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class SubjectClassView : BaseView
    {
        //[Required]
        //[StringLength(128)]
        //public String Name { get; set; }

        //[ForeignKey("Subject")]
        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual String SubjectName { get; set; }

        //[ForeignKey("Staff")]
        public Int32 StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual String StaffName { get; set; }

        //[ForeignKey("RoomOfMidtermExam")]
        public Int32 RoomOfMidtermExamId { get; set; }
        public virtual ClassRoom RoomOfMidtermExam { get; set; }
        public String RoomOfMidtermExamName { get; set; }
        public String RoomOfMidtermExamCode { get; set; }

        //[ForeignKey("RoomOfTermExam")]
        public Int32 RoomOfTermExamId { get; set; }
        public virtual ClassRoom RoomOfTermExam { get; set; }
        public String RoomOfTermExamName { get; set; }
        public String RoomOfTermExamCode { get; set; }

        //[ForeignKey("RoomOfClass")]
        public Int32 RoomOfClassId { get; set; }
        public virtual ClassRoom RoomOfClass { get; set; }
        public String RoomOfClassName { get; set; }
        public String RoomOfClassCode { get; set; }

        //[ForeignKey("Semester")]
        public Int32 SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        public String SemesterName { get; set; }

        // List SubjectClassTeacher
        //public virtual IList<SubjectClassTeacher> SubjectClassTeachers { get; set; }

        // List ScoreRecord
        //public virtual IList<ScoreRecord> ScoreRecords { get; set; }
    }
}










