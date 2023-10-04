using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_clinic.webapi.Migrations
{
    /// <inheritdoc />
    public partial class BDv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioFuncionamento",
                table: "Clinica");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioAbertura",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioFechamento",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAbertura",
                table: "Clinica");

            migrationBuilder.DropColumn(
                name: "HorarioFechamento",
                table: "Clinica");

            migrationBuilder.AddColumn<DateTime>(
                name: "HorarioFuncionamento",
                table: "Clinica",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
