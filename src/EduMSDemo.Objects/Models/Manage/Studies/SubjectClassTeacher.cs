using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class SubjectClassTeacher : BaseModel
    {
        [StringLength(128)]
        public String Accountability { get; set; }

        //[ForeignKey("Staff")]
        public Int32 StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        //[ForeignKey("SubjectClass")]
        public Int32 SubjectClassId { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }
    }
}










