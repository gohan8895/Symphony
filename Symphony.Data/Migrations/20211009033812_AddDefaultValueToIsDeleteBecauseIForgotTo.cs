using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Symphony.Data.Migrations
{
    public partial class AddDefaultValueToIsDeleteBecauseIForgotTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "CourseRegistrations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e1af6f8-e38c-49ca-9ede-7816c1015eb2"),
                column: "ConcurrencyStamp",
                value: "516ce70d-8650-489c-8612-4498bd435e1c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f5710016-2583-453d-a9f9-714583c49265");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92ece64c-416a-4acb-a27e-52922849c5a8"),
                column: "ConcurrencyStamp",
                value: "80bb21b6-6dad-4fa8-89f9-0effbcaffcd2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("13b5bfee-08c4-425c-b3b3-569fed96dfef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97b27b02-364d-4ad9-bcea-e22044a8e917", "AQAAAAEAACcQAAAAEJ+oPtsdLRCMQTwMwvyY76oKBUYp0LHsKjb2ghwsbyYgOrjaH9dUCEy2NIIUDFxwIQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2c773cb-a1e0-4441-8d66-8e1a90afd4fc", "AQAAAAEAACcQAAAAEI3joqm3bGcXu3UzRn+8i9HJ13HJrwnWOUAoCXZpkAR6Ma/FZHz+NAinRXFDh8x52w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentStatus");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Questions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "Enrollments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDelete",
                table: "CourseRegistrations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

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
    }
}
