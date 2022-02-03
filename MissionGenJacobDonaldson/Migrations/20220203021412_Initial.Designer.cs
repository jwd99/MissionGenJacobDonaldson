﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MissionGenJacobDonaldson.Models;

namespace MissionGenJacobDonaldson.Migrations
{
    [DbContext(typeof(MovieFormContext))]
    [Migration("20220203021412_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("MissionGenJacobDonaldson.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "SciFi"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Drama/History"
                        });
                });

            modelBuilder.Entity("MissionGenJacobDonaldson.Models.FormResponse", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DirectorFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DirectorLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CategoryId = 1,
                            DirectorFirstName = "Christopher",
                            DirectorLastName = "Nolan",
                            Edited = false,
                            LentTo = "",
                            Notes = "Ches this is the best!",
                            Rating = "PG-13",
                            Title = "The Dark Night",
                            Year = 2008
                        },
                        new
                        {
                            MovieId = 2,
                            CategoryId = 2,
                            DirectorFirstName = "George",
                            DirectorLastName = "Lucas",
                            Edited = false,
                            LentTo = "",
                            Notes = "#r/prequelmemes for life",
                            Rating = "PG-13",
                            Title = "Star Wars Episode III: Revenge of the Sith",
                            Year = 2005
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 3,
                            DirectorFirstName = "Bryan",
                            DirectorLastName = "Singer",
                            Edited = false,
                            LentTo = "",
                            Notes = "WWII Conspiracy Plot",
                            Rating = "PG-13",
                            Title = "Valkyrie",
                            Year = 2008
                        });
                });

            modelBuilder.Entity("MissionGenJacobDonaldson.Models.FormResponse", b =>
                {
                    b.HasOne("MissionGenJacobDonaldson.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
