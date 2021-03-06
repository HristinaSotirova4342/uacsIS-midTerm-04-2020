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
    [Migration("20200220214532_InitialCreateDB")]
    partial class InitialCreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityApplication.Data.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
