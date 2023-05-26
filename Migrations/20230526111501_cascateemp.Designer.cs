﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySqlDemo.Models;

#nullable disable

namespace MySqlDemo.Migrations
{
    [DbContext(typeof(MySqlDemoContext))]
    [Migration("20230526111501_cascateemp")]
    partial class cascateemp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MySqlDemo.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DepartmentCode")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("DepartmentCode")
                        .HasDatabaseName("IDX_Department_DepartmentCode");

                    b.HasIndex("DepartmentName")
                        .HasDatabaseName("IDX_Department_DepartmentName");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("MySqlDemo.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DateOfBirth")
                        .HasDatabaseName("IDX_Employee_DateOfBirth");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmailAddress")
                        .HasDatabaseName("IDX_Employee_EmailAddress");

                    b.HasIndex("FirstName")
                        .HasDatabaseName("IDX_Employee_FirstName");

                    b.HasIndex("LastName")
                        .HasDatabaseName("IDX_Employee_LastName");

                    b.HasIndex("PhoneNumber")
                        .HasDatabaseName("IDX_Employee_PhoneNumber");

                    b.HasIndex("Salary")
                        .HasDatabaseName("IDX_Employee_Salary");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("MySqlDemo.Models.EmployeeAddress", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StateName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Zipcode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AddressLine1")
                        .HasDatabaseName("IDX_EmployeeAddress_AddressLine1");

                    b.HasIndex("AddressLine2")
                        .HasDatabaseName("IDX_EmployeeAddress_AddressLine2");

                    b.HasIndex("City")
                        .HasDatabaseName("IDX_EmployeeAddress_City");

                    b.HasIndex("StateName")
                        .HasDatabaseName("IDX_EmployeeAddress_StateName");

                    b.HasIndex("Zipcode")
                        .HasDatabaseName("IDX_EmployeeAddress_Zipcode");

                    b.ToTable("EmployeeAddress", (string)null);
                });

            modelBuilder.Entity("MySqlDemo.Models.Employee", b =>
                {
                    b.HasOne("MySqlDemo.Models.Department", "Department")
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Department_Employee_DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MySqlDemo.Models.EmployeeAddress", b =>
                {
                    b.HasOne("MySqlDemo.Models.Employee", "Employee")
                        .WithOne("EmployeeAddress")
                        .HasForeignKey("MySqlDemo.Models.EmployeeAddress", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_EmployeeAddress_Employee_EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MySqlDemo.Models.Department", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MySqlDemo.Models.Employee", b =>
                {
                    b.Navigation("EmployeeAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
