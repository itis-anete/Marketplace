﻿// <auto-generated />
using System;
using Marketplace.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Marketplace.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Marketplace.Core.Auction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BetMinimalStepInUsDollars");

                    b.Property<DateTime>("CompletionDateTime");

                    b.Property<double?>("FinalPriceInUsDollars");

                    b.Property<string>("MarketName");

                    b.Property<Guid>("ProductLotId");

                    b.Property<double>("StartPriceInUsDollars");

                    b.Property<string>("WinnerLogin");

                    b.HasKey("Id");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Marketplace.Core.Bet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AmountInUsDollars");

                    b.Property<Guid?>("AuctionId");

                    b.Property<string>("BettorLogin");

                    b.Property<DateTime>("CreationDateTime");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("Bet");
                });

            modelBuilder.Entity("Marketplace.Core.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerLogin");

                    b.Property<double>("TotalInUsDollarsWithDiscounts");

                    b.HasKey("Id");

                    b.HasIndex("CustomerLogin");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Marketplace.Core.Customer", b =>
                {
                    b.Property<string>("Login")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("PasswordHash");

                    b.HasKey("Login");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Marketplace.Core.Discounts.DiscountBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("EndDate");

                    b.Property<double>("Percent");

                    b.Property<Guid?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("DiscountBase");
                });

            modelBuilder.Entity("Marketplace.Core.Market", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("Marketplace.Core.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerLogin");

                    b.Property<DateTimeOffset>("OrderDateTime");

                    b.Property<double>("TotalInUsDollars");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Marketplace.Core.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BasePriceInUsDollars");

                    b.Property<Guid?>("CartId");

                    b.Property<string>("Description");

                    b.Property<string>("MarketName");

                    b.Property<string>("Name");

                    b.Property<Guid?>("OrderId");

                    b.Property<long>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Marketplace.Core.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsCategories");
                });

            modelBuilder.Entity("Marketplace.Core.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerLogin");

                    b.Property<Guid?>("ProductId");

                    b.Property<double>("Rate");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Marketplace.Core.Bet", b =>
                {
                    b.HasOne("Marketplace.Core.Auction")
                        .WithMany("AllBets")
                        .HasForeignKey("AuctionId");
                });

            modelBuilder.Entity("Marketplace.Core.Cart", b =>
                {
                    b.HasOne("Marketplace.Core.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerLogin");
                });

            modelBuilder.Entity("Marketplace.Core.Discounts.DiscountBase", b =>
                {
                    b.HasOne("Marketplace.Core.Product")
                        .WithMany("Discounts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Marketplace.Core.Product", b =>
                {
                    b.HasOne("Marketplace.Core.Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("Marketplace.Core.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Marketplace.Core.ProductCategory", b =>
                {
                    b.HasOne("Marketplace.Core.Market")
                        .WithMany("ProductsCategories")
                        .HasForeignKey("Name");

                    b.HasOne("Marketplace.Core.Product")
                        .WithMany("AssociatedCategories")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Marketplace.Core.Review", b =>
                {
                    b.HasOne("Marketplace.Core.Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
