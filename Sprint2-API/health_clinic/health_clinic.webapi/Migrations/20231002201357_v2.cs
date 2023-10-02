using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_clinic.webapi.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_FeedBack_IdFeedBack",
                table: "Consulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBack",
                table: "FeedBack");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdFeedBack",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdFeedBack",
                table: "Consulta");

            migrationBuilder.RenameTable(
                name: "FeedBack",
                newName: "Feedback");

            migrationBuilder.RenameColumn(
                name: "DataEvento",
                table: "Consulta",
                newName: "DataConsulta");

            migrationBuilder.AddColumn<Guid>(
                name: "IdConsulta",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Prontuario",
                table: "Consulta",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "IdFeedBack");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_IdConsulta",
                table: "Feedback",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Consulta_IdConsulta",
                table: "Feedback",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "IdConsulta",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Consulta_IdConsulta",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_IdConsulta",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "IdConsulta",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Prontuario",
                table: "Consulta");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "FeedBack");

            migrationBuilder.RenameColumn(
                name: "DataConsulta",
                table: "Consulta",
                newName: "DataEvento");

            migrationBuilder.AddColumn<Guid>(
                name: "IdFeedBack",
                table: "Consulta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBack",
                table: "FeedBack",
                column: "IdFeedBack");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdFeedBack",
                table: "Consulta",
                column: "IdFeedBack");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_FeedBack_IdFeedBack",
                table: "Consulta",
                column: "IdFeedBack",
                principalTable: "FeedBack",
                principalColumn: "IdFeedBack",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
