﻿// <auto-generated />
using System;
using DA_LTW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DA_LTW.Migrations
{
    [DbContext(typeof(TourDbContext))]
    partial class TourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DA_LTW.Models.Account", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccount"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdAccount");

                    b.HasIndex("sdt");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DA_LTW.Models.Customer", b =>
                {
                    b.Property<string>("sdt")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sdt");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DA_LTW.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdTour")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdTour");

                    b.HasIndex("sdt");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DA_LTW.Models.Roles", b =>
                {
                    b.Property<int>("IdRoles")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRoles"));

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRoles");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DA_LTW.Models.Tour", b =>
                {
                    b.Property<int>("IdTour")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTour"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Difficult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_tour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("People")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("Started_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalDay")
                        .HasColumnType("int");

                    b.Property<string>("Tour_guide")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTour");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("DA_LTW.Models.UserRole", b =>
                {
                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<int>("IdRoles")
                        .HasColumnType("int");

                    b.HasKey("IdAccount", "IdRoles");

                    b.HasIndex("IdRoles");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DA_LTW.Models.Account", b =>
                {
                    b.HasOne("DA_LTW.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("sdt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DA_LTW.Models.Order", b =>
                {
                    b.HasOne("DA_LTW.Models.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("IdTour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DA_LTW.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("sdt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("DA_LTW.Models.UserRole", b =>
                {
                    b.HasOne("DA_LTW.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DA_LTW.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("IdRoles")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
