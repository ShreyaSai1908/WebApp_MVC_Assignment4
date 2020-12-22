using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_MVC_Assignment4.Migrations
{
    public partial class addedCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "GetPeopleList",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetCitiesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: false),
                    States = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetCitiesList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetPeopleList_CityId",
                table: "GetPeopleList",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList",
                column: "CityId",
                principalTable: "GetCitiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList");

            migrationBuilder.DropTable(
                name: "GetCitiesList");

            migrationBuilder.DropIndex(
                name: "IX_GetPeopleList_CityId",
                table: "GetPeopleList");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "GetPeopleList");
        }
    }
}
