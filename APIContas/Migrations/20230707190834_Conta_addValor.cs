﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIContas.Migrations
{
    /// <inheritdoc />
    public partial class Conta_addValor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Conta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Conta");
        }
    }
}
