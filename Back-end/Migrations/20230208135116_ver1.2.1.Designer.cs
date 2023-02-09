﻿// <auto-generated />
using System;
using Back_end.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ParkingDbContext))]
    [Migration("20230208135116_ver1.2.1")]
    partial class ver121
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Back_end.Entities.Car", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarModelID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CarModelID");

                    b.HasIndex("LastModifyByID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Back_end.Entities.CarModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParkingPriceID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("ParkingPriceID");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Back_end.Entities.Dashboard", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("NumberOfMember")
                        .HasColumnType("bigint");

                    b.Property<double>("Revenue")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("LastModifyByID");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("Back_end.Entities.Feedback", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FeedbackByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("FeedbackByID");

                    b.HasIndex("ParkingID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Back_end.Entities.Image", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FeedbackID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SlotID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("FeedbackID");

                    b.HasIndex("ParkingID");

                    b.HasIndex("SlotID");

                    b.HasIndex("UserID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Back_end.Entities.Location", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LAT")
                        .HasColumnType("bigint");

                    b.Property<long>("LNT")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ParkingID")
                        .IsUnique();

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Back_end.Entities.MembershipPackage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("Months")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("SubcribeAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("MembershipPackages");
                });

            modelBuilder.Entity("Back_end.Entities.Parking", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DashboardID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLegal")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TimeFrameID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("DashboardID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("TimeFrameID");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("Back_end.Entities.ParkingDetail", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SlotID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeFrameID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("SlotID");

                    b.HasIndex("TimeFrameID");

                    b.ToTable("ParkingDetail");
                });

            modelBuilder.Entity("Back_end.Entities.ParkingPrice", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("ParkingPrices");
                });

            modelBuilder.Entity("Back_end.Entities.Request", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestbyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("ParkingID");

                    b.HasIndex("RequestbyID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Back_end.Entities.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Back_end.Entities.Slot", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParkingPriceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("ParkingID");

                    b.HasIndex("ParkingPriceID");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("Back_end.Entities.TimeFrame", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParkingPriceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("ParkingPriceID");

                    b.ToTable("TimeFrame");
                });

            modelBuilder.Entity("Back_end.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HashPasword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ParkingID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Back_end.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.HasKey("UserID", "RoleID");

                    b.HasIndex("RoleID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Back_end.Entities.Car", b =>
                {
                    b.HasOne("Back_end.Entities.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany("Cars")
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CarModel");

                    b.Navigation("LastModifyBy");
                });

            modelBuilder.Entity("Back_end.Entities.CarModel", b =>
                {
                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany()
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.ParkingPrice", "ParkingPrice")
                        .WithMany()
                        .HasForeignKey("ParkingPriceID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LastModifyBy");

                    b.Navigation("ParkingPrice");
                });

            modelBuilder.Entity("Back_end.Entities.Dashboard", b =>
                {
                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany()
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("LastModifyBy");
                });

            modelBuilder.Entity("Back_end.Entities.Feedback", b =>
                {
                    b.HasOne("Back_end.Entities.User", "FeedbackBy")
                        .WithMany("Feedback")
                        .HasForeignKey("FeedbackByID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.Parking", "Parking")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ParkingID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FeedbackBy");

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("Back_end.Entities.Image", b =>
                {
                    b.HasOne("Back_end.Entities.Feedback", "Feedback")
                        .WithMany("Images")
                        .HasForeignKey("FeedbackID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.Parking", "Parking")
                        .WithMany()
                        .HasForeignKey("ParkingID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.Slot", null)
                        .WithMany("Images")
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Feedback");

                    b.Navigation("Parking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Back_end.Entities.Location", b =>
                {
                    b.HasOne("Back_end.Entities.Parking", "Parking")
                        .WithOne("Location")
                        .HasForeignKey("Back_end.Entities.Location", "ParkingID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.User", "User")
                        .WithOne("Location")
                        .HasForeignKey("Back_end.Entities.Location", "UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Back_end.Entities.MembershipPackage", b =>
                {
                    b.HasOne("Back_end.Entities.User", "SubcribeBy")
                        .WithOne("MembershipPackage")
                        .HasForeignKey("Back_end.Entities.MembershipPackage", "UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SubcribeBy");
                });

            modelBuilder.Entity("Back_end.Entities.Parking", b =>
                {
                    b.HasOne("Back_end.Entities.Dashboard", "Dashboard")
                        .WithMany()
                        .HasForeignKey("DashboardID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany()
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.TimeFrame", "TimeFrame")
                        .WithMany("Parkings")
                        .HasForeignKey("TimeFrameID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Dashboard");

                    b.Navigation("LastModifyBy");

                    b.Navigation("TimeFrame");
                });

            modelBuilder.Entity("Back_end.Entities.ParkingDetail", b =>
                {
                    b.HasOne("Back_end.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany("ParkingDetails")
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.Slot", "Slot")
                        .WithMany("ParkingDetail")
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.TimeFrame", "TimeFrame")
                        .WithMany()
                        .HasForeignKey("TimeFrameID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("LastModifyBy");

                    b.Navigation("Slot");

                    b.Navigation("TimeFrame");
                });

            modelBuilder.Entity("Back_end.Entities.Request", b =>
                {
                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany()
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.Parking", null)
                        .WithMany("Bookings")
                        .HasForeignKey("ParkingID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.User", "Requestby")
                        .WithMany()
                        .HasForeignKey("RequestbyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LastModifyBy");

                    b.Navigation("Requestby");
                });

            modelBuilder.Entity("Back_end.Entities.Slot", b =>
                {
                    b.HasOne("Back_end.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany()
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.Parking", "Parking")
                        .WithMany("Slots")
                        .HasForeignKey("ParkingID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.ParkingPrice", "ParkingPrice")
                        .WithMany()
                        .HasForeignKey("ParkingPriceID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Car");

                    b.Navigation("LastModifyBy");

                    b.Navigation("Parking");

                    b.Navigation("ParkingPrice");
                });

            modelBuilder.Entity("Back_end.Entities.TimeFrame", b =>
                {
                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany()
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.ParkingPrice", "ParkingPrice")
                        .WithMany()
                        .HasForeignKey("ParkingPriceID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LastModifyBy");

                    b.Navigation("ParkingPrice");
                });

            modelBuilder.Entity("Back_end.Entities.User", b =>
                {
                    b.HasOne("Back_end.Entities.Parking", null)
                        .WithMany("Users")
                        .HasForeignKey("ParkingID")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Back_end.Entities.UserRole", b =>
                {
                    b.HasOne("Back_end.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Back_end.Entities.Feedback", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Back_end.Entities.Parking", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Feedbacks");

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Slots");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Back_end.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Back_end.Entities.Slot", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ParkingDetail");
                });

            modelBuilder.Entity("Back_end.Entities.TimeFrame", b =>
                {
                    b.Navigation("Parkings");
                });

            modelBuilder.Entity("Back_end.Entities.User", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Feedback");

                    b.Navigation("Images");

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("MembershipPackage")
                        .IsRequired();

                    b.Navigation("ParkingDetails");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
