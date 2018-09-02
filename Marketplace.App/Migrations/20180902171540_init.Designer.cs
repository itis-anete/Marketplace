﻿// <auto-generated />
using System;
using Marketplace.App.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Marketplace.App.Migrations
{
    [DbContext(typeof(MarketPlaceDbContext))]
    [Migration("20180902171540_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Marketplace.App.DataBase.Entities.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("Marketplace.App.DataBase.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<int?>("MarketId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Marketplace.App.DataBase.Entities.Market", b =>
                {
                    b.HasOne("Marketplace.App.DataBase.Entities.Product")
                        .WithMany("InMarkets")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Marketplace.App.DataBase.Entities.Product", b =>
                {
                    b.HasOne("Marketplace.App.DataBase.Entities.Market")
                        .WithMany("Products")
                        .HasForeignKey("MarketId");
                });
#pragma warning restore 612, 618
        }
    }
}
