﻿// <auto-generated />
using Lab4MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab4MySql.Migrations
{
    [DbContext(typeof(CalculationDbContext))]
    [Migration("20210113183924_resultStringInsteadOfDecimal")]
    partial class resultStringInsteadOfDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lab4Models.Calculation", b =>
                {
                    b.Property<int>("CalculationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("NumberOne")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("NumberTwo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Result")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TypeOfCalculation")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CalculationId");

                    b.ToTable("Calculations");
                });
#pragma warning restore 612, 618
        }
    }
}
