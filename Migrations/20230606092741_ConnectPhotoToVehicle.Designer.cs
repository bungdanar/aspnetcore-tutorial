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
    [Migration("20230606092741_ConnectPhotoToVehicle")]
    partial class ConnectPhotoToVehicle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Feature", b =>
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

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Make", b =>
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

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Model", b =>
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

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Vehicle", b =>
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

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.VehicleFeature", b =>
                {
                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("FeatureId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehiclesFeatures");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Model", b =>
                {
                    b.HasOne("aspnetcore_tutorial.Core.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Photo", b =>
                {
                    b.HasOne("aspnetcore_tutorial.Core.Models.Vehicle", null)
                        .WithMany("Photos")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Vehicle", b =>
                {
                    b.HasOne("aspnetcore_tutorial.Core.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("aspnetcore_tutorial.Core.Models.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("VehicleId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Phone")
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

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.VehicleFeature", b =>
                {
                    b.HasOne("aspnetcore_tutorial.Core.Models.Feature", "Feature")
                        .WithMany("VehicleFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("aspnetcore_tutorial.Core.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleFeatures")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Feature", b =>
                {
                    b.Navigation("VehicleFeatures");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Make", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("aspnetcore_tutorial.Core.Models.Vehicle", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("VehicleFeatures");
                });
#pragma warning restore 612, 618
        }
    }
}
