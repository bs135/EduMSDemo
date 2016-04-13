using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class PreSubjectView : BaseView
    {
        //[ForeignKey("PreOfSubject")]
        public Int32 PreOfSubjectId { get; set; }
        public virtual Subject PreOfSubject { get; set; }
        public String PreOfSubjectName { get; set; }

        //[ForeignKey("SubjectOfPre")]
        public Int32 SubjectOfPreId { get; set; }
        public virtual Subject SubjectOfPre { get; set; }
        public String SubjectOfPreName { get; set; }

    }
}










