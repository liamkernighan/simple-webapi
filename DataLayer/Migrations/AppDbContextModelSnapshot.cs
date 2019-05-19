﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsGroup");

                    b.Property<int?>("ParentId");

                    b.Property<bool>("SoftDeleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(85);

                    b.Property<long>("UniversalTimeTicks")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("IsGroup");

                    b.HasIndex("ParentId");

                    b.HasIndex("Title");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataLayer.Models.FacebookPage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AdAccountId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("Deactivated");

                    b.Property<long>("UniversalTimeTicks")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("FacebookPages");
                });

            modelBuilder.Entity("DataLayer.Models.InsightsLoaderState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AdAccountId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Success");

                    b.Property<long>("UniversalTimeTicks")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("AdAccountId", "Date")
                        .IsUnique();

                    b.ToTable("InsightsLoaderState");
                });

            modelBuilder.Entity("DataLayer.Models.LeadCampaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<Guid>("FacebookPageId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(85);

                    b.Property<long>("UniversalTimeTicks")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("FacebookPageId");

                    b.ToTable("LeadCampaigns");
                });

            modelBuilder.Entity("DataLayer.Models.LeadCampaignInsights", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AdAccountId");

                    b.Property<long>("AmountSpent");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("LeadCampaignId");

                    b.Property<long>("UniversalTimeTicks")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("LeadCampaignId");

                    b.HasIndex("LeadCampaignId", "Date")
                        .IsUnique();

                    b.ToTable("LeadCampaignInsights");
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Description");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("SoftDeleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<long>("UniversalTimeTicks")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Sku")
                        .IsUnique();

                    b.HasIndex("Title");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Category", b =>
                {
                    b.HasOne("DataLayer.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DataLayer.Models.LeadCampaign", b =>
                {
                    b.HasOne("DataLayer.Models.FacebookPage", "FacebookPage")
                        .WithMany()
                        .HasForeignKey("FacebookPageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.LeadCampaignInsights", b =>
                {
                    b.HasOne("DataLayer.Models.LeadCampaign", "LeadCampaign")
                        .WithMany()
                        .HasForeignKey("LeadCampaignId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.HasOne("DataLayer.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
