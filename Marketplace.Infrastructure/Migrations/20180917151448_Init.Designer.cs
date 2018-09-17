﻿// <auto-generated />
using Marketplace.Infrastructure.Сontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marketplace.Infrastructure.Migrations
{
    [DbContext(typeof(MarketPlaceDbContext))]
    [Migration("20180917151448_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Marketplace.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("Marketplace.Models.MarketProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MarketId");

                    b.Property<int>("ProductId");

                    b.Property<string>("UserUId");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserUId");

                    b.ToTable("MarketProducts");
                });

            modelBuilder.Entity("Marketplace.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Marketplace.Models.User", b =>
                {
                    b.Property<string>("UId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Role");

                    b.HasKey("UId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Marketplace.Models.MarketProduct", b =>
                {
                    b.HasOne("Marketplace.Models.Market", "Market")
                        .WithMany("Products")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marketplace.Models.Product", "Product")
                        .WithMany("InMarkets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Marketplace.Models.User")
                        .WithMany("Cart")
                        .HasForeignKey("UserUId");
                });
#pragma warning restore 612, 618
        }
    }
}
