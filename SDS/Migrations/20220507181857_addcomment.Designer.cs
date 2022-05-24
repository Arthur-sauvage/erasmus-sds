﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SDS.Migrations
{
    [DbContext(typeof(SDSContext))]
    [Migration("20220507181857_addcomment")]
    partial class addcomment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("SDS.Models.Comment", b =>
                {
                    b.Property<int>("IdStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentStudent")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdStudent");

                    b.HasIndex("CourseId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SDS.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ects")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Speciality")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SDS.Models.Comment", b =>
                {
                    b.HasOne("SDS.Models.Course", null)
                        .WithMany("AllComments")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("SDS.Models.Course", b =>
                {
                    b.Navigation("AllComments");
                });
#pragma warning restore 612, 618
        }
    }
}
