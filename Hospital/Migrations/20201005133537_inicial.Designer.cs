﻿// <auto-generated />
using System;
using Hospital.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201005133537_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hospital.Model.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chegada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PacienteID")
                        .HasColumnName("id_paciente")
                        .HasColumnType("int");

                    b.Property<string>("Sintomas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("Hospital.Model.Paciente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AtendimentoId")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AtendimentoId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Hospital.Model.Paciente", b =>
                {
                    b.HasOne("Hospital.Model.Atendimento", null)
                        .WithMany("Paciente")
                        .HasForeignKey("AtendimentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
