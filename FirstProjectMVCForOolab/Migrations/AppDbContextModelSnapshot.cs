﻿// <auto-generated />
using System;
using FirstProjectMVCForOolab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstProjectMVCForOolab.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.36");

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MembershipTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DurationInMonth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("signUpFee")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("membershipTypes");
                });

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("movies");
                });

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.Customer", b =>
                {
                    b.HasOne("FirstProjectMVCForOolab.Models.MembershipType", null)
                        .WithMany("customers")
                        .HasForeignKey("MembershipTypeId");
                });

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.Movie", b =>
                {
                    b.HasOne("FirstProjectMVCForOolab.Models.Genre", null)
                        .WithMany("movies")
                        .HasForeignKey("GenreId");
                });

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.Genre", b =>
                {
                    b.Navigation("movies");
                });

            modelBuilder.Entity("FirstProjectMVCForOolab.Models.MembershipType", b =>
                {
                    b.Navigation("customers");
                });
#pragma warning restore 612, 618
        }
    }
}
