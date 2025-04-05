using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "periodicEvaluation",
                columns: table => new
                {
                    periodicEvaluationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    patientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    evaluationNotes = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    height = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    systolic = table.Column<int>(type: "int", nullable: false),
                    diastolic = table.Column<int>(type: "int", nullable: false),
                    heartRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodicEvaluation", x => x.periodicEvaluationId);
                    table.ForeignKey(
                        name: "FK_periodicEvaluation_patient_patientId",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_periodicEvaluation_patientId",
                table: "periodicEvaluation",
                column: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "periodicEvaluation");
        }
    }
}
