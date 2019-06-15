﻿// <auto-generated />
using System;
using LearningCentre.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearningCentre.Migrations
{
    [DbContext(typeof(LearningCentreContext))]
    [Migration("20190615120544_Update2")]
    partial class Update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LearningCentre.Database.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int?>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("LearningCentre.Database.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("LearningCentre.Database.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("LearningCentre.Database.PlacementTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LevelId");

                    b.Property<DateTime?>("PlacementTestDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("PlacementTest");
                });

            modelBuilder.Entity("LearningCentre.Database.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Citizenship")
                        .HasMaxLength(50);

                    b.Property<int?>("CountryId");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateOfRegistration")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .HasColumnType("nchar(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NativeLanguage")
                        .HasMaxLength(50);

                    b.Property<long?>("PassportNumber");

                    b.Property<string>("PlaceOfStudy");

                    b.Property<int?>("UserProfileId");

                    b.Property<string>("WorkPlace");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("LearningCentre.Database.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("LearningCentre.Database.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<int?>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("LearningCentre.Database.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Role")
                        .HasMaxLength(50);

                    b.Property<string>("Token");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("LearningCentre.Database.City", b =>
                {
                    b.HasOne("LearningCentre.Database.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("LearningCentre.Database.PlacementTest", b =>
                {
                    b.HasOne("LearningCentre.Database.Level", "Level")
                        .WithMany("PlacementTest")
                        .HasForeignKey("LevelId")
                        .HasConstraintName("FK_PlacementTest_Level");
                });

            modelBuilder.Entity("LearningCentre.Database.Student", b =>
                {
                    b.HasOne("LearningCentre.Database.Country", "Country")
                        .WithMany("Student")
                        .HasForeignKey("CountryId");

                    b.HasOne("LearningCentre.Database.UserProfile", "UserProfile")
                        .WithMany("Student")
                        .HasForeignKey("UserProfileId")
                        .HasConstraintName("FK_Student_Country");
                });

            modelBuilder.Entity("LearningCentre.Database.Teacher", b =>
                {
                    b.HasOne("LearningCentre.Database.Subject", "Subject")
                        .WithMany("Teacher")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Teacher_Subject");
                });
#pragma warning restore 612, 618
        }
    }
}