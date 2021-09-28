using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Symphony.Data.Migrations
{
    public partial class add_column_to_Exams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxScore",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequiredScore",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f788bf7f-e083-4067-aadb-3f791dfa19d3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e50c502-094a-418f-a879-104aa477af7a", "AQAAAAEAACcQAAAAEHWMqf4UaMILf8Voly72hED2KPvcgRCmle4DPdOTPz0J1rDJgcgstQPUzCzIftBvMw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxScore",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "RequiredScore",
                table: "Exams");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ee3def32-5da4-438e-86b0-770dec4dffc5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "649b7f0f-0299-4fd6-9665-735701114cbf", "AQAAAAEAACcQAAAAEHzD3DeqkcwFmkjwwuJumVzlAOSDdsOQNAL5/vW4kjXbOuChWGoEu403KuA7/8Y6dQ==" });
        }
    }
}
