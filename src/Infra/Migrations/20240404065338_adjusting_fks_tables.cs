using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4__Infra.Migrations
{
    /// <inheritdoc />
    public partial class adjusting_fks_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CommandId",
                table: "Parameter",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "BIGINT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                table: "Measurement",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "BIGINT",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                table: "Command",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "BIGINT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CommandId",
                table: "Parameter",
                type: "BIGINT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                table: "Measurement",
                type: "BIGINT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                table: "Command",
                type: "BIGINT",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "BIGINT");
        }
    }
}
