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
    [Migration("20230211142552_ver1.4.3.1")]
    partial class ver1431
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

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("LastModifyByID");

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

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("FeedbackID");

                    b.HasIndex("ParkingID");

                    b.HasIndex("SlotID");

                    b.HasIndex("UserID");

                    b.ToTable("Images");
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

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<double>("LAT")
                        .HasColumnType("float");

                    b.Property<double>("LON")
                        .HasColumnType("float");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifyByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("DashboardID");

                    b.HasIndex("LastModifyByID");

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

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("CarID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("SlotID");

                    b.HasIndex("TimeFrameID");

                    b.ToTable("ParkingDetail");
                });

            modelBuilder.Entity("Back_end.Entities.Request", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestbyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("ParkingID");

                    b.HasIndex("RequestbyID");

                    b.ToTable("Requests");
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

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfSlot")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("CarID");

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("ParkingID");

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

                    b.Property<Guid>("ParkingsID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("LastModifyByID");

                    b.HasIndex("ParkingsID");

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

                    b.Property<DateTime>("LastModifyAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MembershipPackageID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParkingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasIndex("MembershipPackageID");

                    b.HasIndex("ParkingID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = new Guid("ab6de029-f760-4099-8296-37fd7b3c2b6b"),
                            DateOfBirth = new DateTime(2000, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Phuc",
                            Gender = 0,
                            HashPasword = "$2b$10$SN0Axy2LTcHVHmWrl6BRn.J0Plj092pWemt..ItvMtjua8XnMGibi",
                            LastModifyAt = new DateTime(2023, 2, 11, 21, 25, 52, 9, DateTimeKind.Local).AddTicks(8503),
                            LastName = "Nguyen Van",
                            PhoneNumber = "0966416708",
                            Role = 0,
                            UserName = "phucnv"
                        },
                        new
                        {
                            ID = new Guid("4ed83d2b-8482-4a29-b1ec-dfa568e63bde"),
                            DateOfBirth = new DateTime(2000, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Duy",
                            Gender = 0,
                            HashPasword = "$2b$10$w4S73i0JCV157iepOOrPKeS31E0jFPuTeO56ltq8GFO0G2c.MGCDm",
                            LastModifyAt = new DateTime(2023, 2, 11, 21, 25, 52, 84, DateTimeKind.Local).AddTicks(1893),
                            LastName = "Phung Nam",
                            PhoneNumber = "0945454587",
                            Role = 0,
                            UserName = "duypn"
                        },
                        new
                        {
                            ID = new Guid("e7f8fe74-ae77-48a2-8b31-a39d5d642279"),
                            DateOfBirth = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Phong",
                            Gender = 0,
                            HashPasword = "$2b$10$zbi2FWhtzgo4YyuTtulwBeQyt/Dw.ikDuw2GdlOkmTvuRmltSUlii",
                            LastModifyAt = new DateTime(2023, 2, 11, 21, 25, 52, 153, DateTimeKind.Local).AddTicks(437),
                            LastName = "Dao Tuan",
                            PhoneNumber = "0832323201",
                            Role = 0,
                            UserName = "phongdt"
                        });
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

                    b.Navigation("LastModifyBy");
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

                    b.Navigation("Dashboard");

                    b.Navigation("LastModifyBy");
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
                    b.HasOne("Back_end.Entities.Parking", "Parking")
                        .WithMany("Requests")
                        .HasForeignKey("ParkingID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Back_end.Entities.User", "Requestby")
                        .WithMany()
                        .HasForeignKey("RequestbyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parking");

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

                    b.Navigation("Car");

                    b.Navigation("LastModifyBy");

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("Back_end.Entities.TimeFrame", b =>
                {
                    b.HasOne("Back_end.Entities.User", "LastModifyBy")
                        .WithMany()
                        .HasForeignKey("LastModifyByID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.Parking", "Parkings")
                        .WithMany("TimeFrames")
                        .HasForeignKey("ParkingsID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LastModifyBy");

                    b.Navigation("Parkings");
                });

            modelBuilder.Entity("Back_end.Entities.User", b =>
                {
                    b.HasOne("Back_end.Entities.MembershipPackage", "MembershipPackage")
                        .WithMany("SubcribeBy")
                        .HasForeignKey("MembershipPackageID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Back_end.Entities.Parking", null)
                        .WithMany("Users")
                        .HasForeignKey("ParkingID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("MembershipPackage");
                });

            modelBuilder.Entity("Back_end.Entities.Feedback", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Back_end.Entities.MembershipPackage", b =>
                {
                    b.Navigation("SubcribeBy");
                });

            modelBuilder.Entity("Back_end.Entities.Parking", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Requests");

                    b.Navigation("Slots");

                    b.Navigation("TimeFrames");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Back_end.Entities.Slot", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ParkingDetail");
                });

            modelBuilder.Entity("Back_end.Entities.User", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Feedback");

                    b.Navigation("Images");

                    b.Navigation("ParkingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}