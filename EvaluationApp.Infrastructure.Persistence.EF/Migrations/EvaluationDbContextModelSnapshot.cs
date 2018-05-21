﻿// <auto-generated />
using System;
using Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.EF.Migrations
{
    [DbContext(typeof(EvaluationDbContext))]
    partial class EvaluationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModel.Domain.Criteria", b =>
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

            modelBuilder.Entity("DomainModel.Domain.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EvaluationName");

                    b.Property<int>("FormId");

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

            modelBuilder.Entity("DomainModel.Domain.EvaluationScale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EvaluationScales");
                });

            modelBuilder.Entity("DomainModel.Domain.EvaluationScaleOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("EvaluationScaleId");

                    b.Property<string>("Name");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationScaleId");

                    b.ToTable("EvaluationScaleOption");
                });

            modelBuilder.Entity("DomainModel.Domain.Importance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Importance");
                });

            modelBuilder.Entity("DomainModel.Domain.Section", b =>
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

            modelBuilder.Entity("DomainModel.Domain.Criteria", b =>
                {
                    b.HasOne("DomainModel.Domain.EvaluationScaleOption", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId");

                    b.HasOne("DomainModel.Domain.Section")
                        .WithMany("Criteria")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("DomainModel.Domain.Evaluation", b =>
                {
                    b.HasOne("DomainModel.Domain.Importance", "Importance")
                        .WithMany()
                        .HasForeignKey("ImportanceId");
                });

            modelBuilder.Entity("DomainModel.Domain.EvaluationScaleOption", b =>
                {
                    b.HasOne("DomainModel.Domain.EvaluationScale", "EvaluationScale")
                        .WithMany("EvaluationScaleOptions")
                        .HasForeignKey("EvaluationScaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModel.Domain.Section", b =>
                {
                    b.HasOne("DomainModel.Domain.Evaluation", "Evaluation")
                        .WithMany("Sections")
                        .HasForeignKey("EvaluationId");

                    b.HasOne("DomainModel.Domain.EvaluationScale", "EvaluationScale")
                        .WithMany()
                        .HasForeignKey("EvaluationScaleId");
                });
#pragma warning restore 612, 618
        }
    }
}
