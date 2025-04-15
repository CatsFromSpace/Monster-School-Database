namespace EF_MonsterSchoolDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(60)]
        public string DepartmentName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
