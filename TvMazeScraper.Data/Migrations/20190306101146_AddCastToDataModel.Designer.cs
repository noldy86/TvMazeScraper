﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TvMazeScraper.Data;

namespace TvMazeScraper.Data.Migrations
{
    [DbContext(typeof(MazeDbContext))]
    [Migration("20190306101146_AddCastToDataModel")]
    partial class AddCastToDataModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestCore.Data.Models.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Name");

                    b.Property<int?>("ShowId");

                    b.HasKey("Id");

                    b.HasIndex("ShowId");

                    b.ToTable("Cast");
                });

            modelBuilder.Entity("TestCore.Data.Models.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("TestCore.Data.Models.Cast", b =>
                {
                    b.HasOne("TestCore.Data.Models.Show")
                        .WithMany("Cast")
                        .HasForeignKey("ShowId");
                });
#pragma warning restore 612, 618
        }
    }
}
