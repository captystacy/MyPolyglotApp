﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPolyglotWeb.Repositories;

namespace MyPolyglotWeb.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20210801105832_AddLessonWithExercisesWithWords")]
    partial class AddLessonWithExercisesWithWords
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyPolyglotWeb.Models.DomainModels.Exercise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<string>("RusPhrase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("MyPolyglotWeb.Models.DomainModels.Lesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LessonName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("MyPolyglotWeb.Models.DomainModels.Words.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ExerciseId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("MyPolyglotWeb.Models.DomainModels.Exercise", b =>
                {
                    b.HasOne("MyPolyglotWeb.Models.DomainModels.Lesson", "Lesson")
                        .WithMany("Exercises")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("MyPolyglotWeb.Models.DomainModels.Words.Word", b =>
                {
                    b.HasOne("MyPolyglotWeb.Models.DomainModels.Exercise", "Exercise")
                        .WithMany("EngPhrase")
                        .HasForeignKey("ExerciseId");

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("MyPolyglotWeb.Models.DomainModels.Exercise", b =>
                {
                    b.Navigation("EngPhrase");
                });

            modelBuilder.Entity("MyPolyglotWeb.Models.DomainModels.Lesson", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
