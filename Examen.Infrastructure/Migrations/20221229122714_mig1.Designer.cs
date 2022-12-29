﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamenContext))]
    [Migration("20221229122714_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Avocat", b =>
                {
                    b.Property<int>("AvocatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvocatId"), 1L, 1);

                    b.Property<DateTime>("DateEmbauche")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreNom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialiteId")
                        .HasColumnType("int");

                    b.HasKey("AvocatId");

                    b.HasIndex("SpecialiteId");

                    b.ToTable("Avocats");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Client", b =>
                {
                    b.Property<int>("CIN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CIN"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreNom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CIN");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Dossier", b =>
                {
                    b.Property<int>("AvocatFk")
                        .HasColumnType("int");

                    b.Property<int>("ClientFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDepot")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Clos")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Frais")
                        .HasColumnType("real");

                    b.HasKey("AvocatFk", "ClientFk", "DateDepot");

                    b.HasIndex("ClientFk");

                    b.ToTable("Dossiers");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Specialite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomSpecialite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialites");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Avocat", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Specialite", "Specialite")
                        .WithMany("Avocats")
                        .HasForeignKey("SpecialiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialite");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Dossier", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Avocat", "Avocat")
                        .WithMany("Dossiers")
                        .HasForeignKey("AvocatFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Client", "Client")
                        .WithMany("Dossiers")
                        .HasForeignKey("ClientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avocat");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Avocat", b =>
                {
                    b.Navigation("Dossiers");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Client", b =>
                {
                    b.Navigation("Dossiers");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Specialite", b =>
                {
                    b.Navigation("Avocats");
                });
#pragma warning restore 612, 618
        }
    }
}
