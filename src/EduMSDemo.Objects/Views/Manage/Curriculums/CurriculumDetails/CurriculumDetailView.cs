using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class CurriculumDetailView : BaseView
    {
        // [ForeignKey("Curriculum")]
        public Int32 CurriculumId { get; set; }
        public virtual Curriculum Curriculum { get; set; }
        public String CurriculumName { get; set; }

        // [ForeignKey("Subject")]
        public Int32 SubjectId { get; set; }
        public String SubjectName { get; set; }

        // [ForeignKey("CurriculumType")]
        public Int32 CurriculumTypeId { get; set; }
        public virtual CurriculumType CurriculumType { get; set; }
        public String CurriculumTypeName { get; set; }
    }
}
