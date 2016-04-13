using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class BuildingView : BaseView
    {
        [Required]
        [StringLength(32)]
        //[Index(IsUnique = true)]
        public String Code { get; set; }

        [Required]
        [StringLength(128)]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        public Int32 RoomCount { get; set; }

        // List ClassRoom
        public virtual IList<ClassRoom> ClassRooms { get; set; }
    }
}










