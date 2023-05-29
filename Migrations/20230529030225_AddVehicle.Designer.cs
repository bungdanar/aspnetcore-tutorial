﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetcore_tutorial.Persistence;

#nullable disable

namespace aspnetcore_tutorial.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230529030225_AddVehicle")]
    partial class AddVehicle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VehiclesFeatures", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("VehiclesFeatures");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehiclesFeatures", b =>
                {
                    b.HasOne("aspnetcore_tutorial.Models.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aspnetcore_tutorial.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("aspnetcore_tutorial.Models.Model", b =>
                {
                    b.HasOne("aspnetcore_tutorial.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Models.Vehicle", b =>
                {
                    b.HasOne("aspnetcore_tutorial.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("aspnetcore_tutorial.Models.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("VehicleId")
                                .HasColumnType("int");

                            b1.Property<string>("ContactEmail")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("ContactName")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("ContactPhone")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.HasKey("VehicleId");

                            b1.ToTable("Vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId");
                        });

                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Models.Make", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
