using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_MVC_Assignment4.Migrations
{
    public partial class CreateCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "GetCitiesList",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetCountriesList",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetCountriesList", x => x.CountryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetCitiesList_CountryId",
                table: "GetCitiesList",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GetCitiesList_GetCountriesList_CountryId",
                table: "GetCitiesList",
                column: "CountryId",
                principalTable: "GetCountriesList",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetCitiesList_GetCountriesList_CountryId",
                table: "GetCitiesList");

            migrationBuilder.DropTable(
                name: "GetCountriesList");

            migrationBuilder.DropIndex(
                name: "IX_GetCitiesList_CountryId",
                table: "GetCitiesList");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "GetCitiesList");
        }
    }
}
