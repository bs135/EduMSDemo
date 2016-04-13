using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class CurriculumDetail : BaseModel
    {
        // [ForeignKey("Curriculum")]
        public Int32 CurriculumId { get; set; }
        public virtual Curriculum Curriculum { get; set; }

        // [ForeignKey("Subject")]
        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        // [ForeignKey("CurriculumType")]
        public Int32 CurriculumTypeId { get; set; }
        public virtual CurriculumType CurriculumType { get; set; }
    }
}
