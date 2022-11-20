﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoBanco1;

#nullable disable

namespace ProyectoBanco1.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoBanco1.CajaDeAhorro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cbu")
                        .HasColumnType("int");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Cajas", (string)null);
                });

            modelBuilder.Entity("ProyectoBanco1.Movimiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("detalle")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("dateTime");

                    b.Property<int>("idCaja")
                        .HasColumnType("int");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("idCaja");

                    b.ToTable("Movimientos", (string)null);
                });

            modelBuilder.Entity("ProyectoBanco1.Pago", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<string>("metodo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("pagado")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("idUsuario");

                    b.ToTable("Pagos", (string)null);
                });

            modelBuilder.Entity("ProyectoBanco1.PlazoFijo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cbu")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("fechaFin")
                        .HasColumnType("dateTime");

                    b.Property<DateTime>("fechaIni")
                        .HasColumnType("dateTime");

                    b.Property<int>("idTitular")
                        .HasColumnType("int");

                    b.Property<double>("monto")
                        .HasColumnType("float");

                    b.Property<bool>("pagado")
                        .HasColumnType("bit");

                    b.Property<double>("tasa")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("idTitular");

                    b.ToTable("Pfs", (string)null);
                });

            modelBuilder.Entity("ProyectoBanco1.TarjetaDeCredito", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("codigoV")
                        .HasColumnType("int");

                    b.Property<double>("consumos")
                        .HasColumnType("float");

                    b.Property<int>("idTitular")
                        .HasColumnType("int");

                    b.Property<double>("limite")
                        .HasColumnType("float");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idTitular");

                    b.ToTable("Tarjetas", (string)null);
                });

            modelBuilder.Entity("ProyectoBanco1.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("bloqueado")
                        .HasColumnType("bit");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<bool>("esAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("intentosFallidos")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("varchar(512)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("ProyectoBanco1.UsuarioCaja", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("idCaja")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idCaja");

                    b.HasIndex("idUsuario");

                    b.ToTable("UsuariosCajas", (string)null);
                });

            modelBuilder.Entity("ProyectoBanco1.Movimiento", b =>
                {
                    b.HasOne("ProyectoBanco1.CajaDeAhorro", "caja")
                        .WithMany("movimientos")
                        .HasForeignKey("idCaja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("caja");
                });

            modelBuilder.Entity("ProyectoBanco1.Pago", b =>
                {
                    b.HasOne("ProyectoBanco1.Usuario", "user")
                        .WithMany("pagos")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProyectoBanco1.PlazoFijo", b =>
                {
                    b.HasOne("ProyectoBanco1.Usuario", "titular")
                        .WithMany("pfs")
                        .HasForeignKey("idTitular")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("titular");
                });

            modelBuilder.Entity("ProyectoBanco1.TarjetaDeCredito", b =>
                {
                    b.HasOne("ProyectoBanco1.Usuario", "titular")
                        .WithMany("tarjetas")
                        .HasForeignKey("idTitular")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("titular");
                });

            modelBuilder.Entity("ProyectoBanco1.UsuarioCaja", b =>
                {
                    b.HasOne("ProyectoBanco1.CajaDeAhorro", "caja")
                        .WithMany("userCaja")
                        .HasForeignKey("idCaja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoBanco1.Usuario", "user")
                        .WithMany("userCaja")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("caja");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProyectoBanco1.CajaDeAhorro", b =>
                {
                    b.Navigation("movimientos");

                    b.Navigation("userCaja");
                });

            modelBuilder.Entity("ProyectoBanco1.Usuario", b =>
                {
                    b.Navigation("pagos");

                    b.Navigation("pfs");

                    b.Navigation("tarjetas");

                    b.Navigation("userCaja");
                });
#pragma warning restore 612, 618
        }
    }
}
