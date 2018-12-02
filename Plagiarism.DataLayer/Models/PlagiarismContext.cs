using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Plagiarism.DataLayer.Models
{
    public class PlagiarismContext:DbContext
    {
        public PlagiarismContext():base("PlagiarismContext")
        {
            
        }
        public PlagiarismContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<Admin> Administrators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<PlagiarismData> PlagiarismData { get; set; }
        public DbSet<CoreData> CoreData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var adminEntity = modelBuilder.Entity<Admin>();
            var studentEntity = modelBuilder.Entity<Student>();
            var assignmentEntity = modelBuilder.Entity<Assignment>();
            var roleEntity = modelBuilder.Entity<Role>();
            var studentClassEntity = modelBuilder.Entity<StudentClass>();
            var plagiarismDataEntity = modelBuilder.Entity<PlagiarismData>();
            var coreDataEntity = modelBuilder.Entity<CoreData>();


            #region Admin
            adminEntity.HasKey(x => x.ID);
            adminEntity
                .Property(x => x.UserName)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(256);
            adminEntity
                .Property(x => x.PasswordHash)
                .IsRequired()
                .IsUnicode(true);
            adminEntity.ToTable("Admin", "vx");
            #endregion

            #region Student
            studentEntity.HasKey(x => x.ID);
            studentEntity
                .Property(x => x.FullName)
                .HasMaxLength(256)
                .IsRequired()
                .IsUnicode(false);
            studentEntity
                .Property(x => x.UserName)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(256);
            studentEntity
                .Property(x => x.PasswordHash)
                .IsRequired()
                .IsUnicode(true);
            studentEntity
                .Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired()
                .IsUnicode(false);
            studentEntity.HasRequired(x => x.Role);
            studentEntity.HasRequired(x => x.Class).WithMany(x => x.Students).WillCascadeOnDelete();
            studentEntity.HasMany(x => x.Assignments).WithMany(x => x.Students)
                .Map(rel =>
                {
                    rel.MapLeftKey("StudentID");
                    rel.MapLeftKey("AssignmentID");
                    rel.ToTable("StudentAssignment", "vx");
                });
            studentEntity.ToTable("Student", "vx");
            #endregion

            #region Assignment
            assignmentEntity.HasKey(x => x.ID);
            assignmentEntity
                .Property(x => x.AssignmentName)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode();
            assignmentEntity
                .HasRequired(x => x.Class).WithMany(x => x.Assignments).WillCascadeOnDelete();
            assignmentEntity.ToTable("Assignment", "vx");
            #endregion

            #region Role
            roleEntity.HasKey(x => x.ID);
            roleEntity.Property(x => x.RoleName).IsRequired().HasMaxLength(256).IsUnicode(false);
            roleEntity.ToTable("Role", "vx");
            #endregion

            #region Student Class
            studentClassEntity.HasKey(x => x.ID);
            studentClassEntity
                .Property(x => x.ClassName)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode();
            studentClassEntity
                .HasMany(x => x.Assignments)
                .WithRequired(x => x.Class);
            studentClassEntity
                .HasMany(x => x.Students)
                .WithRequired(x => x.Class);
            studentClassEntity
                .ToTable("StudentClass", "vx");
            #endregion

            #region PlagiarismData
            plagiarismDataEntity.HasKey(x => x.ID);
            plagiarismDataEntity
                .Property(x => x.UploadedFilePath)
                .HasMaxLength(1000)
                .IsUnicode(true);
            plagiarismDataEntity.
                Property(x => x.Description)
                .HasMaxLength(256)
                .IsUnicode(false);
            plagiarismDataEntity.Property(x => x.Data)
                .IsUnicode(true)
                .IsMaxLength();
            plagiarismDataEntity
                .HasOptional(x => x.CoreData)
                .WithRequired(x => x.PlagiarismData).WillCascadeOnDelete();
            plagiarismDataEntity
                .ToTable("PlagiarismData", "vx");
            #endregion

            #region CoreData
            coreDataEntity.HasKey(x => x.ID);
            coreDataEntity.HasRequired(x => x.Class);
            coreDataEntity.HasRequired(x => x.Student);
            coreDataEntity.HasRequired(x => x.Assignment);
            coreDataEntity.HasRequired(x => x.PlagiarismData);
            coreDataEntity.ToTable("CoreData", "vx");
            #endregion
        }

    }
}

