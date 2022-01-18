﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Projekat.Migrations
{
    [DbContext(typeof(ReceptContext))]
    [Migration("20220104162105_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Kategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("Models.Recept", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Instrukcija")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Opis")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Sastojci")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("TezinaPripremeID")
                        .HasColumnType("int");

                    b.Property<int?>("TipID")
                        .HasColumnType("int");

                    b.Property<string>("VremePripreme")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("ID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("TezinaPripremeID");

                    b.HasIndex("TipID");

                    b.ToTable("Recept");
                });

            modelBuilder.Entity("Models.TezinaPripreme", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Tezina")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("TezinaPripreme");
                });

            modelBuilder.Entity("Models.Tip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TipJela")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("Models.Recept", b =>
                {
                    b.HasOne("Models.Kategorija", "Kategorija")
                        .WithMany("Recepti")
                        .HasForeignKey("KategorijaID");

                    b.HasOne("Models.TezinaPripreme", "TezinaPripreme")
                        .WithMany("Recepti")
                        .HasForeignKey("TezinaPripremeID");

                    b.HasOne("Models.Tip", "Tip")
                        .WithMany("Recepti")
                        .HasForeignKey("TipID");

                    b.Navigation("Kategorija");

                    b.Navigation("TezinaPripreme");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("Models.Kategorija", b =>
                {
                    b.Navigation("Recepti");
                });

            modelBuilder.Entity("Models.TezinaPripreme", b =>
                {
                    b.Navigation("Recepti");
                });

            modelBuilder.Entity("Models.Tip", b =>
                {
                    b.Navigation("Recepti");
                });
#pragma warning restore 612, 618
        }
    }
}