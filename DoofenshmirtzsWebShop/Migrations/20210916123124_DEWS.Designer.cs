﻿// <auto-generated />
using DoofenshmirtzsWebShop.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoofenshmirtzsWebShop.Migrations
{
    [DbContext(typeof(DoofenshmirtzWebShopContext))]
    [Migration("20210916123124_DEWS")]
    partial class DEWS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoofenshmirtzsWebShop.Database.Entities.Address", b =>
                {
                    b.Property<int>("addressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("addressCountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("addressCustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("addressPostalCode")
                        .HasColumnType("int");

                    b.Property<string>("addressStreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("addressID");

                    b.HasIndex("userID");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            addressID = 1,
                            addressCountryName = "Carkeys",
                            addressCustomerName = "Test McTesting",
                            addressPostalCode = 6969,
                            addressStreetName = "Danville 101",
                            userID = 1
                        });
                });

            modelBuilder.Entity("DoofenshmirtzsWebShop.Database.Entities.Category", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("categoryID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            categoryID = 1,
                            categoryName = "Products"
                        },
                        new
                        {
                            categoryID = 2,
                            categoryName = "Books"
                        },
                        new
                        {
                            categoryID = 3,
                            categoryName = "Merch"
                        });
                });

            modelBuilder.Entity("DoofenshmirtzsWebShop.Database.Entities.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("userRole")
                        .HasColumnType("int");

                    b.HasKey("userID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            userID = 1,
                            userEmail = "test@test.dk",
                            userName = "Test101",
                            userPassword = "Test1234",
                            userRole = 1
                        });
                });

            modelBuilder.Entity("DoofenshmirtzsWebShop.Database.Entities.Address", b =>
                {
                    b.HasOne("DoofenshmirtzsWebShop.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}