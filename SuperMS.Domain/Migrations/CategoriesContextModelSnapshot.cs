﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperMS.Domain;

#nullable disable

namespace SuperMS.Domain
{
    [DbContext(typeof(CategoriesContext))]
    partial class CategoriesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("SuperMS.Domain.CategoriesEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("SuperMS.Domain.ProductEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Categoriesid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Categoriesid");

                    b.ToTable("products");
                });

            modelBuilder.Entity("SuperMS.Domain.ProductEntity", b =>
                {
                    b.HasOne("SuperMS.Domain.CategoriesEntity", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("Categoriesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("SuperMS.Domain.CategoriesEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
