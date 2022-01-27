﻿// <auto-generated />
using System;
using BookApp.Persistence.EfCoreSql.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookApp.Persistence.EfCoreSql.Books.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20201026112348_AddUtfsAndAddUpdateLog")]
    partial class AddUtfsAndAddUpdateLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("BookApp.Domain.Books.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookApp.Domain.Books.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("ActualPrice")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("AuthorsOrdered")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstimatedDate")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("LastUpdatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManningBookUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<decimal>("OrgPrice")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("PromotionalText")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ReviewsAverageVotes")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("float");

                    b.Property<int>("ReviewsCount")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WhenCreatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId");

                    b.HasIndex("ActualPrice");

                    b.HasIndex("PublishedOn");

                    b.HasIndex("ReviewsAverageVotes");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookApp.Domain.Books.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Order")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("WhenCreatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("BookApp.Domain.Books.BookDetails", b =>
                {
                    b.Property<int>("BookDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AboutAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutReader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutTechnology")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorsOrdered")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ReviewsAverageVotes")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("float");

                    b.Property<int>("ReviewsCount")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<string>("WhatsInside")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetailsId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookApp.Domain.Books.BookTag", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("TagId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("BookId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("BookTag");
                });

            modelBuilder.Entity("BookApp.Domain.Books.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumStars")
                        .HasColumnType("int");

                    b.Property<string>("VoterName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("WhenCreatedUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("BookApp.Domain.Books.Tag", b =>
                {
                    b.Property<string>("TagId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BookApp.Domain.Books.BookAuthor", b =>
                {
                    b.HasOne("BookApp.Domain.Books.Author", "Author")
                        .WithMany("BooksLink")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApp.Domain.Books.Book", "Book")
                        .WithMany("AuthorsLink")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookApp.Domain.Books.BookDetails", b =>
                {
                    b.HasOne("BookApp.Domain.Books.Book", null)
                        .WithOne("Details")
                        .HasForeignKey("BookApp.Domain.Books.BookDetails", "BookDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookApp.Domain.Books.BookTag", b =>
                {
                    b.HasOne("BookApp.Domain.Books.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApp.Domain.Books.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("BookApp.Domain.Books.Review", b =>
                {
                    b.HasOne("BookApp.Domain.Books.Book", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookApp.Domain.Books.Author", b =>
                {
                    b.Navigation("BooksLink");
                });

            modelBuilder.Entity("BookApp.Domain.Books.Book", b =>
                {
                    b.Navigation("AuthorsLink");

                    b.Navigation("Details");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
