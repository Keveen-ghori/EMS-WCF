using EMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EMS.Infrastructure.Settings
{
    public class EmployeeManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("server=PCI101\\SQL2019;Database=EmployeeManagement;User Id=sa;Password=Tatva@123;Trusted_connection=SSPI;Encrypt=false;TrustServerCertificate=True");

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4888E0BB2B6");

                entity.ToTable("Admin");

                entity.HasIndex(e => e.Email).IsUnique().HasName("UQ__Admin__A9D10534FA250DDC");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At");
                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_AT");
                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");
                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false);
                entity.Property(e => e.ExpDays)
                    .HasDefaultValueSql("((7))")
                    .HasColumnName("Exp_Days");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.PasswordUpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Password_Updated_At");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F115CAF5691");

                entity.HasIndex(e => e.Email).IsUnique().HasName("UQ__Employee__A9D10534559D0D9F");

                entity.Property(e => e.Attemps).HasDefaultValueSql("((0))");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnName("Created_At");
                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_AT");
                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");
                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false);
                entity.Property(e => e.ExpDays)
                    .HasDefaultValueSql("((7))")
                    .HasColumnName("Exp_days");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.PasswordUpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Password_Updated_At");
                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
                entity.Property(e => e.TotalAttemps).HasColumnName("Total_Attemps");
                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_At");
                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

        }

    }
}
