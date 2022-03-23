using Microsoft.EntityFrameworkCore.Migrations;

namespace Awe.Migrations
{
    public partial class V17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spoj_Clanarina_clanarinaID",
                table: "Spoj");

            migrationBuilder.DropForeignKey(
                name: "FK_Spoj_clans_ClanID",
                table: "Spoj");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spoj",
                table: "Spoj");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clanarina",
                table: "Clanarina");

            migrationBuilder.RenameTable(
                name: "Spoj",
                newName: "spojs");

            migrationBuilder.RenameTable(
                name: "Clanarina",
                newName: "clanarinas");

            migrationBuilder.RenameIndex(
                name: "IX_Spoj_ClanID",
                table: "spojs",
                newName: "IX_spojs_ClanID");

            migrationBuilder.RenameIndex(
                name: "IX_Spoj_clanarinaID",
                table: "spojs",
                newName: "IX_spojs_clanarinaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spojs",
                table: "spojs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clanarinas",
                table: "clanarinas",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_spojs_clanarinas_clanarinaID",
                table: "spojs",
                column: "clanarinaID",
                principalTable: "clanarinas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spojs_clans_ClanID",
                table: "spojs",
                column: "ClanID",
                principalTable: "clans",
                principalColumn: "ClanID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spojs_clanarinas_clanarinaID",
                table: "spojs");

            migrationBuilder.DropForeignKey(
                name: "FK_spojs_clans_ClanID",
                table: "spojs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spojs",
                table: "spojs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clanarinas",
                table: "clanarinas");

            migrationBuilder.RenameTable(
                name: "spojs",
                newName: "Spoj");

            migrationBuilder.RenameTable(
                name: "clanarinas",
                newName: "Clanarina");

            migrationBuilder.RenameIndex(
                name: "IX_spojs_ClanID",
                table: "Spoj",
                newName: "IX_Spoj_ClanID");

            migrationBuilder.RenameIndex(
                name: "IX_spojs_clanarinaID",
                table: "Spoj",
                newName: "IX_Spoj_clanarinaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spoj",
                table: "Spoj",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clanarina",
                table: "Clanarina",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spoj_Clanarina_clanarinaID",
                table: "Spoj",
                column: "clanarinaID",
                principalTable: "Clanarina",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spoj_clans_ClanID",
                table: "Spoj",
                column: "ClanID",
                principalTable: "clans",
                principalColumn: "ClanID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
