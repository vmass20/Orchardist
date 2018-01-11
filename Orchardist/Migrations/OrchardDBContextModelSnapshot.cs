﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Orchardist.Data;
using System;

namespace Orchardist.Migrations
{
    [DbContext(typeof(OrchardDBContext))]
    partial class OrchardDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Orchardist.Data.GlobalPlantList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<string>("FruitVariety")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Origin");

                    b.Property<string>("Use");

                    b.Property<string>("YearDeveloped");

                    b.HasKey("ID");

                    b.ToTable("GlobalPlantList");
                });

            modelBuilder.Entity("Orchardist.Data.UserPlantList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<DateTime>("DatePlanted");

                    b.Property<string>("FruitVariety")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Parentage")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("TreeCount");

                    b.Property<string>("Use");

                    b.Property<string>("YearDeveloped");

                    b.HasKey("ID");

                    b.ToTable("UserPlantList");
                });
#pragma warning restore 612, 618
        }
    }
}
