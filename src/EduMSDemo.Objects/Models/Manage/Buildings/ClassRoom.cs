using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class ClassRoom : BaseModel
    {
        [Required]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public String Code { get; set; }

        [Required]
        [StringLength(128)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        public Int32 Capacity { get; set; }

        //[ForeignKey("Building")]
        public Int32 BuildingId { get; set; }
        public virtual Building Building { get; set; }

        // List RoomOfMidtermExam
        [InverseProperty("RoomOfMidtermExam")]
        public virtual IList<SubjectClass> RoomOfMidtermExams { get; set; }

        // List RoomOfTermExam
        [InverseProperty("RoomOfTermExam")]
        public virtual IList<SubjectClass> RoomOfTermExams { get; set; }

        // List RoomOfClass
        [InverseProperty("RoomOfClass")]
        public virtual IList<SubjectClass> RoomOfClasses { get; set; }
    }
}










