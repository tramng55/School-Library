﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School_Library.Data;

#nullable disable

namespace School_Library.Migrations
{
    [DbContext(typeof(School_LibraryDbContext))]
    [Migration("20220922085002_Add_Model9")]
    partial class Add_Model9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookProducer", b =>
                {
                    b.Property<int>("BooksBookID")
                        .HasColumnType("int");

                    b.Property<int>("ProducersProducerID")
                        .HasColumnType("int");

                    b.HasKey("BooksBookID", "ProducersProducerID");

                    b.HasIndex("ProducersProducerID");

                    b.ToTable("BookProducer");
                });

            modelBuilder.Entity("School_Library.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"), 1L, 1);

                    b.Property<string>("NameAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameBook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.AuthorBook", b =>
                {
                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.HasKey("AuthorID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("AuthorBook", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("NameBook")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.BorrowAssignment", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID", "BookID");

                    b.HasIndex("BookID");

                    b.ToTable("BorrowAssignment", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("NameCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.Checkin_out", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentID", "StaffID");

                    b.HasIndex("StaffID");

                    b.ToTable("Checkin_out", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.Producer", b =>
                {
                    b.Property<int>("ProducerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProducerID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameProducer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProducerID");

                    b.ToTable("Producer", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.Staff", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffID"), 1L, 1);

                    b.Property<string>("Dayofbirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameStaff")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffID");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("School_Library.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"), 1L, 1);

                    b.Property<string>("Dayofbirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameStudent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("BookProducer", b =>
                {
                    b.HasOne("School_Library.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_Library.Models.Producer", null)
                        .WithMany()
                        .HasForeignKey("ProducersProducerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("School_Library.Models.AuthorBook", b =>
                {
                    b.HasOne("School_Library.Models.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_Library.Models.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("School_Library.Models.Book", b =>
                {
                    b.HasOne("School_Library.Models.Category", "Categories")
                        .WithMany("Books")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("School_Library.Models.BorrowAssignment", b =>
                {
                    b.HasOne("School_Library.Models.Book", "Book")
                        .WithMany("BorrowAssignments")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_Library.Models.Student", "Student")
                        .WithMany("BorrowAssignments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("School_Library.Models.Checkin_out", b =>
                {
                    b.HasOne("School_Library.Models.Staff", "Staff")
                        .WithMany("Checkin_outs")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School_Library.Models.Student", "Student")
                        .WithMany("Checkin_outs")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("School_Library.Models.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("School_Library.Models.Book", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("BorrowAssignments");
                });

            modelBuilder.Entity("School_Library.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("School_Library.Models.Staff", b =>
                {
                    b.Navigation("Checkin_outs");
                });

            modelBuilder.Entity("School_Library.Models.Student", b =>
                {
                    b.Navigation("BorrowAssignments");

                    b.Navigation("Checkin_outs");
                });
#pragma warning restore 612, 618
        }
    }
}
