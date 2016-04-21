﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class SubjectClass : BaseModel
    {

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

        // List SubjectClassTeacher
        public virtual IList<SubjectClassTeacher> SubjectClassTeachers { get; set; }

        // List ScoreRecord
        public virtual IList<ScoreRecord> ScoreRecords { get; set; }
    }
}









