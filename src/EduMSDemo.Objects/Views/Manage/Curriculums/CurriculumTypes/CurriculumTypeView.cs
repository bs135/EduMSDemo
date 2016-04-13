using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class CurriculumTypeView : BaseView
    {
        [Required]
        [StringLength(256)]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        // List CurriculumDetail
        //public virtual IList<CurriculumDetail> CurriculumDetails { get; set; }

    }
}
