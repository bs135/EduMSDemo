using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class CurriculumType : BaseModel
    {

        [Required]
        [StringLength(256)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        // List CurriculumDetail
        public virtual IList<CurriculumDetail> CurriculumDetails { get; set; }

    }
}
