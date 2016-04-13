using Datalist;
using EduMSDemo.Components.Extensions.Html;
using System;
using System.ComponentModel.DataAnnotations;

namespace EduMSDemo.Objects
{
    public class ProductView : BaseView
    {
        [Required]
        [StringLength(256)]
        //[Index(IsUnique = true)]
        public String SKU { get; set; }

        [Required]
        [StringLength(256)]
        [DatalistColumn]
        //[Index(IsUnique = true)]
        public String Name { get; set; }

        public Int32 StockQuanlity { get; set; }

        public Boolean  IsActive { get; set; }

        // [ForeignKey("ProductGroup")]
        public Int32 ProductGroupId { get; set; }
        //public virtual ProductGroup ProductGroup { get; set; }
        public String ProductGroupName { get; set; }

        // List PartNo
        //public virtual IList<PartNo> PartNoes { get; set; }
        //public int PartNoCount { get; set; }

    }
}
