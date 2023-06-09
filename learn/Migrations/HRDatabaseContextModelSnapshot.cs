﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using learn.Models;

#nullable disable

namespace learn.Migrations
{
    [DbContext(typeof(HRDatabaseContext))]
    partial class HRDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("learn.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentAbbr")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", "dbo");
                });

            modelBuilder.Entity("learn.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("EmployeeNumber")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<decimal>("GrossSalary")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NetSalary")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
