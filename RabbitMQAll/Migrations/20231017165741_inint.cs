using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RabbitMQAll.Migrations
{
    /// <inheritdoc />
    public partial class inint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "invoces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nipBayer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTimeCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fieldInvoces",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vat = table.Column<int>(type: "int", nullable: false),
                    netto = table.Column<double>(type: "float", nullable: false),
                    brutto = table.Column<double>(type: "float", nullable: false),
                    idInvoce = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fieldInvoces", x => x.id);
                    table.ForeignKey(
                        name: "FK_fieldInvoces_invoces_idInvoce",
                        column: x => x.idInvoce,
                        principalTable: "invoces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fieldInvoces_idInvoce",
                table: "fieldInvoces",
                column: "idInvoce",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fieldInvoces");

            migrationBuilder.DropTable(
                name: "invoces");
        }
    }
}
