using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Symphony.Data.Migrations
{
    public partial class NewSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "71f42542-ff6b-4d13-8796-ae5bce852dd7");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("92ece64c-416a-4acb-a27e-52922849c5a8"), "2bf6865d-b644-4b36-a271-f655d313a404", "Student Role", "student", "STUDENT" },
                    { new Guid("0e1af6f8-e38c-49ca-9ede-7816c1015eb2"), "a73a8149-e296-4a80-909c-590a6cc549df", "Teacher Role", "teacher", "TEACHER" }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d199570-7a97-4598-b417-b444b43693bb", "AQAAAAEAACcQAAAAEGTWz+0/FQO8PJSiNiUCw/uvmuywdVuUJwhLpnjt/JEAWjH56ngUqoK6IdnHOzAE1A==" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BatchId", "ConcurrencyStamp", "CreatedAt", "DOB", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("13b5bfee-08c4-425c-b3b3-569fed96dfef"), 0, null, null, "8b6251b7-9618-42d3-8c5c-3839ff099555", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@symphony.com", true, "Symphony", " ", "Admin", false, null, "ADMIN@SYMPHONY.COM", "ADMIN@SYMPHONY.COM", "AQAAAAEAACcQAAAAEMfbPJo0eRoLlzPnFekrrXW8Nty0TOGm6yaU277xe8OqLxp7P7t8U1ha/T5FuZ6fTQ==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@symphony.com" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("13b5bfee-08c4-425c-b3b3-569fed96dfef") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e1af6f8-e38c-49ca-9ede-7816c1015eb2"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92ece64c-416a-4acb-a27e-52922849c5a8"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("13b5bfee-08c4-425c-b3b3-569fed96dfef") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("13b5bfee-08c4-425c-b3b3-569fed96dfef"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppUser",
                table: "ExamRegistrations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "ExamRegistrations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7dfb8ec5-350f-4345-8fcc-3f5ed6e75926");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2b0672d-22d2-49bd-81a7-44602bce944f", "AQAAAAEAACcQAAAAEEtsSZL39bHB2+gu5zVtwgKNMBsc2tv1524+RptJshadiAH8PAMzV4pxMoWqaO7EgQ==" });
        }
    }
}
