using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _4__Infra.Migrations
{
    /// <inheritdoc />
    public partial class adjusting_tables_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Device_DeviceId",
                table: "Measurement");

            migrationBuilder.DropIndex(
                name: "IX_Measurement_DeviceId",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Measurement");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateTime",
                table: "Measurement",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Measurement",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "MeasurementId",
                table: "Device",
                type: "BIGINT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Measurement",
                columns: new[] { "Id", "dateTime", "name", "value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "São Paulo", 10m },
                    { 2L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Rio de Janeiro", 15m },
                    { 3L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Brasília", 12m },
                    { 4L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Salvador", 18m },
                    { 5L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Fortaleza", 9m },
                    { 6L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Curitiba", 20m },
                    { 7L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Recife", 16m },
                    { 8L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Manaus", 13m },
                    { 9L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Porto Alegre", 11m },
                    { 10L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Belém", 14m },
                    { 11L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Goiânia", 17m },
                    { 12L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Florianópolis", 19m },
                    { 13L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Vitória", 8m },
                    { 14L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Natal", 21m },
                    { 15L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "João Pessoa", 22m },
                    { 16L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Campo Grande", 23m },
                    { 17L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Teresina", 24m },
                    { 18L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Cuiabá", 25m },
                    { 19L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "São Luís", 26m },
                    { 20L, new DateTime(2024, 4, 4, 18, 29, 20, 0, DateTimeKind.Utc), "Maceió", 27m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_MeasurementId",
                table: "Device",
                column: "MeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Measurement_MeasurementId",
                table: "Device",
                column: "MeasurementId",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_Measurement_MeasurementId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_MeasurementId",
                table: "Device");

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Measurement",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DropColumn(
                name: "name",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "MeasurementId",
                table: "Device");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateTime",
                table: "Measurement",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");

            migrationBuilder.AddColumn<long>(
                name: "DeviceId",
                table: "Measurement",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_DeviceId",
                table: "Measurement",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Device_DeviceId",
                table: "Measurement",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
