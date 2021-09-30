using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Symphony.Data.Migrations
{
    public partial class AddImageToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "IsShown", "Title" },
                values: new object[,]
                {
                    { 1, "Founded in 2000 in the heart of London, <b>Symphony Ltd.</b> is London's leading private institute, with more than 1000 staffs and 2000 students from different countries. We are a diverse community with the freedom and courage to challenge, to question and to think differently.", true, "Opening" },
                    { 2, "Who we are", true, "First Question" },
                    { 3, "Symphony Institute is a diverse global community of world-class academics, students, industry links, external partners, and alumni. Our powerful collective of individuals and institutes work together to explore new possibilities.", true, "First Answer" },
                    { 4, "Symphony's vision and impact", true, "Second Question" },
                    { 5, "Symphony Institute is a diverse global community of world-class academics, students, industry links, external partners, and alumni. Our powerful collective of individuals and institutes work together to explore new possibilities.", true, "Second Answer" },
                    { 6, "What we has to offer", true, "Third Question" },
                    { 7, "Symphony Institute provides many courses on subject about programming languages like C Sharp, Java, C++, Javascript, Php, Python, Ruby and more... ", true, "Third Answer" }
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcebd616-2030-463e-a60b-511660c2426d", "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "cd32d97c-cb0a-4307-9652-48c22666b222", "TRUNG.NGUYEN@GMAIL.COM", "TRUNG.NGUYEN@GMAIL.COM", "AQAAAAEAACcQAAAAEDm71Sij5H1pZy4owbTDMSRZ3aqOHlw+z9BaIP4FclwQQurPeezZ0KdCYZYa5GcGig==", "trung.nguyen@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed4acdc5-4cc7-4488-89ba-712067db2425", "trung.nguyen@gmail.com", "trung.nguyen@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "43930390-4c0a-4e14-b392-6d8c17f6a90e", "trung.nguyen@gmail.com", "admin", "AQAAAAEAACcQAAAAENMpdsnQ9PVfc18c2IEoDaBXtMxDr1/jPCYr+ddAGV0L2wUE6L5R7HCoVtn436pUmQ==", "admin" });
        }
    }
}
