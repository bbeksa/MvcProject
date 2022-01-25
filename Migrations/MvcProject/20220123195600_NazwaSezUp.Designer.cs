﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MvcProject.Migrations.MvcProject
{
    [DbContext(typeof(MvcProjectContext))]
    [Migration("20220123195600_NazwaSezUp")]
    partial class NazwaSezUp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("MvcProject.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.HasKey("LeagueId");

                    b.ToTable("League");
                });

            modelBuilder.Entity("MvcProject.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryOfBirth")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nickname")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("MvcProject.Models.Seazon", b =>
                {
                    b.Property<int>("SeazonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("SeazonId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Seazon");
                });

            modelBuilder.Entity("MvcProject.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdcPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Classification")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JungPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MidPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<int>("SeazonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuppPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TopPlayerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamId");

                    b.HasIndex("AdcPlayerId");

                    b.HasIndex("JungPlayerId");

                    b.HasIndex("MidPlayerId");

                    b.HasIndex("SeazonId");

                    b.HasIndex("SuppPlayerId");

                    b.HasIndex("TopPlayerId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("MvcProject.Models.Seazon", b =>
                {
                    b.HasOne("MvcProject.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("MvcProject.Models.Team", b =>
                {
                    b.HasOne("MvcProject.Models.Player", "AdcPlayer")
                        .WithMany()
                        .HasForeignKey("AdcPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcProject.Models.Player", "JungPlayer")
                        .WithMany()
                        .HasForeignKey("JungPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcProject.Models.Player", "MidPlayer")
                        .WithMany()
                        .HasForeignKey("MidPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcProject.Models.Seazon", "Seazon")
                        .WithMany()
                        .HasForeignKey("SeazonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcProject.Models.Player", "SuppPlayer")
                        .WithMany()
                        .HasForeignKey("SuppPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcProject.Models.Player", "TopPlayer")
                        .WithMany()
                        .HasForeignKey("TopPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdcPlayer");

                    b.Navigation("JungPlayer");

                    b.Navigation("MidPlayer");

                    b.Navigation("Seazon");

                    b.Navigation("SuppPlayer");

                    b.Navigation("TopPlayer");
                });
#pragma warning restore 612, 618
        }
    }
}
