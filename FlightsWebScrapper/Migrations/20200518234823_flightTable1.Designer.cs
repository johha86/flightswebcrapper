﻿// <auto-generated />
using System;
using FlightsWebScrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightsWebScrapper.Migrations
{
    [DbContext(typeof(FlightsWebScrapperDbContext))]
    [Migration("20200518234823_flightTable1")]
    partial class flightTable1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayerLibrary.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ActualTimeArrival")
                        .HasColumnType("float");

                    b.Property<double>("ActualTimeDeparture")
                        .HasColumnType("float");

                    b.Property<string>("AircraftModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromAirportFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAirportIATA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("ScheduledTimeArrival")
                        .HasColumnType("float");

                    b.Property<double>("ScheduledTimeDeparture")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAirportFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAirportIATA")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("DataLayerLibrary.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("_Tests");
                });
#pragma warning restore 612, 618
        }
    }
}