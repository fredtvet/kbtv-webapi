﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infrastructure.data.migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("CleanArchitecture.Core.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(45);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT")
                        .HasMaxLength(12);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<int?>("EmployerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Finished")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<int?>("MissionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT")
                        .HasMaxLength(12);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("MissionTypeId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.MissionDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("MissionId");

                    b.ToTable("MissionDocuments");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.MissionImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("MissionImages");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.MissionNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Pinned")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(75);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("MissionNotes");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.MissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(45);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MissionTypes");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(400);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalHours")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Mission", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Employer", "Employer")
                        .WithMany("Missions")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CleanArchitecture.Core.Entities.MissionType", "MissionType")
                        .WithMany("Missions")
                        .HasForeignKey("MissionTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.MissionDocument", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.DocumentType", "DocumentType")
                        .WithMany("MissionDocuments")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Core.Entities.Mission", "Mission")
                        .WithMany("MissionDocuments")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.MissionImage", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Mission", "Mission")
                        .WithMany("MissionImages")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.MissionNote", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Mission", "Mission")
                        .WithMany("MissionNotes")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Core.Entities.Timesheet", b =>
                {
                    b.HasOne("CleanArchitecture.Core.Entities.Mission", "Mission")
                        .WithMany("Timesheets")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
