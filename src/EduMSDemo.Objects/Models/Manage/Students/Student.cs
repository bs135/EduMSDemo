using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class Student : BaseModel
    {
        [Required]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public String Code { get; set; }

        [Required]
        [StringLength(128)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String PlaceOfBirth { get; set; }

        public String Sex { get; set; }

        [StringLength(512)]
        public String Address { get; set; }

        [StringLength(256)]
        [EmailAddress]
        public String Email { get; set; }

        [StringLength(256)]
        [Phone]
        public String PhoneNumber { get; set; }

        //[ForeignKey("Account")]
        public Int32 AccountId { get; set; }
        public virtual Account Account { get; set; }

        // [ForeignKey("StudentClass")]
        public Int32 StudentClassId { get; set; }
        public virtual StudentClass StudentClass { get; set; }

        // List ScoreRecord
        public virtual IList<ScoreRecord> ScoreRecords { get; set; }

        // List BonusScore
        public virtual IList<BonusScore> BonusScores { get; set; }

    }
}










