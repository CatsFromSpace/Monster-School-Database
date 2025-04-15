using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EF_MonsterSchoolDB
{
    public partial class MonsterSchoolModel1 : DbContext
    {
        public MonsterSchoolModel1()
            : base("name=MonsterSchoolModel1")
        {
        }

        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Cours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Instructors)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseInstructors").MapLeftKey("CourseId").MapRightKey("InstructorId"));

            modelBuilder.Entity<Instructor>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.LName)
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Instructor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.EnrollDate)
                .IsUnicode(false);
        }
    }
}
