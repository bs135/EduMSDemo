using Datalist;
using EduMSDemo.Components.Extensions.Html;
using System;
using System.ComponentModel.DataAnnotations;

namespace EduMSDemo.Objects
{
    public class SystemSettingView : BaseView
    {
        [StringLength(64)]
        public String ValueString { get; set; }

        public Int32 ValueType { get; set; }

        public Double ValueFloat { get; set; }

        public Int32 ValueInt { get; set; }
    }
}
