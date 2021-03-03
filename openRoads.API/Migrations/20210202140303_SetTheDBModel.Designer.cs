﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210202140303_SetTheDBModel")]
    partial class SetTheDBModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("openRoadsWebAPI.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkingHoursFrom")
                        .HasColumnType("int");

                    b.Property<int>("WorkingHoursTo")
                        .HasColumnType("int");

                    b.Property<string>("ZIPCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchId");

                    b.HasIndex("CountryId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ClientId");

                    b.HasIndex("PersonId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("BranchId");

                    b.HasIndex("PersonId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.EmployeeEmployeeRoles", b =>
                {
                    b.Property<int>("EmployeeEmployeeRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeRolesId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeEmployeeRolesId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmployeeRolesId");

                    b.ToTable("EmployeeEmployeeRoles");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.EmployeeRoles", b =>
                {
                    b.Property<int>("EmployeeRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeRolesId");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Insurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("InsuranceId");

                    b.ToTable("Insurance");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.LoginData", b =>
                {
                    b.Property<int>("LoginDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginDataId");

                    b.ToTable("LoginData");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginDataId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("CountryId");

                    b.HasIndex("LoginDataId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RatingInt")
                        .HasColumnType("int");

                    b.Property<string>("RatingString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Canceled")
                        .HasColumnType("bit");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("DoorsCount")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturedYear")
                        .HasColumnType("int");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PictureThumb")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PowerInHp")
                        .HasColumnType("int");

                    b.Property<float>("PriceByDay")
                        .HasColumnType("real");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatsCount")
                        .HasColumnType("int");

                    b.Property<int>("VehicleCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleFuelTypeId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTransmissionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.HasIndex("BranchId");

                    b.HasIndex("VehicleCategoryId");

                    b.HasIndex("VehicleFuelTypeId");

                    b.HasIndex("VehicleModelId");

                    b.HasIndex("VehicleTransmissionTypeId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.VehicleCategory", b =>
                {
                    b.Property<int>("VehicleCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleCategoryId");

                    b.ToTable("VehicleCategory");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.VehicleFuelType", b =>
                {
                    b.Property<int>("VehicleFuelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleFuelTypeId");

                    b.ToTable("VehicleFuelType");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.VehicleManufacturer", b =>
                {
                    b.Property<int>("VehicleManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleManufacturerId");

                    b.ToTable("VehicleManufacturer");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.VehicleModel", b =>
                {
                    b.Property<int>("VehicleModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleManufacturerId")
                        .HasColumnType("int");

                    b.HasKey("VehicleModelId");

                    b.HasIndex("VehicleManufacturerId");

                    b.ToTable("VehicleModel");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.VehicleTransmissionType", b =>
                {
                    b.Property<int>("VehicleTransmissionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleTransmissionTypeId");

                    b.ToTable("VehicleTransmissionType");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleType");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Branch", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Client", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Employee", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.EmployeeEmployeeRoles", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.EmployeeRoles", "EmployeeRoles")
                        .WithMany()
                        .HasForeignKey("EmployeeRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("EmployeeRoles");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Person", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.LoginData", "LoginData")
                        .WithMany()
                        .HasForeignKey("LoginDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("LoginData");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Rating", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Reservation");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Reservation", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Insurance");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.Vehicle", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.VehicleCategory", "VehicleCategory")
                        .WithMany()
                        .HasForeignKey("VehicleCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.VehicleFuelType", "VehicleFuelType")
                        .WithMany()
                        .HasForeignKey("VehicleFuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.VehicleTransmissionType", "VehicleTransmissionType")
                        .WithMany()
                        .HasForeignKey("VehicleTransmissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("openRoadsWebAPI.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("VehicleCategory");

                    b.Navigation("VehicleFuelType");

                    b.Navigation("VehicleModel");

                    b.Navigation("VehicleTransmissionType");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("openRoadsWebAPI.Models.VehicleModel", b =>
                {
                    b.HasOne("openRoadsWebAPI.Models.VehicleManufacturer", "VehicleManufacturer")
                        .WithMany()
                        .HasForeignKey("VehicleManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleManufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}
