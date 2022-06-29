﻿// <auto-generated />
using System;
using FlightBookingService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightAdminservices.Migrations
{
    [DbContext(typeof(FlightBookingContext))]
    [Migration("20220626160458_addingallthetables")]
    partial class addingallthetables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("FlightAdminservices.Models.DiscountDetails", b =>
                {
                    b.Property<int>("DiscountNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DisCoupon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DiscountNo");

                    b.ToTable("DiscountDetails");
                });

            modelBuilder.Entity("FlightBookingService.Models.AirLineDetail", b =>
                {
                    b.Property<int>("AirLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IsBlocked")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirLineId");

                    b.ToTable("AirLineDetail");
                });

            modelBuilder.Entity("FlightBookingService.Models.FlightDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Airlinename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassOfSeats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("FromLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsInstrumentUsed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ScheduleDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ToLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalSeat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FlightDetail");
                });

            modelBuilder.Entity("FlightBookingService.Models.PassengerBookedFlight", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Airlinename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisCoupon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("FromLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsBooked")
                        .HasColumnType("int");

                    b.Property<string>("MealOption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OnwardDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PnrNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ScheduleDays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("age")
                        .HasColumnType("int");

                    b.Property<string>("contactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("onwardseat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("returnseat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.ToTable("PassengerBookedFlights");
                });
#pragma warning restore 612, 618
        }
    }
}
