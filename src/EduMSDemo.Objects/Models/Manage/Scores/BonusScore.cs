using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class BonusScore : BaseModel
    {
        public Double Score { get; set; }

        public String Note { get; set; }

        // [ForeignKey("Student")]
        public Int32 StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}










