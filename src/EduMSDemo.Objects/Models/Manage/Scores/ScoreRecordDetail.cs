using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class ScoreRecordDetail : BaseModel
    {
        public Double MidTermScore { get; set; }
        public Double TermScore { get; set; }
        public Double FinalScore { get; set; }
        public DateTime DateOfScore { get; set; }

        // [ForeignKey("ScoreRecord")]
        public Int32 ScoreRecordId { get; set; }
        public virtual ScoreRecord ScoreRecord { get; set; }
    }
}










