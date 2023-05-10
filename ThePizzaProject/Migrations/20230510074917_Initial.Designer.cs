﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThePizzaProject.Data;

#nullable disable

namespace ThePizzaProject.Migrations
{
    [DbContext(typeof(ThePizzaProjectContext))]
<<<<<<<< HEAD:ThePizzaProject/Migrations/20230510070628_init.Designer.cs
    [Migration("20230510070628_init")]
    partial class init
========
    [Migration("20230510074917_Initial")]
    partial class Initial
>>>>>>>> c06c2510bd3ad8c4f70a13d8a54ce4d9db049a5c:ThePizzaProject/Migrations/20230510074917_Initial.Designer.cs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ThePizzaProject.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientID"), 1L, 1);

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

            modelBuilder.Entity("ThePizzaProject.Models.Account", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Ingredient", b =>
                {
                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("ThePizzaProject.Models.Pizza", b =>
                {
                    b.Navigation("PizzaIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
