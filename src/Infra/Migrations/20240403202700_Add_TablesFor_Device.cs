using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4__Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_TablesFor_Device : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identifier = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    manufacturer = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    url = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    DeviceId = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Command_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    value = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    DeviceId = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurement_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CommandId = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameter_Command_CommandId",
                        column: x => x.CommandId,
                        principalTable: "Command",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Command_DeviceId",
                table: "Command",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_DeviceId",
                table: "Measurement",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_CommandId",
                table: "Parameter",
                column: "CommandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Command");

            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
