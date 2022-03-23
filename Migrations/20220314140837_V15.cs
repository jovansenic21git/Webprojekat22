using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Awe.Migrations
{
    public partial class V15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ansambls_Rukovodilac_rukovodilacID_rk",
                table: "ansambls");

            migrationBuilder.DropTable(
                name: "ClanInstrument");

            migrationBuilder.DropTable(
                name: "instruments");

            migrationBuilder.DropTable(
                name: "spojs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rukovodilac",
                table: "Rukovodilac");

            migrationBuilder.RenameTable(
                name: "Rukovodilac",
                newName: "rukovodilacs");

            migrationBuilder.AddColumn<int>(
                name: "ansamblID_an",
                table: "clans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "datumupisa",
                table: "clans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_rukovodilacs",
                table: "rukovodilacs",
                column: "ID_rk");

            migrationBuilder.CreateIndex(
                name: "IX_clans_ansamblID_an",
                table: "clans",
                column: "ansamblID_an");

            migrationBuilder.AddForeignKey(
                name: "FK_ansambls_rukovodilacs_rukovodilacID_rk",
                table: "ansambls",
                column: "rukovodilacID_rk",
                principalTable: "rukovodilacs",
                principalColumn: "ID_rk",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clans_ansambls_ansamblID_an",
                table: "clans",
                column: "ansamblID_an",
                principalTable: "ansambls",
                principalColumn: "ID_an",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ansambls_rukovodilacs_rukovodilacID_rk",
                table: "ansambls");

            migrationBuilder.DropForeignKey(
                name: "FK_clans_ansambls_ansamblID_an",
                table: "clans");

            migrationBuilder.DropIndex(
                name: "IX_clans_ansamblID_an",
                table: "clans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rukovodilacs",
                table: "rukovodilacs");

            migrationBuilder.DropColumn(
                name: "ansamblID_an",
                table: "clans");

            migrationBuilder.DropColumn(
                name: "datumupisa",
                table: "clans");

            migrationBuilder.RenameTable(
                name: "rukovodilacs",
                newName: "Rukovodilac");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rukovodilac",
                table: "Rukovodilac",
                column: "ID_rk");

            migrationBuilder.CreateTable(
                name: "spojs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanID = table.Column<int>(type: "int", nullable: false),
                    ansamblID_an = table.Column<int>(type: "int", nullable: false),
                    sposobnost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spojs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_spojs_ansambls_ansamblID_an",
                        column: x => x.ansamblID_an,
                        principalTable: "ansambls",
                        principalColumn: "ID_an",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spojs_clans_ClanID",
                        column: x => x.ClanID,
                        principalTable: "clans",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "instruments",
                columns: table => new
                {
                    ID_ins = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpojID = table.Column<int>(type: "int", nullable: true),
                    naziv_ins = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruments", x => x.ID_ins);
                    table.ForeignKey(
                        name: "FK_instruments_spojs_SpojID",
                        column: x => x.SpojID,
                        principalTable: "spojs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClanInstrument",
                columns: table => new
                {
                    clanoviClanID = table.Column<int>(type: "int", nullable: false),
                    instrumentiID_ins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanInstrument", x => new { x.clanoviClanID, x.instrumentiID_ins });
                    table.ForeignKey(
                        name: "FK_ClanInstrument_clans_clanoviClanID",
                        column: x => x.clanoviClanID,
                        principalTable: "clans",
                        principalColumn: "ClanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanInstrument_instruments_instrumentiID_ins",
                        column: x => x.instrumentiID_ins,
                        principalTable: "instruments",
                        principalColumn: "ID_ins",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanInstrument_instrumentiID_ins",
                table: "ClanInstrument",
                column: "instrumentiID_ins");

            migrationBuilder.CreateIndex(
                name: "IX_instruments_SpojID",
                table: "instruments",
                column: "SpojID");

            migrationBuilder.CreateIndex(
                name: "IX_spojs_ansamblID_an",
                table: "spojs",
                column: "ansamblID_an");

            migrationBuilder.CreateIndex(
                name: "IX_spojs_ClanID",
                table: "spojs",
                column: "ClanID");

            migrationBuilder.AddForeignKey(
                name: "FK_ansambls_Rukovodilac_rukovodilacID_rk",
                table: "ansambls",
                column: "rukovodilacID_rk",
                principalTable: "Rukovodilac",
                principalColumn: "ID_rk",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
