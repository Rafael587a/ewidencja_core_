using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace core_ewidencja.Migrations
{
    public partial class Migration_9_11_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "czynnosciPojazdy",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_pojazdu = table.Column<int>(nullable: true),
                    przebieg = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    opis_czynnosci = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    data = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_vehicle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_czynnosciPojazdy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblStats",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    visit_host_ip = table.Column<string>(maxLength: 400, nullable: true),
                    date_visited = table.Column<DateTime>(type: "datetime", nullable: true),
                    counter = table.Column<int>(nullable: true),
                    page = table.Column<string>(maxLength: 420, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(unicode: false, maxLength: 490, nullable: true),
                    password = table.Column<string>(unicode: false, maxLength: 900, nullable: true),
                    active = table.Column<int>(nullable: true),
                    added_date = table.Column<DateTime>(type: "date", nullable: true),
                    type_user = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblWaluty",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ins_date = table.Column<DateTime>(type: "date", nullable: true),
                    usd_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    jpy_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    bgn_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    czk_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    dkk_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    gbp_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    huf_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    pln_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    ron_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    sek_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    chf_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    isk_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    nok_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    hrk_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    rub_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    try_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    aud_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    brl_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    cad_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    cny_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    hkd_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    idr_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    ils_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    inr_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    krw_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    mxn_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    myr_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    nzd_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    php_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    sgd_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    thb_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true),
                    zar_value = table.Column<decimal>(type: "decimal(10, 6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWaluty", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblZuzycieEnergii",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    wsk_licznika = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    kwh = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    id_user = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZuzycieEnergii", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblZuzycieGazu",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: true),
                    wsk_licznika = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    kwh = table.Column<decimal>(type: "decimal(6, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZuzycieGazu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblZuzycieWody",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    wsk_licznika = table.Column<decimal>(type: "decimal(10, 6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblZuzycieWody", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "czynnosciPojazdy");

            migrationBuilder.DropTable(
                name: "tblStats");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblWaluty");

            migrationBuilder.DropTable(
                name: "tblZuzycieEnergii");

            migrationBuilder.DropTable(
                name: "tblZuzycieGazu");

            migrationBuilder.DropTable(
                name: "tblZuzycieWody");
        }
    }
}
