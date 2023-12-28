﻿// <auto-generated />
using System;
using CookbookDataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookbookDataAccess.Migrations
{
    [DbContext(typeof(RecipeContext))]
    [Migration("20231226194343_keyRepare")]
    partial class keyRepare
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CookbookDataAccess.Models.Guides", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("TotalCalories")
                        .HasMaxLength(50)
                        .HasColumnType("real");

                    b.Property<float>("TotalGrams")
                        .HasMaxLength(50)
                        .HasColumnType("real");

                    b.Property<float>("TotalProtein")
                        .HasMaxLength(50)
                        .HasColumnType("real");

                    b.Property<string>("WritenGuide")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Guides");
                });

            modelBuilder.Entity("CookbookDataAccess.Models.IngredientTabs", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Kcal")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Measurement")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<float>("Protein")
                        .HasMaxLength(50)
                        .HasColumnType("real");

                    b.HasKey("Name");

                    b.ToTable("IngredientTabs");
                });

            modelBuilder.Entity("CookbookDataAccess.Models.Ingredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Calories")
                        .HasMaxLength(50)
                        .HasColumnType("real");

                    b.Property<int?>("GuidesId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Protein")
                        .HasMaxLength(50)
                        .HasColumnType("real");

                    b.Property<float>("Volume")
                        .HasMaxLength(50)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GuidesId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CookbookDataAccess.Models.Recipes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastCooked")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Score")
                        .HasMaxLength(20)
                        .HasColumnType("real");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CookbookDataAccess.Models.Ingredients", b =>
                {
                    b.HasOne("CookbookDataAccess.Models.Guides", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("GuidesId");
                });

            modelBuilder.Entity("CookbookDataAccess.Models.Guides", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
