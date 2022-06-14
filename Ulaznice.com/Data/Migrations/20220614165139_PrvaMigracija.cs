using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ulaznice.com.Data.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MjestoDogađaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeografskaŠirina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeografskaDužina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpisMjesta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaćanje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nagrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nagrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PorukaDobitnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdabirDobitnika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorukaDobitnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PovratniMail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zahvalnica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PovratniMail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlobodnaMjesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSlobodnihMjesta = table.Column<int>(type: "int", nullable: false),
                    BrojMjesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlobodnaMjesta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NagradnaIgra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisNagradneIgre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NagradaId = table.Column<int>(type: "int", nullable: false),
                    InformacijeODobitniku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorukaDobitnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NagradnaIgra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NagradnaIgra_Nagrada_NagradaId",
                        column: x => x.NagradaId,
                        principalTable: "Nagrada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NagradnaIgra_PorukaDobitnik_PorukaDobitnikId",
                        column: x => x.PorukaDobitnikId,
                        principalTable: "PorukaDobitnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MjestoDogađaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumDogađaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzvođačiDogađaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CijenaKarte = table.Column<float>(type: "real", nullable: false),
                    OpisDogađaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PovratniMailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karta_PovratniMail_PovratniMailId",
                        column: x => x.PovratniMailId,
                        principalTable: "PovratniMail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojBankovnogRačuna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KartaId = table.Column<int>(type: "int", nullable: false),
                    NagradnaIgraId = table.Column<int>(type: "int", nullable: false),
                    PorukaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_NagradnaIgra_NagradnaIgraId",
                        column: x => x.NagradnaIgraId,
                        principalTable: "NagradnaIgra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manifestacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KartaId = table.Column<int>(type: "int", nullable: false),
                    OpisKupnjeKarte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NacinPlacanjaId = table.Column<int>(type: "int", nullable: false),
                    NagradnaIgraId = table.Column<int>(type: "int", nullable: false),
                    Legenda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlobodnaMjestaId = table.Column<int>(type: "int", nullable: false),
                    VrijemeOdržavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifestacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manifestacija_Karta_KartaId",
                        column: x => x.KartaId,
                        principalTable: "Karta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifestacija_Lokacija_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifestacija_NacinPlacanja_NacinPlacanjaId",
                        column: x => x.NacinPlacanjaId,
                        principalTable: "NacinPlacanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifestacija_NagradnaIgra_NagradnaIgraId",
                        column: x => x.NagradnaIgraId,
                        principalTable: "NagradnaIgra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manifestacija_SlobodnaMjesta_SlobodnaMjestaId",
                        column: x => x.SlobodnaMjestaId,
                        principalTable: "SlobodnaMjesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karta_PovratniMailId",
                table: "Karta",
                column: "PovratniMailId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_NagradnaIgraId",
                table: "Korisnik",
                column: "NagradnaIgraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacija_KartaId",
                table: "Manifestacija",
                column: "KartaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacija_LokacijaId",
                table: "Manifestacija",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacija_NacinPlacanjaId",
                table: "Manifestacija",
                column: "NacinPlacanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacija_NagradnaIgraId",
                table: "Manifestacija",
                column: "NagradnaIgraId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifestacija_SlobodnaMjestaId",
                table: "Manifestacija",
                column: "SlobodnaMjestaId");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgra_NagradaId",
                table: "NagradnaIgra",
                column: "NagradaId");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgra_PorukaDobitnikId",
                table: "NagradnaIgra",
                column: "PorukaDobitnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Manifestacija");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "NagradnaIgra");

            migrationBuilder.DropTable(
                name: "SlobodnaMjesta");

            migrationBuilder.DropTable(
                name: "PovratniMail");

            migrationBuilder.DropTable(
                name: "Nagrada");

            migrationBuilder.DropTable(
                name: "PorukaDobitnik");
        }
    }
}
