namespace EF_MonsterSchoolDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instructor()
        {
            Departments = new HashSet<Department>();
            Courses = new HashSet<Cours>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstructorId { get; set; }

        [Required]
        [StringLength(60)]
        public string FName { get; set; }

        [Required]
        [StringLength(60)]
        public string LName { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cours> Courses { get; set; }
    }
}
