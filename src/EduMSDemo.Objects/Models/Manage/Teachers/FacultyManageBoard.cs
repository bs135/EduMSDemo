using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class FacultyManageBoard : BaseModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("Dean")]
        public Int32 DeanId { get; set; }
        public virtual Staff Dean { get; set; }

        [ForeignKey("ViceDean1")]
        public Int32 ViceDean1Id { get; set; }
        public virtual Staff ViceDean1 { get; set; }

        [ForeignKey("ViceDean2")]
        public Int32 ViceDean2Id { get; set; }
        public virtual Staff ViceDean2 { get; set; }

    }
}
