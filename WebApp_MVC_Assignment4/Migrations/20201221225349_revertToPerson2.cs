using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_MVC_Assignment4.Migrations
{
    public partial class revertToPerson2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "GetPeopleList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "GetPeopleList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GetPeopleList_GetCitiesList_CityId",
                table: "GetPeopleList",
                column: "CityId",
                principalTable: "GetCitiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
