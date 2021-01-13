using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab4MySql.Migrations
{
    public partial class resultStringInsteadOfDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Calculations",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Result",
                table: "Calculations",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
