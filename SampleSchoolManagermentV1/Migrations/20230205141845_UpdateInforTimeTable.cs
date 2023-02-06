using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleSchoolManagermentV1.Migrations
{
    public partial class UpdateInforTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Classid",
                table: "TimeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_Classid",
                table: "TimeTable",
                column: "Classid");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTable_InforClass_Classid",
                table: "TimeTable",
                column: "Classid",
                principalTable: "InforClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTable_InforClass_Classid",
                table: "TimeTable");

            migrationBuilder.DropIndex(
                name: "IX_TimeTable_Classid",
                table: "TimeTable");

            migrationBuilder.DropColumn(
                name: "Classid",
                table: "TimeTable");
        }
    }
}
