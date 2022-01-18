using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recept_Instrukcija_InstrukcijaID",
                table: "Recept");

            migrationBuilder.DropTable(
                name: "Instrukcija");

            migrationBuilder.DropTable(
                name: "Sastojci");

            migrationBuilder.DropIndex(
                name: "IX_Recept_InstrukcijaID",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "InstrukcijaID",
                table: "Recept");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Recept",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "Instrukcija",
                table: "Recept",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sastojci",
                table: "Recept",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipID",
                table: "Recept",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VremePripreme",
                table: "Recept",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipJela = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recept_TipID",
                table: "Recept",
                column: "TipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recept_Tip_TipID",
                table: "Recept",
                column: "TipID",
                principalTable: "Tip",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recept_Tip_TipID",
                table: "Recept");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropIndex(
                name: "IX_Recept_TipID",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "Instrukcija",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "Sastojci",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "TipID",
                table: "Recept");

            migrationBuilder.DropColumn(
                name: "VremePripreme",
                table: "Recept");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Recept",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "InstrukcijaID",
                table: "Recept",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sastojci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlavniSastojak = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OstaliSastojci = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastojci", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instrukcija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SastojciID = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    VremeZaPripremu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrukcija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instrukcija_Sastojci_SastojciID",
                        column: x => x.SastojciID,
                        principalTable: "Sastojci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recept_InstrukcijaID",
                table: "Recept",
                column: "InstrukcijaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instrukcija_SastojciID",
                table: "Instrukcija",
                column: "SastojciID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recept_Instrukcija_InstrukcijaID",
                table: "Recept",
                column: "InstrukcijaID",
                principalTable: "Instrukcija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
