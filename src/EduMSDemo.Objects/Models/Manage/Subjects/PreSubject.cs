using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class PreSubject : BaseModel
    {
        [ForeignKey("PreOfSubject")]
        public Int32 PreOfSubjectId { get; set; }
        public virtual Subject PreOfSubject { get; set; }

        [ForeignKey("SubjectOfPre")]
        public Int32 SubjectOfPreId { get; set; }
        public virtual Subject SubjectOfPre { get; set; }

    }
}










