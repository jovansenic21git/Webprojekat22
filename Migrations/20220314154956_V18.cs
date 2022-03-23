using Microsoft.EntityFrameworkCore.Migrations;

namespace Awe.Migrations
{
    public partial class V18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ansambls_kuds_kudID",
                table: "ansambls");

            migrationBuilder.AlterColumn<int>(
                name: "kudID",
                table: "ansambls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ansambls_kuds_kudID",
                table: "ansambls",
                column: "kudID",
                principalTable: "kuds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ansambls_kuds_kudID",
                table: "ansambls");

            migrationBuilder.AlterColumn<int>(
                name: "kudID",
                table: "ansambls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ansambls_kuds_kudID",
                table: "ansambls",
                column: "kudID",
                principalTable: "kuds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
