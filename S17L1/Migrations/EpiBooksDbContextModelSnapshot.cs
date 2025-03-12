﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S17L1.Data;

#nullable disable

namespace S17L1.Migrations
{
    [DbContext(typeof(EpiBooksDbContext))]
    partial class EpiBooksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("S17L1.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autore")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Copertina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponibilita")
                        .HasColumnType("bit");

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("S17L1.Models.Borrow", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BorrowDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("BorrowEndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("S17L1.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("S17L1.Models.Borrow", b =>
                {
                    b.HasOne("S17L1.Models.Book", "Book")
                        .WithOne("Borrow")
                        .HasForeignKey("S17L1.Models.Borrow", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S17L1.Models.User", "User")
                        .WithMany("Borrows")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("S17L1.Models.Book", b =>
                {
                    b.Navigation("Borrow")
                        .IsRequired();
                });

            modelBuilder.Entity("S17L1.Models.User", b =>
                {
                    b.Navigation("Borrows");
                });
#pragma warning restore 612, 618
        }
    }
}
