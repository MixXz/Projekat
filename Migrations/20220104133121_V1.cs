using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.ID);
                });

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
                name: "TezinaPripreme",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tezina = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TezinaPripreme", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instrukcija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    VremeZaPripremu = table.Column<int>(type: "int", nullable: false),
                    SastojciID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Recept",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InstrukcijaID = table.Column<int>(type: "int", nullable: false),
                    TezinaPripremeID = table.Column<int>(type: "int", nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recept", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Recept_Instrukcija_InstrukcijaID",
                        column: x => x.InstrukcijaID,
                        principalTable: "Instrukcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recept_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recept_TezinaPripreme_TezinaPripremeID",
                        column: x => x.TezinaPripremeID,
                        principalTable: "TezinaPripreme",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrukcija_SastojciID",
                table: "Instrukcija",
                column: "SastojciID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recept_InstrukcijaID",
                table: "Recept",
                column: "InstrukcijaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recept_KategorijaID",
                table: "Recept",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Recept_TezinaPripremeID",
                table: "Recept",
                column: "TezinaPripremeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recept");

            migrationBuilder.DropTable(
                name: "Instrukcija");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "TezinaPripreme");

            migrationBuilder.DropTable(
                name: "Sastojci");
        }
    }
}
