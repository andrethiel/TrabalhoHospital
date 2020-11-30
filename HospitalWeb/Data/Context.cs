using HospitalWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HospitalWeb.Data
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Atendimento>().ToTable("Pacientes");
        //}
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }

        public DbSet<AtendimentoPaciente> AtendimentoPacientes { get; set; }

        public DbSet<Prescricao> Prescricao { get; set; }

        public DbSet<UserView> Usuarios { get; set; }
    }
}
