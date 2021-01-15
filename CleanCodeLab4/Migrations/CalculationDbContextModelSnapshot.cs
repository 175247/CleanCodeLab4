﻿// <auto-generated />
using CleanCodeLab4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanCodeLab4.Migrations
{
    [DbContext(typeof(CalculationDbContext))]
    partial class CalculationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CleanCodeLab4.Models.CalculationResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("FirstNumber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MeansOfCalculation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SecondNumber")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CalculationResults");
                });
#pragma warning restore 612, 618
        }
    }
}
