﻿// <auto-generated />
using CrudApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250122210503_Primera Migracion, Prueba")]
    partial class PrimeraMigracionPrueba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudApi.Entities.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sueldo")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("CrudApi.Entities.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerfil"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfil", (string)null);

                    b.HasData(
                        new
                        {
                            IdPerfil = 1,
                            Nombre = "Programador Junior"
                        },
                        new
                        {
                            IdPerfil = 2,
                            Nombre = "Programador Senior"
                        },
                        new
                        {
                            IdPerfil = 3,
                            Nombre = "Analista"
                        });
                });

            modelBuilder.Entity("CrudApi.Entities.Empleado", b =>
                {
                    b.HasOne("CrudApi.Entities.Perfil", "PerfilReferencia")
                        .WithMany("EmpleadoReferencia")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerfilReferencia");
                });

            modelBuilder.Entity("CrudApi.Entities.Perfil", b =>
                {
                    b.Navigation("EmpleadoReferencia");
                });
#pragma warning restore 612, 618
        }
    }
}
