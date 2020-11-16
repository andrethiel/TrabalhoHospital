using Hospital.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hospital.Data
{
    class Context : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            options.UseSqlServer(@"Server=tcp:servidorfacu.database.windows.net,1433;Initial Catalog=Hospital_Medico;Persist Security Info=False;User ID=lucresmac;Password=teste22!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Atendimento>().ToTable("Pacientes");
        //}
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }

        public DbSet<AtendimentoPaciente> AtendimentoPacientes { get; set; }

        public DbSet<Prescricao> Prescricao { get; set; }
    }
}
