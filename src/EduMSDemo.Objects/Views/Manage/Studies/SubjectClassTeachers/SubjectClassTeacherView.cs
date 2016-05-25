using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class SubjectClassTeacherView : BaseView
    {
        [StringLength(128)]
        public String Accountability { get; set; }

        //[ForeignKey("Staff")]
        public Int32 StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public String StaffName { get; set; }

        //[ForeignKey("SubjectClass")]
        public Int32 SubjectClassId { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }
        public virtual String SubjectClassSubjectName { get; set; }
    }
}










