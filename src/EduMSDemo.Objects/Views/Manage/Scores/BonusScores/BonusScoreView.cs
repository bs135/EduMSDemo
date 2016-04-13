using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class BonusScoreView : BaseView
    {
        public Double Score { get; set; }

        public String Note { get; set; }

        // [ForeignKey("Student")]
        public Int32 StudentId { get; set; }
        public virtual Student Student { get; set; }
        public String StudentName { get; set; }
        public String StudentCode { get; set; }
    }
}










