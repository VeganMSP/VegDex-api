﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VegDex.Infrastructure.Context;

#nullable disable

namespace VegDex.Infrastructure.Migrations
{
    [DbContext(typeof(VegDexContext))]
    [Migration("20230406011902_AddMetaPagesDateInformation")]
    partial class AddMetaPagesDateInformation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("VegDex.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street2")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.BlogCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BlogCategory", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("BlogPost", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.FarmersMarket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hours")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("FarmersMarket", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("LinkCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LinkCategoryId");

                    b.ToTable("Link", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.LinkCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LinkCategory", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.Meta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AboutPage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AboutPageCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AboutPageLastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HomePageCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HomePageLastUpdated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Meta", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AboutPage = "VeganMSP.com is a new project from <a href=\"https://jrgnsn.net\" target=\"_blank\">Matthew Jorgensen</a>. Inspired\nby <a href=\"https://veganmilwaukee.com/\" target=\"_blank\">VeganMKE.com</a>, this site aims to be a complete-as-possible\nguide to being vegan in and around the Minneapolis/St. Paul area. But\nwe're always welcome to suggestions! Find something wrong? Feel free to\n<a href=\"https://github.com/VeganMSP/VeganMSP.com/issues\">open a ticket</a> on our tracker.",
                            AboutPageCreated = new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5660),
                            AboutPageLastUpdated = new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5670),
                            HomePage = "It’s easy being vegan in Minneapolis and St. Paul, but it can be hard to\nknow where to start, or where to look for information and answers. We\naim to fix that.\n\nAt VeganMSP.com you will find restaurant and food guides, shopping\nguides, and other information to help you on your vegan journey.",
                            HomePageCreated = new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5600),
                            HomePageLastUpdated = new DateTime(2023, 4, 5, 20, 19, 1, 971, DateTimeKind.Local).AddTicks(5660)
                        });
                });

            modelBuilder.Entity("VegDex.Core.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllVegan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Restaurant", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.VeganCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VeganCompany", (string)null);
                });

            modelBuilder.Entity("VegDex.Core.Entities.Address", b =>
                {
                    b.HasOne("VegDex.Core.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("VegDex.Core.Entities.BlogPost", b =>
                {
                    b.HasOne("VegDex.Core.Entities.BlogCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("VegDex.Core.Entities.FarmersMarket", b =>
                {
                    b.HasOne("VegDex.Core.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("VegDex.Core.Entities.Link", b =>
                {
                    b.HasOne("VegDex.Core.Entities.LinkCategory", "Category")
                        .WithMany("Links")
                        .HasForeignKey("LinkCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("VegDex.Core.Entities.Restaurant", b =>
                {
                    b.HasOne("VegDex.Core.Entities.City", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("VegDex.Core.Entities.City", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("VegDex.Core.Entities.LinkCategory", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
