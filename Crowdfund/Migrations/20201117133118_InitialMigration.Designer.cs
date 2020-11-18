﻿// <auto-generated />
using System;
using Crowdfund.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crowdfund.Migrations
{
    [DbContext(typeof(CrowdfundDbContext))]
    [Migration("20201117133118_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crowdfund.model.Backer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Backer");
                });

            modelBuilder.Entity("Crowdfund.model.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Media");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Media");
                });

            modelBuilder.Entity("Crowdfund.model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackerId")
                        .HasColumnType("int");

                    b.Property<decimal>("BudgetRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrentBudget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectCreatorId")
                        .HasColumnType("int");

                    b.Property<decimal>("TargetBudget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BackerId");

                    b.HasIndex("ProjectCreatorId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Crowdfund.model.ProjectCreator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectCreator");
                });

            modelBuilder.Entity("Crowdfund.model.RewardPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Reward")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BackerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("RewardPackage");
                });

            modelBuilder.Entity("Crowdfund.model.Photo", b =>
                {
                    b.HasBaseType("Crowdfund.model.Media");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasIndex("ProjectId");

                    b.HasDiscriminator().HasValue("Photo");
                });

            modelBuilder.Entity("Crowdfund.model.Video", b =>
                {
                    b.HasBaseType("Crowdfund.model.Media");

                    b.Property<int?>("ProjectId")
                        .HasColumnName("Video_ProjectId")
                        .HasColumnType("int");

                    b.HasIndex("ProjectId");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("Crowdfund.model.Project", b =>
                {
                    b.HasOne("Crowdfund.model.Backer", null)
                        .WithMany("Projects")
                        .HasForeignKey("BackerId");

                    b.HasOne("Crowdfund.model.ProjectCreator", "ProjectCreator")
                        .WithMany()
                        .HasForeignKey("ProjectCreatorId");
                });

            modelBuilder.Entity("Crowdfund.model.RewardPackage", b =>
                {
                    b.HasOne("Crowdfund.model.Backer", null)
                        .WithMany("RewardPackages")
                        .HasForeignKey("BackerId");

                    b.HasOne("Crowdfund.model.Project", "Project")
                        .WithMany("RewardPackages")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Crowdfund.model.Photo", b =>
                {
                    b.HasOne("Crowdfund.model.Project", null)
                        .WithMany("Photos")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Crowdfund.model.Video", b =>
                {
                    b.HasOne("Crowdfund.model.Project", null)
                        .WithMany("Videos")
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
