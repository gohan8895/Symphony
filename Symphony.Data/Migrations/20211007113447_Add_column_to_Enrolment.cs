using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Symphony.Data.Migrations
{
    public partial class Add_column_to_Enrolment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsShown",
                table: "News",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShown",
                table: "FAQs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShown",
                table: "Events",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e1af6f8-e38c-49ca-9ede-7816c1015eb2"),
                column: "ConcurrencyStamp",
                value: "e4661e6a-fa95-4d83-8294-f55ea26d89f4");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b217e63f-e3ff-4d62-935f-1e108c0f013b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92ece64c-416a-4acb-a27e-52922849c5a8"),
                column: "ConcurrencyStamp",
                value: "11847cd3-3ada-4c1c-ab83-a1a8a2633941");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("13b5bfee-08c4-425c-b3b3-569fed96dfef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d1d7906-8f0a-4bcb-b63e-a0deb71fdacb", "AQAAAAEAACcQAAAAEHeL03t0W9omVFNQUfsunEJ78nGcU/61DKpmiES6IT1eCOVRhJoOyT60WqoHBIYqeQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d8935b0-e19f-42d7-b837-5466ec7003ec", "AQAAAAEAACcQAAAAED1gD/vbeUYFn/KVaGkUmXFoHq/K2D44WyWM6nP2JCiZFsMen/TTFFNw+6dNd6EtaA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Enrollments");

            migrationBuilder.AlterColumn<bool>(
                name: "IsShown",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsShown",
                table: "FAQs",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsShown",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e1af6f8-e38c-49ca-9ede-7816c1015eb2"),
                column: "ConcurrencyStamp",
                value: "a73a8149-e296-4a80-909c-590a6cc549df");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "71f42542-ff6b-4d13-8796-ae5bce852dd7");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92ece64c-416a-4acb-a27e-52922849c5a8"),
                column: "ConcurrencyStamp",
                value: "2bf6865d-b644-4b36-a271-f655d313a404");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("13b5bfee-08c4-425c-b3b3-569fed96dfef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b6251b7-9618-42d3-8c5c-3839ff099555", "AQAAAAEAACcQAAAAEMfbPJo0eRoLlzPnFekrrXW8Nty0TOGm6yaU277xe8OqLxp7P7t8U1ha/T5FuZ6fTQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d199570-7a97-4598-b417-b444b43693bb", "AQAAAAEAACcQAAAAEGTWz+0/FQO8PJSiNiUCw/uvmuywdVuUJwhLpnjt/JEAWjH56ngUqoK6IdnHOzAE1A==" });
        }
    }
}
