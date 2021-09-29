using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Symphony.Data.Migrations
{
    public partial class fix_table_examregistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamRegistrations_AppUsers_AppUserId",
                table: "ExamRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_ExamRegistrations_AppUserId",
                table: "ExamRegistrations");

            migrationBuilder.DropColumn(
                name: "AppUser",
                table: "ExamRegistrations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ExamRegistrations");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "812de486-8704-4b8c-bcf2-ccd552910807", "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "0591a69c-814e-46ee-9df5-7edeb77c0406", "TRUNG.NGUYEN@GMAIL.COM", "TRUNG.NGUYEN@GMAIL.COM", "AQAAAAEAACcQAAAAEFrAz9s92VM0N1akGJBAfmkV0TDJTxE5nwDKzqM0fYjn3P1HLgMlam/bj1Q0wyFhCA==", "trung.nguyen@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_ExamRegistrations_UserId",
                table: "ExamRegistrations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamRegistrations_AppUsers_UserId",
                table: "ExamRegistrations",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamRegistrations_AppUsers_UserId",
                table: "ExamRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_ExamRegistrations_UserId",
                table: "ExamRegistrations");

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
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f788bf7f-e083-4067-aadb-3f791dfa19d3", "trung.nguyen@gmail.com", "trung.nguyen@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "7e50c502-094a-418f-a879-104aa477af7a", "trung.nguyen@gmail.com", "admin", "AQAAAAEAACcQAAAAEHWMqf4UaMILf8Voly72hED2KPvcgRCmle4DPdOTPz0J1rDJgcgstQPUzCzIftBvMw==", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ExamRegistrations_AppUserId",
                table: "ExamRegistrations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamRegistrations_AppUsers_AppUserId",
                table: "ExamRegistrations",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
