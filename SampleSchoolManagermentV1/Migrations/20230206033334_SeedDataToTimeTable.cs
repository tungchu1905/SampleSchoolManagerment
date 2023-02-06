using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleSchoolManagermentV1.Migrations
{
    public partial class SeedDataToTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TimeTable",
                columns: new[] { "Id", "Classid", "Day", "SubjectId", "slot" },
                values: new object[,]
                {
                    { 1, 1, "Thu 2", 1, 2 },
                    { 2, 1, "Thu 2", 3, 3 },
                    { 3, 1, "Thu 2", 5, 4 },
                    { 4, 1, "Thu 2", 7, 6 },
                    { 5, 1, "Thu 2", 9, 7 },
                    { 6, 1, "Thu 2", 11, 8 },
                    { 7, 1, "Thu 3", 13, 1 },
                    { 8, 1, "Thu 3", 1, 3 },
                    { 9, 1, "Thu 3", 5, 5 },
                    { 10, 1, "Thu 3", 7, 7 },
                    { 11, 1, "Thu 3", 9, 9 },
                    { 12, 1, "Thu 4", 5, 1 },
                    { 13, 1, "Thu 4", 3, 2 },
                    { 14, 1, "Thu 4", 7, 4 },
                    { 15, 1, "Thu 4", 13, 6 },
                    { 16, 1, "Thu 4", 1, 8 },
                    { 17, 1, "Thu 5", 1, 2 },
                    { 18, 1, "Thu 5", 7, 4 },
                    { 19, 1, "Thu 5", 13, 6 },
                    { 20, 1, "Thu 5", 9, 8 },
                    { 21, 1, "Thu 6", 3, 1 },
                    { 22, 1, "Thu 6", 5, 4 },
                    { 23, 1, "Thu 6", 9, 6 },
                    { 24, 1, "Thu 6", 7, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TimeTable",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
