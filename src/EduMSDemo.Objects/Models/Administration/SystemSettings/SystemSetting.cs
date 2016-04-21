using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class SystemSetting : BaseModel
    {
        [Required]
        [StringLength(64)]
        [Index(IsUnique = true)]
        public String Key { get; set; }

        [StringLength(256)]
        public String ValueString { get; set; }

        public Double ValueDouble { get; set; }
    }
}
