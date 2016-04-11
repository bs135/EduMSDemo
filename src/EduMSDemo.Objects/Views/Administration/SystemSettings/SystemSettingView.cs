using Datalist;
using EduMSDemo.Components.Extensions.Html;
using System;
using System.ComponentModel.DataAnnotations;

namespace EduMSDemo.Objects
{
    public class SystemSettingView : BaseView
    {
        [Required]
        [StringLength(64)]
        //[Index(IsUnique = true)]
        public String Key { get; set; }

        [StringLength(256)]
        public String ValueString { get; set; }

        public Double ValueDouble { get; set; }
    }
}
