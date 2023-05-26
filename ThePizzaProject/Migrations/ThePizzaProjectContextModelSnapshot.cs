﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThePizzaProject.Data;

#nullable disable

namespace ThePizzaProject.Migrations
{
    [DbContext(typeof(ThePizzaProjectContext))]
    partial class ThePizzaProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ThePizzaProject.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenIDIssuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenIDSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"), 1L, 1);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserAccountID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("UserAccountID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ThePizzaProject.Models.CommentPizza", b =>
                {
                    b.Property<int>("CommentPizzaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentPizzaID"), 1L, 1);

                    b.Property<int?>("CommentID")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaID")
                        .HasColumnType("int");

                    b.HasKey("CommentPizzaID");

                    b.HasIndex("CommentID");

                    b.HasIndex("PizzaID");

                    b.ToTable("CommentPizza");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientID"), 1L, 1);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaID"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PizzaID");

                    b.HasIndex("AccountID");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("ThePizzaProject.Models.PizzaIngredient", b =>
                {
                    b.Property<int>("PizzaIngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaIngredientID"), 1L, 1);

                    b.Property<int>("IngredientID")
                        .HasColumnType("int");

                    b.Property<int>("PizzaID")
                        .HasColumnType("int");

                    b.HasKey("PizzaIngredientID");

                    b.HasIndex("IngredientID");

                    b.HasIndex("PizzaID");

                    b.ToTable("PizzaIngredient");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Rating", b =>
                {
                    b.Property<int>("ratingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ratingId"), 1L, 1);

                    b.Property<int>("UserAccountID")
                        .HasColumnType("int");

                    b.Property<int>("ratingValue")
                        .HasColumnType("int");

                    b.HasKey("ratingId");

                    b.HasIndex("UserAccountID");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("ThePizzaProject.Models.RatingPizza", b =>
                {
                    b.Property<int>("ratingPizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ratingPizzaId"), 1L, 1);

                    b.Property<int?>("PizzaID")
                        .HasColumnType("int");

                    b.Property<int?>("ratingId")
                        .HasColumnType("int");

                    b.HasKey("ratingPizzaId");

                    b.HasIndex("PizzaID");

                    b.HasIndex("ratingId");

                    b.ToTable("RatingPizza");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Comment", b =>
                {
                    b.HasOne("ThePizzaProject.Models.Account", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThePizzaProject.Models.CommentPizza", b =>
                {
                    b.HasOne("ThePizzaProject.Models.Comment", "Comment")
                        .WithMany("CommentPizzas")
                        .HasForeignKey("CommentID");

                    b.HasOne("ThePizzaProject.Models.Pizza", "Pizza")
                        .WithMany("CommentPizza")
                        .HasForeignKey("PizzaID");

                    b.Navigation("Comment");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Pizza", b =>
                {
                    b.HasOne("ThePizzaProject.Models.Account", "User")
                        .WithMany("Pizzas")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThePizzaProject.Models.PizzaIngredient", b =>
                {
                    b.HasOne("ThePizzaProject.Models.Ingredient", "Ingredient")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThePizzaProject.Models.Pizza", "Pizza")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("PizzaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Rating", b =>
                {
                    b.HasOne("ThePizzaProject.Models.Account", "User")
                        .WithMany()
                        .HasForeignKey("UserAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ThePizzaProject.Models.RatingPizza", b =>
                {
                    b.HasOne("ThePizzaProject.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaID");

                    b.HasOne("ThePizzaProject.Models.Rating", "Rating")
                        .WithMany("RatingPizzas")
                        .HasForeignKey("ratingId");

                    b.Navigation("Pizza");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Account", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Comment", b =>
                {
                    b.Navigation("CommentPizzas");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Ingredient", b =>
                {
                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Pizza", b =>
                {
                    b.Navigation("CommentPizza");

                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Rating", b =>
                {
                    b.Navigation("RatingPizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
