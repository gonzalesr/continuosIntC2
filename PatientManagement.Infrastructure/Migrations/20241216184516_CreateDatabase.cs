using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.patientId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    fullName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patientPhone",
                columns: table => new
                {
                    patiendPhoneId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    patientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientPhone", x => x.patiendPhoneId);
                    table.ForeignKey(
                        name: "FK_patientPhone_patient_patientId",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_patientPhone_patientId",
                table: "patientPhone",
                column: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patientPhone");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
