using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "initialConsultation",
                columns: table => new
                {
                    initialConsultationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    patientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    reason = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    observations = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_initialConsultation", x => x.initialConsultationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "initialConsultation");
        }
    }
}
