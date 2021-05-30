﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeopleSearchApp.Data;

namespace PeopleSearchApp.Migrations
{
    [DbContext(typeof(PeopleSearchAppContext))]
    partial class PeopleSearchAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("InterestsId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("PeopleSearchApp.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("PeopleSearchApp.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address2")
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Picture")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("PeopleSearchApp.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeopleSearchApp.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
