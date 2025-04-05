using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_initialConsultation_patient_PatientStoredModelId",
                table: "initialConsultation");

            migrationBuilder.DropIndex(
                name: "IX_initialConsultation_PatientStoredModelId",
                table: "initialConsultation");

            migrationBuilder.DropColumn(
                name: "PatientStoredModelId",
                table: "initialConsultation");

            migrationBuilder.CreateIndex(
                name: "IX_initialConsultation_patientId",
                table: "initialConsultation",
                column: "patientId");

            migrationBuilder.AddForeignKey(
                name: "FK_initialConsultation_patient_patientId",
                table: "initialConsultation",
                column: "patientId",
                principalTable: "patient",
                principalColumn: "patientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_initialConsultation_patient_patientId",
                table: "initialConsultation");

            migrationBuilder.DropIndex(
                name: "IX_initialConsultation_patientId",
                table: "initialConsultation");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientStoredModelId",
                table: "initialConsultation",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_initialConsultation_PatientStoredModelId",
                table: "initialConsultation",
                column: "PatientStoredModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_initialConsultation_patient_PatientStoredModelId",
                table: "initialConsultation",
                column: "PatientStoredModelId",
                principalTable: "patient",
                principalColumn: "patientId");
        }
    }
}
