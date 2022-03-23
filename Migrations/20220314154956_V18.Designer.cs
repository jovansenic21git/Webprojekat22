﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Awe.Migrations
{
    [DbContext(typeof(KudContext))]
    [Migration("20220314154956_V18")]
    partial class V18
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Ansambl", b =>
                {
                    b.Property<int>("ID_an")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("kudID")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("probe")
                        .HasColumnType("int");

                    b.Property<int?>("rukovodilacID_rk")
                        .HasColumnType("int");

                    b.HasKey("ID_an");

                    b.HasIndex("kudID");

                    b.HasIndex("rukovodilacID_rk");

                    b.ToTable("ansambls");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Property<int>("ClanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime_cl")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prezime_cl")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ansamblID_an")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumupisa")
                        .HasColumnType("datetime2");

                    b.Property<int>("dolasci")
                        .HasColumnType("int");

                    b.Property<int>("godine_cl")
                        .HasColumnType("int");

                    b.HasKey("ClanID");

                    b.HasIndex("ansamblID_an");

                    b.ToTable("clans");
                });

            modelBuilder.Entity("Models.Clanarina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("clanarinas");
                });

            modelBuilder.Entity("Models.Kud", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("mesto")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("naziv_kud")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("kuds");
                });

            modelBuilder.Entity("Models.Rukovodilac", b =>
                {
                    b.Property<int>("ID_rk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("godine_rk")
                        .HasColumnType("int");

                    b.Property<string>("ime_rk")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("prezime_rk")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID_rk");

                    b.ToTable("rukovodilacs");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClanID")
                        .HasColumnType("int");

                    b.Property<int?>("clanarinaID")
                        .HasColumnType("int");

                    b.Property<bool>("uplata")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("ClanID");

                    b.HasIndex("clanarinaID");

                    b.ToTable("spojs");
                });

            modelBuilder.Entity("Models.Ansambl", b =>
                {
                    b.HasOne("Models.Kud", "kud")
                        .WithMany("anasambli")
                        .HasForeignKey("kudID");

                    b.HasOne("Models.Rukovodilac", "rukovodilac")
                        .WithMany("ansambli")
                        .HasForeignKey("rukovodilacID_rk");

                    b.Navigation("kud");

                    b.Navigation("rukovodilac");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.HasOne("Models.Ansambl", "ansambl")
                        .WithMany("clanovi")
                        .HasForeignKey("ansamblID_an");

                    b.Navigation("ansambl");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.HasOne("Models.Clan", "clan")
                        .WithMany("clan_clanarina")
                        .HasForeignKey("ClanID");

                    b.HasOne("Models.Clanarina", "clanarina")
                        .WithMany("clan_clanarina")
                        .HasForeignKey("clanarinaID");

                    b.Navigation("clan");

                    b.Navigation("clanarina");
                });

            modelBuilder.Entity("Models.Ansambl", b =>
                {
                    b.Navigation("clanovi");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Navigation("clan_clanarina");
                });

            modelBuilder.Entity("Models.Clanarina", b =>
                {
                    b.Navigation("clan_clanarina");
                });

            modelBuilder.Entity("Models.Kud", b =>
                {
                    b.Navigation("anasambli");
                });

            modelBuilder.Entity("Models.Rukovodilac", b =>
                {
                    b.Navigation("ansambli");
                });
#pragma warning restore 612, 618
        }
    }
}