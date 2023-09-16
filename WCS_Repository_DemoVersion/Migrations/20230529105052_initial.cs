using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WCS_Repository_DemoVersion.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    IdRegion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfRegion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.IdRegion);
                });

            migrationBuilder.CreateTable(
                name: "SubjectOfTheRegions",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectOfTheRegions", x => x.IdSubject);
                    table.ForeignKey(
                        name: "FK_SubjectOfTheRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "IdRegion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherServices",
                columns: table => new
                {
                    IdWeatherService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<double>(type: "float", nullable: false),
                    WindSpeed = table.Column<double>(type: "float", nullable: false),
                    Precipitation = table.Column<double>(type: "float", nullable: false),
                    SubjectOfTheRegionIdSubject = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherServices", x => x.IdWeatherService);
                    table.ForeignKey(
                        name: "FK_WeatherServices_SubjectOfTheRegions_SubjectOfTheRegionIdSubject",
                        column: x => x.SubjectOfTheRegionIdSubject,
                        principalTable: "SubjectOfTheRegions",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectOfTheRegions_RegionId",
                table: "SubjectOfTheRegions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherServices_SubjectOfTheRegionIdSubject",
                table: "WeatherServices",
                column: "SubjectOfTheRegionIdSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherServices");

            migrationBuilder.DropTable(
                name: "SubjectOfTheRegions");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
