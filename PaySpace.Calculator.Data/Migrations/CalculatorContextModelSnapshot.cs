﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaySpace.Calculator.Data;

#nullable disable

namespace PaySpace.Calculator.Data.Migrations
{
    [DbContext(typeof(CalculatorContext))]
    partial class CalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaySpace.Calculator.Data.Models.CalculatorHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Calculator")
                        .HasColumnType("int");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CalculatorHistories");
                });

            modelBuilder.Entity("PaySpace.Calculator.Data.Models.CalculatorSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Calculator")
                        .HasColumnType("int");

                    b.Property<decimal>("From")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RateType")
                        .HasColumnType("int");

                    b.Property<decimal>("To")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CalculatorSettings");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Calculator = 1,
                            From = 0m,
                            Rate = 10m,
                            RateType = 0,
                            To = 8350m
                        },
                        new
                        {
                            Id = 2L,
                            Calculator = 1,
                            From = 8351m,
                            Rate = 15m,
                            RateType = 0,
                            To = 33950m
                        },
                        new
                        {
                            Id = 3L,
                            Calculator = 1,
                            From = 33951m,
                            Rate = 25m,
                            RateType = 0,
                            To = 82250m
                        },
                        new
                        {
                            Id = 4L,
                            Calculator = 1,
                            From = 82251m,
                            Rate = 28m,
                            RateType = 0,
                            To = 171550m
                        },
                        new
                        {
                            Id = 5L,
                            Calculator = 1,
                            From = 171551m,
                            Rate = 33m,
                            RateType = 0,
                            To = 372950m
                        },
                        new
                        {
                            Id = 6L,
                            Calculator = 1,
                            From = 372951m,
                            Rate = 35m,
                            RateType = 0,
                            To = 79228162514264337593543950335m
                        },
                        new
                        {
                            Id = 7L,
                            Calculator = 2,
                            From = 0m,
                            Rate = 5m,
                            RateType = 0,
                            To = 199999m
                        },
                        new
                        {
                            Id = 8L,
                            Calculator = 2,
                            From = 200000m,
                            Rate = 10000m,
                            RateType = 1,
                            To = 79228162514264337593543950335m
                        },
                        new
                        {
                            Id = 9L,
                            Calculator = 3,
                            From = 0m,
                            Rate = 17.5m,
                            RateType = 0,
                            To = 79228162514264337593543950335m
                        });
                });

            modelBuilder.Entity("PaySpace.Calculator.Data.Models.PostalCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Calculator")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PostalCodes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Calculator = 1,
                            Code = "7441"
                        },
                        new
                        {
                            Id = 2L,
                            Calculator = 2,
                            Code = "A100"
                        },
                        new
                        {
                            Id = 3L,
                            Calculator = 3,
                            Code = "7000"
                        },
                        new
                        {
                            Id = 4L,
                            Calculator = 1,
                            Code = "1000"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
