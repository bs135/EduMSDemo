using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduMSDemo.Objects
{
    public class Staff : BaseModel
    {
        [Required]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public String Code { get; set; }

        [Required]
        [StringLength(128)]
        [Index(IsUnique = true)]
        public String Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String PlaceOfBirth { get; set; }

        public String Gender { get; set; }

        [StringLength(512)]
        public String Address { get; set; }

        [StringLength(256)]
        [EmailAddress]
        public String Email { get; set; }

        [StringLength(256)]
        [Phone]
        public String PhoneNumber { get; set; }

        //[ForeignKey("Account")]
        public Int32 AccountId { get; set; }
        public virtual Account Account { get; set; }

        // [ForeignKey("Department")]
        public Int32 DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        // List DEAN
        [InverseProperty("Dean")]
        public virtual IList<FacultyManageBoard> Deans { get; set; }

        // List VICE1
        [InverseProperty("ViceDean1")]
        public virtual IList<FacultyManageBoard> ViceDean1s { get; set; }

        // List VICE2
        [InverseProperty("ViceDean2")]
        public virtual IList<FacultyManageBoard> ViceDean2s { get; set; }

        // List SubjectClassTeacher
        public virtual IList<SubjectClassTeacher> SubjectClassTeachers { get; set; }

        // List StudentClass
        public virtual IList<StudentClass> StudentClasses { get; set; }
    }
}










