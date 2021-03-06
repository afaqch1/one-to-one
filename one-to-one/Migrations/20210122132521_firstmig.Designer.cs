﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using one_to_many;

namespace one_to_one.Migrations
{
    [DbContext(typeof(ClassRoom))]
    [Migration("20210122132521_firstmig")]
    partial class firstmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("one_to_many.Student", b =>
                {
                    b.Property<int>("studentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("student_age")
                        .HasColumnType("int");

                    b.Property<string>("student_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentid");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("one_to_many.StudentAddress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("studentid")
                        .IsUnique();

                    b.ToTable("StudentAddresses");
                });

            modelBuilder.Entity("one_to_many.StudentAddress", b =>
                {
                    b.HasOne("one_to_many.Student", "student")
                        .WithOne("address")
                        .HasForeignKey("one_to_many.StudentAddress", "studentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });

            modelBuilder.Entity("one_to_many.Student", b =>
                {
                    b.Navigation("address");
                });
#pragma warning restore 612, 618
        }
    }
}
