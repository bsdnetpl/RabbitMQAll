﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RabbitMQAll.DB;

#nullable disable

namespace RabbitMQAll.Migrations
{
    [DbContext(typeof(Dbconnect))]
    [Migration("20231017165741_inint")]
    partial class inint
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RabbitMQAll.Models.FieldInvoce", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("brutto")
                        .HasColumnType("float");

                    b.Property<Guid>("idInvoce")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nameValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("netto")
                        .HasColumnType("float");

                    b.Property<int>("vat")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idInvoce")
                        .IsUnique();

                    b.ToTable("fieldInvoces");
                });

            modelBuilder.Entity("RabbitMQAll.Models.Invoce", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTimeCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("nipBayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("invoces");
                });

            modelBuilder.Entity("RabbitMQAll.Models.FieldInvoce", b =>
                {
                    b.HasOne("RabbitMQAll.Models.Invoce", "Invoce")
                        .WithOne("fieldInvoce")
                        .HasForeignKey("RabbitMQAll.Models.FieldInvoce", "idInvoce")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoce");
                });

            modelBuilder.Entity("RabbitMQAll.Models.Invoce", b =>
                {
                    b.Navigation("fieldInvoce");
                });
#pragma warning restore 612, 618
        }
    }
}
