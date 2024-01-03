﻿// <auto-generated />
using System;
using ConsoleLesha;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleLesha.Migrations
{
    [DbContext(typeof(WSContext))]
    [Migration("20240103185601_updat")]
    partial class updat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsoleLesha.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Finished")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Started")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ConsoleLesha.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConsoleLesha.HelmetProduct", b =>
                {
                    b.HasBaseType("ConsoleLesha.Product");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.ToTable("HelmetProduct", (string)null);
                });

            modelBuilder.Entity("ConsoleLesha.SkiBootsProduct", b =>
                {
                    b.HasBaseType("ConsoleLesha.Product");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.ToTable("SkiBootsProduct", (string)null);
                });

            modelBuilder.Entity("ConsoleLesha.SkiPoleProduct", b =>
                {
                    b.HasBaseType("ConsoleLesha.Product");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SkiPoleProduct", (string)null);
                });

            modelBuilder.Entity("ConsoleLesha.SkiProduct", b =>
                {
                    b.HasBaseType("ConsoleLesha.Product");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Width")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SkiProduct", (string)null);
                });

            modelBuilder.Entity("ConsoleLesha.Product", b =>
                {
                    b.HasOne("ConsoleLesha.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleLesha.HelmetProduct", b =>
                {
                    b.HasOne("ConsoleLesha.Product", null)
                        .WithOne()
                        .HasForeignKey("ConsoleLesha.HelmetProduct", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleLesha.SkiBootsProduct", b =>
                {
                    b.HasOne("ConsoleLesha.Product", null)
                        .WithOne()
                        .HasForeignKey("ConsoleLesha.SkiBootsProduct", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleLesha.SkiPoleProduct", b =>
                {
                    b.HasOne("ConsoleLesha.Product", null)
                        .WithOne()
                        .HasForeignKey("ConsoleLesha.SkiPoleProduct", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleLesha.SkiProduct", b =>
                {
                    b.HasOne("ConsoleLesha.Product", null)
                        .WithOne()
                        .HasForeignKey("ConsoleLesha.SkiProduct", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleLesha.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
