using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_MVC_Assignment4.Migrations
{
    public partial class alterTabPeople_AddColCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "GetPeopleList",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList",
                column: "CityId",
                principalTable: "GetCitiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "GetPeopleList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList",
                column: "CityId",
                principalTable: "GetCitiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
