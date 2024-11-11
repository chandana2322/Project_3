using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace project3WithDBFirstAndLinq.Models;

public partial class Projectsql3Context : DbContext
{
    public Projectsql3Context()
    {
    }

    public Projectsql3Context(DbContextOptions<Projectsql3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressInformation> AddressInformations { get; set; }

    public virtual DbSet<Bankdetail> Bankdetails { get; set; }

    public virtual DbSet<ContactInformation> ContactInformations { get; set; }

    public virtual DbSet<Educationinfo> Educationinfos { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Employmentinfo> Employmentinfos { get; set; }

    public virtual DbSet<MemberInformation> MemberInformations { get; set; }

    public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3308;database=projectsql3;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AddressInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("address_information");

            entity.HasIndex(e => e.Uid, "UID");

            entity.Property(e => e.AddressLine1).HasMaxLength(100);
            entity.Property(e => e.AddressLine2).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.ResidentialStatus).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(d => d.UidNavigation).WithMany()
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("address_information_ibfk_1");
        });

        modelBuilder.Entity<Bankdetail>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PRIMARY");

            entity.ToTable("bankdetails");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.AccountHolderName).HasMaxLength(100);
            entity.Property(e => e.AccountNumber).HasMaxLength(20);
            entity.Property(e => e.AccountType).HasMaxLength(20);
            entity.Property(e => e.BankBranch).HasMaxLength(100);
            entity.Property(e => e.BankCountry).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(100);
            entity.Property(e => e.Currency).HasMaxLength(10);
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(20)
                .HasColumnName("IFSCCode");
            entity.Property(e => e.SwiftCode).HasMaxLength(20);

            entity.HasOne(d => d.UidNavigation).WithOne(p => p.Bankdetail)
                .HasForeignKey<Bankdetail>(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bankdetails_ibfk_1");
        });

        modelBuilder.Entity<ContactInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("contact_information");

            entity.HasIndex(e => e.Uid, "UID");

            entity.Property(e => e.AlternatePhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactName).HasMaxLength(50);
            entity.Property(e => e.EmergencyContactPhone).HasMaxLength(15);
            entity.Property(e => e.EmergencyContactRelation).HasMaxLength(50);
            entity.Property(e => e.FacebookProfile).HasMaxLength(100);
            entity.Property(e => e.LinkedInProfile).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.TwitterHandle).HasMaxLength(50);
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.UidNavigation).WithMany()
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("contact_information_ibfk_1");
        });

        modelBuilder.Entity<Educationinfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("educationinfo");

            entity.HasIndex(e => e.Uid, "UID");

            entity.Property(e => e.Certifications).HasMaxLength(100);
            entity.Property(e => e.Degree).HasMaxLength(50);
            entity.Property(e => e.Gpa)
                .HasPrecision(3, 2)
                .HasColumnName("GPA");
            entity.Property(e => e.HighSchoolName).HasMaxLength(100);
            entity.Property(e => e.Major).HasMaxLength(50);
            entity.Property(e => e.Scholarships).HasMaxLength(100);
            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.UniversityName).HasMaxLength(100);

            entity.HasOne(d => d.UidNavigation).WithMany()
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("educationinfo_ibfk_1");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Employmentinfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("employmentinfo");

            entity.HasIndex(e => e.Uid, "UID");

            entity.Property(e => e.EmployerName).HasMaxLength(100);
            entity.Property(e => e.JobDescription).HasColumnType("text");
            entity.Property(e => e.JobTitle).HasMaxLength(100);
            entity.Property(e => e.Salary).HasPrecision(10, 2);
            entity.Property(e => e.SupervisorName).HasMaxLength(100);
            entity.Property(e => e.SupervisorPhone).HasMaxLength(15);
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.UidNavigation).WithMany()
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("employmentinfo_ibfk_1");
        });

        modelBuilder.Entity<MemberInformation>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PRIMARY");

            entity.ToTable("member_information");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<PersonalInfo>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PRIMARY");

            entity.ToTable("personal_info");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Hobbies).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MaritalStatus).HasMaxLength(20);
            entity.Property(e => e.Nationality).HasMaxLength(50);
            entity.Property(e => e.PassportNumber).HasMaxLength(20);
            entity.Property(e => e.Religion).HasMaxLength(50);
            entity.Property(e => e.Ssn)
                .HasMaxLength(20)
                .HasColumnName("SSN");

            entity.HasOne(d => d.UidNavigation).WithOne(p => p.PersonalInfo)
                .HasForeignKey<PersonalInfo>(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personal_info_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
