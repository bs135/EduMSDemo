using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class ProductGroup : BaseModel
    {
        [Required]
        [StringLength(256)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        [StringLength(512)]
        public String Description { get; set; }

        // List Product
        public virtual IList<Product> Products { get; set; }

    }
}
