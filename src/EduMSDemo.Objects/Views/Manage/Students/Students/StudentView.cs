using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class StudentView : BaseView
    {
        [Required]
        [StringLength(32)]
        //[Index(IsUnique = true)]
        public String Code { get; set; }

        [Required]
        [StringLength(128)]
        public String Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String PlaceOfBirth { get; set; }

        public String Gender { get; set; }

        [StringLength(512)]
        public String Address { get; set; }

        //[StringLength(256)]
        //[EmailAddress]
        //public String Email { get; set; }

        [StringLength(256)]
        [Phone]
        public String PhoneNumber { get; set; }

        //[ForeignKey("Account")]
        public Int32 AccountId { get; set; }
        public virtual Account Account { get; set; }
        //public virtual String AccountUsername { get; set; }
        public virtual String AccountEmail { get; set; }

        // [ForeignKey("StudentClass")]
        public Int32 StudentClassId { get; set; }
        public virtual StudentClass StudentClass { get; set; }
        public String StudentClassName { get; set; }
        public String StudentClassCurriculumName { get; set; }


        // List ScoreRecord
        //public virtual IList<ScoreRecord> ScoreRecords { get; set; }

        // List BonusScore
        //public virtual IList<BonusScore> BonusScores { get; set; }

    }
}










