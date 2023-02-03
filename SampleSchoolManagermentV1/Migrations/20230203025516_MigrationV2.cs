using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleSchoolManagermentV1.Migrations
{
    public partial class MigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InforClass",
                columns: table => new
                {
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "integer", maxLength: 12, nullable: false),
                    TeacherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InforClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    SlotInWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_InforClass_ClassId",
                        column: x => x.ClassId,
                        principalTable: "InforClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    slot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTable_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentMark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    typeOfMark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mark = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentMark_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMark_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InforClass",
                columns: new[] { "Id", "ClassName", "Grade", "TeacherName" },
                values: new object[,]
                {
                    { 1, "1A", 1, "Nguyen Thi Hanh" },
                    { 2, "1B", 1, "Nguyen Thi Hoa" },
                    { 3, "2A", 2, "Nguyen Van Thanh" },
                    { 4, "2B", 2, "Chu Thi Hanh" },
                    { 5, "3A", 3, "Nguyen Thi Thuy" },
                    { 6, "3B", 3, "Chu Thi Thuy" },
                    { 7, "4A", 4, "Hoang Thi Tham" },
                    { 8, "4B", 4, "Vuong Thi Minh Hanh" },
                    { 9, "5A", 5, "Hoang Thi Hoa" },
                    { 10, "5B", 5, "Pham Thi Chuc" },
                    { 11, "1C", 1, "Hoang Thi Tham" },
                    { 12, "1D", 1, "Vuong Thi Minh Hanh" },
                    { 13, "2C", 2, "Hoang Thi Hoa" },
                    { 14, "2D", 2, "Pham Thi Chuc" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Grade", "Semester", "SlotInWeek", "SubjectName" },
                values: new object[,]
                {
                    { 1, 1, 1, 5, "Toan" },
                    { 2, 1, 2, 5, "Toan" },
                    { 3, 1, 1, 5, "Van" },
                    { 4, 1, 2, 5, "Van" },
                    { 5, 1, 1, 5, "Anh" },
                    { 6, 1, 2, 5, "Anh" },
                    { 7, 1, 1, 5, "Hoa" },
                    { 8, 1, 2, 5, "Hoa" },
                    { 9, 1, 1, 5, "Li" },
                    { 10, 1, 2, 5, "Li" },
                    { 11, 1, 1, 5, "Sinh" },
                    { 12, 1, 2, 5, "Sinh" },
                    { 13, 1, 1, 5, "GDCD" },
                    { 14, 1, 2, 5, "GDCD" },
                    { 15, 2, 1, 5, "Toan" },
                    { 16, 2, 2, 5, "Toan" },
                    { 17, 2, 1, 5, "Van" },
                    { 18, 2, 2, 5, "Van" },
                    { 19, 2, 1, 5, "Anh" },
                    { 20, 2, 2, 5, "Anh" },
                    { 21, 2, 1, 5, "Hoa" },
                    { 22, 2, 2, 5, "Hoa" },
                    { 23, 2, 1, 5, "Li" },
                    { 24, 2, 2, 5, "Li" },
                    { 25, 2, 1, 5, "Sinh" },
                    { 26, 2, 2, 5, "Sinh" },
                    { 27, 2, 1, 5, "GDCD" },
                    { 28, 2, 2, 5, "GDCD" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Grade", "Semester", "SlotInWeek", "SubjectName" },
                values: new object[,]
                {
                    { 29, 3, 1, 5, "Toan" },
                    { 30, 3, 2, 5, "Toan" },
                    { 31, 3, 1, 5, "Van" },
                    { 32, 3, 2, 5, "Van" },
                    { 33, 3, 1, 5, "Anh" },
                    { 34, 3, 2, 5, "Anh" },
                    { 35, 3, 1, 5, "Hoa" },
                    { 36, 3, 2, 5, "Hoa" },
                    { 37, 3, 1, 5, "Li" },
                    { 38, 3, 2, 5, "Li" },
                    { 39, 3, 1, 5, "Sinh" },
                    { 40, 3, 2, 5, "Sinh" },
                    { 41, 3, 1, 5, "GDCD" },
                    { 42, 3, 2, 5, "GDCD" },
                    { 43, 4, 1, 5, "Toan" },
                    { 44, 4, 2, 5, "Toan" },
                    { 45, 4, 1, 5, "Van" },
                    { 46, 4, 2, 5, "Van" },
                    { 47, 4, 1, 5, "Anh" },
                    { 48, 4, 2, 5, "Anh" },
                    { 49, 4, 1, 5, "Hoa" },
                    { 50, 4, 2, 5, "Hoa" },
                    { 51, 4, 1, 5, "Li" },
                    { 52, 4, 2, 5, "Li" },
                    { 53, 4, 1, 5, "Sinh" },
                    { 54, 4, 2, 5, "Sinh" },
                    { 55, 4, 1, 5, "GDCD" },
                    { 56, 4, 2, 5, "GDCD" },
                    { 57, 5, 1, 5, "Toan" },
                    { 58, 5, 2, 5, "Toan" },
                    { 59, 5, 1, 5, "Van" },
                    { 60, 5, 2, 5, "Van" },
                    { 61, 5, 1, 5, "Anh" },
                    { 62, 5, 2, 5, "Anh" },
                    { 63, 5, 1, 5, "Hoa" },
                    { 64, 5, 2, 5, "Hoa" },
                    { 65, 5, 1, 5, "Li" },
                    { 66, 5, 2, 5, "Li" },
                    { 67, 5, 1, 5, "Sinh" },
                    { 68, 5, 2, 5, "Sinh" },
                    { 69, 5, 1, 5, "GDCD" },
                    { 70, 5, 2, 5, "GDCD" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Address", "ClassId", "DateOfBirth", "FatherName", "Gender", "MotherName", "StudentName" },
                values: new object[,]
                {
                    { 1, "Ha Noi", 1, new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Nguyen Khanh Toan" },
                    { 2, "Ha Noi", 1, new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "", "Nguyen Ngoc Long" },
                    { 3, "Ha Noi", 2, new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Chu Khanh Toan" },
                    { 4, "Ha Noi", 2, new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Hoang Van Long" },
                    { 5, "Ha Noi", 3, new DateTime(2014, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "", "Pham Thanh Xuan" },
                    { 6, "Ha Noi", 3, new DateTime(2014, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Vu Duc Khanh" },
                    { 7, "Ha Noi", 4, new DateTime(2014, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "", "Chuong Thi Khanh Toan" },
                    { 8, "Ha Noi", 4, new DateTime(2014, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Nguyen Thanh Long" },
                    { 9, "Ha Noi", 5, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "", "Do Thi Huong" },
                    { 10, "Ha Noi", 5, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Truong Dang Hieu" },
                    { 11, "Ha Noi", 6, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Truong Quoc Sinh" },
                    { 12, "Ha Noi", 6, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "", "Nguyen Thu Huong" },
                    { 13, "Ha Noi", 6, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, "", "Do Thi Mai" },
                    { 14, "Ha Noi", 1, new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "", "Nguyen Khanh Mai" }
                });

            migrationBuilder.InsertData(
                table: "StudentMark",
                columns: new[] { "Id", "Mark", "StudentId", "SubjectId", "typeOfMark" },
                values: new object[,]
                {
                    { 1, 4f, 1, 1, "15 phut" },
                    { 2, 5f, 2, 1, "15 phut" },
                    { 3, 7f, 3, 1, "15 phut" },
                    { 4, 6f, 4, 1, "15 phut" },
                    { 5, 8f, 5, 1, "15 phut" },
                    { 6, 9f, 6, 1, "15 phut" },
                    { 7, 8f, 1, 1, "1 Tiet" },
                    { 8, 5f, 2, 1, "1 Tiet" },
                    { 9, 7f, 3, 1, "1 Tiet" },
                    { 10, 4f, 4, 1, "1 Tiet" },
                    { 11, 6f, 5, 1, "1 Tiet" },
                    { 12, 9f, 6, 1, "1 Tiet" },
                    { 13, 8f, 1, 1, "Giua ki" },
                    { 14, 4f, 2, 1, "Giua ki" },
                    { 15, 6f, 3, 1, "Giua ki" },
                    { 16, 4f, 4, 1, "Giua ki" },
                    { 17, 5f, 5, 1, "Giua ki" },
                    { 18, 7f, 6, 1, "Giua ki" },
                    { 19, 7f, 1, 1, "Cuoi ki" },
                    { 20, 4f, 2, 1, "Cuoi ki" },
                    { 21, 5f, 3, 1, "Cuoi ki" },
                    { 22, 7f, 4, 1, "Cuoi ki" },
                    { 23, 8f, 5, 1, "Cuoi ki" },
                    { 24, 9f, 6, 1, "Cuoi ki" },
                    { 25, 9f, 1, 2, "15 phut" },
                    { 26, 9f, 1, 2, "1 tiet" },
                    { 27, 9f, 1, 2, "Giua ki" },
                    { 28, 9f, 1, 2, "Cuoi ki" },
                    { 29, 6f, 1, 3, "15 phut" },
                    { 30, 5f, 1, 3, "1 tiet" },
                    { 31, 6f, 1, 3, "Giua ki" },
                    { 32, 7f, 1, 3, "Cuoi ki" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMark_StudentId",
                table: "StudentMark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMark_SubjectId",
                table: "StudentMark",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_SubjectId",
                table: "TimeTable",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StudentMark");

            migrationBuilder.DropTable(
                name: "TimeTable");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "InforClass");
        }
    }
}
