using Datalist;
using EduMSDemo.Components.Extensions.Html;
using System;
using System.ComponentModel.DataAnnotations;

namespace EduMSDemo.Objects
{
    public class ProductGroupView : BaseView
    {
        [Required]
        [StringLength(256)]
        [DatalistColumn]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        [StringLength(512)]
        public String Description { get; set; }

        // List Product
        //public virtual IList<Product> Products { get; set; }
    }
}
