﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteMercado.Infrastructure.Database;

namespace SiteMercado.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210213234514_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiteMercado.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(500");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Description");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
