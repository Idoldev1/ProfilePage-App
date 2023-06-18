﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfileManagement.Models;

#nullable disable

namespace ProfileManagement.Data
{
    [DbContext(typeof(ProfileDetailsContext))]
    [Migration("20230525095436_SeedDetails")]
    partial class SeedDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("ProfileManagement.Models.ProfileDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Department")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Projects")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProfileDetail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 2,
                            Email = "mark@gmail.com",
                            Experience = "1 year",
                            Name = "Mark",
                            Projects = "Todo App",
                            Skills = "Writing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
