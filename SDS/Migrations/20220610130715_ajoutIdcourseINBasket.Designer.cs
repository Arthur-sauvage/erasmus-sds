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
    [Migration("20220610130715_ajoutIdcourseINBasket")]
    partial class ajoutIdcourseINBasket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("SDS.Models.Basket", b =>
                {
                    b.Property<string>("idBasket")
                        .HasColumnType("TEXT");

                    b.Property<string>("idCourse")
                        .HasColumnType("TEXT");

                    b.Property<string>("idStudent")
                        .HasColumnType("TEXT");

                    b.HasKey("idBasket");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("SDS.Models.Comment", b =>
                {
                    b.Property<string>("CommentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentStudent")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DifficultyC")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IDCourse")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdStudent")
                        .HasColumnType("TEXT");

                    b.Property<int>("QualityC")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentId");

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

                    b.Property<int?>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ects")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastComment")
                        .HasColumnType("TEXT");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Quality")
                        .HasColumnType("INTEGER");

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
