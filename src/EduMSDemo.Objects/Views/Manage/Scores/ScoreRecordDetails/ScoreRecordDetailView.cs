using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class ScoreRecordDetailView : BaseView
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










