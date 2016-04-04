using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class Product : BaseModel
    {
        [Required]
        [StringLength(256)]
        [Index(IsUnique = true)]
        public String SKU { get; set; }

        [Required]
        [StringLength(256)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        public Int32 StockQuanlity { get; set; }

        public Boolean IsActive { get; set; }

        // [ForeignKey("ProductGroup")]
        public Int32 ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }

    }
}
