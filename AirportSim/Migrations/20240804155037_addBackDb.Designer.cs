﻿// <auto-generated />
using System;
using AirportSim.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirportSim.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240804155037_addBackDb")]
    partial class addBackDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirportSim.Models.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"));

                    b.Property<Guid>("FlightNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FlightStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("In")
                        .HasColumnType("datetime2");

                    b.Property<int>("Leg")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Out")
                        .HasColumnType("datetime2");

                    b.HasKey("LogId");

                    b.ToTable("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
