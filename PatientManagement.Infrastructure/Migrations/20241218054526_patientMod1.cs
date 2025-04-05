using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class patientMod1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patientPhone");

            migrationBuilder.CreateTable(
                name: "phone",
                columns: table => new
                {
                    phoneId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    patientId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone", x => x.phoneId);
                    table.ForeignKey(
                        name: "FK_phone_patient_patientId",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_phone_patientId",
                table: "phone",
                column: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phone");

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
    }
}
