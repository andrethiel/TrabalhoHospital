using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWeb.Migrations
{
    public partial class cep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AtendimentoPacientes",
                newName: "IdAtendimento");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoLogradouro",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Paciente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atendido",
                table: "AtendimentoPacientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Chegada",
                table: "AtendimentoPacientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "TipoLogradouro",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Atendido",
                table: "AtendimentoPacientes");

            migrationBuilder.DropColumn(
                name: "Chegada",
                table: "AtendimentoPacientes");

            migrationBuilder.RenameColumn(
                name: "IdAtendimento",
                table: "AtendimentoPacientes",
                newName: "ID");
        }
    }
}
