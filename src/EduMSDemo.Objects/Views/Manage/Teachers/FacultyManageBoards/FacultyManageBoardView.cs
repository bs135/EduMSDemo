using Datalist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduMSDemo.Components.Extensions.Html;

namespace EduMSDemo.Objects
{
    public class FacultyManageBoardView : BaseView
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //[ForeignKey("Dean")]
        public Int32 DeanId { get; set; }
        public virtual Staff Dean { get; set; }
        public String DeanName { get; set; }

        //[ForeignKey("ViceDean1")]
        public Int32 ViceDean1Id { get; set; }
        public virtual Staff ViceDean1 { get; set; }
        public String ViceDean1Name { get; set; }

        //[ForeignKey("ViceDean2")]
        public Int32 ViceDean2Id { get; set; }
        public virtual Staff ViceDean2 { get; set; }
        public String ViceDean2Name { get; set; }

    }
}
