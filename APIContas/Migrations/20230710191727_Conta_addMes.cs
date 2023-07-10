using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIContas.Migrations
{
    /// <inheritdoc />
    public partial class Conta_addMes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mes",
                table: "Conta");
        }
    }
}
