﻿// <auto-generated />
using System;
using EvaluationApp.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvaluationApp.Persistence.EF.Migrations
{
    [DbContext(typeof(EvaluationDbContext))]
    [Migration("20180509123931_init_migration")]
    partial class init_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EvaluationApp.Domain.Criteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<int?>("GradeId");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int?>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("SectionId");

                    b.ToTable("Criteria");
                });

            modelBuilder.Entity("EvaluationApp.Domain.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EvaluationName");

                    b.Property<string>("FormName");

                    b.Property<int?>("ImportanceId");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("LastEvaluatorId");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ImportanceId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("EvaluationApp.Domain.EvaluationScale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EvaluationScale");
                });

            modelBuilder.Entity("EvaluationApp.Domain.EvaluationScaleOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("EvaluationScaleId");

                    b.Property<string>("Name");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationScaleId");

                    b.ToTable("EvaluationScaleOption");
                });

            modelBuilder.Entity("EvaluationApp.Domain.Importance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Importance");
                });

            modelBuilder.Entity("EvaluationApp.Domain.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<int?>("EvaluationId");

                    b.Property<int?>("EvaluationScaleId");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationId");

                    b.HasIndex("EvaluationScaleId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("EvaluationApp.Domain.Criteria", b =>
                {
                    b.HasOne("EvaluationApp.Domain.EvaluationScaleOption", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId");

                    b.HasOne("EvaluationApp.Domain.Section")
                        .WithMany("Criteria")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("EvaluationApp.Domain.Evaluation", b =>
                {
                    b.HasOne("EvaluationApp.Domain.Importance", "Importance")
                        .WithMany()
                        .HasForeignKey("ImportanceId");
                });

            modelBuilder.Entity("EvaluationApp.Domain.EvaluationScaleOption", b =>
                {
                    b.HasOne("EvaluationApp.Domain.EvaluationScale", "EvaluationScale")
                        .WithMany("EvaluationScaleOptions")
                        .HasForeignKey("EvaluationScaleId");
                });

            modelBuilder.Entity("EvaluationApp.Domain.Section", b =>
                {
                    b.HasOne("EvaluationApp.Domain.Evaluation")
                        .WithMany("Sections")
                        .HasForeignKey("EvaluationId");

                    b.HasOne("EvaluationApp.Domain.EvaluationScale", "EvaluationScale")
                        .WithMany()
                        .HasForeignKey("EvaluationScaleId");
                });
#pragma warning restore 612, 618
        }
    }
}
