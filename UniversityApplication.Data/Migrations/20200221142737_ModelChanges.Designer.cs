﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityApplication.Data;

namespace UniversityApplication.Data.Migrations
{
    [DbContext(typeof(UniversityDataContext))]
    [Migration("20200221142737_ModelChanges")]
    partial class ModelChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityApplication.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("UniversityApplication.Data.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Credits")
                        .HasColumnType("decimal(4)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("ProfessorName")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("UniversityApplication.Data.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnName("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DOB")
                        .HasColumnName("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("EnrollmentDate")
                        .IsRequired()
                        .HasColumnName("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<decimal?>("GPA")
                        .HasColumnName("GPA")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentIndex")
                        .IsRequired()
                        .HasColumnName("StudentIndex")
                        .HasColumnType("char(4)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UniversityApplication.Data.Models.Transcript", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(4)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Transcripts");
                });

            modelBuilder.Entity("UniversityApplication.Data.Models.Student", b =>
                {
                    b.HasOne("UniversityApplication.Data.Models.Address", "Address")
                        .WithMany("Students")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniversityApplication.Data.Models.Transcript", b =>
                {
                    b.HasOne("UniversityApplication.Data.Models.Exam", "Exam")
                        .WithMany("Students")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityApplication.Data.Models.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
