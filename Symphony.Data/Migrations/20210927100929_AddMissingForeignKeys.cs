using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Symphony.Data.Migrations
{
    public partial class AddMissingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_AppUsers_AppUserId",
                table: "CourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_AppUsers_AppUserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Results_AppUsers_AppUserId",
                table: "Exam_Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Answer_AppUsers_AppUserId",
                table: "Student_Answer");

            migrationBuilder.DropIndex(
                name: "IX_Student_Answer_AppUserId",
                table: "Student_Answer");

            migrationBuilder.DropIndex(
                name: "IX_Exam_Results_AppUserId",
                table: "Exam_Results");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_AppUserId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegistrations_AppUserId",
                table: "CourseRegistrations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Student_Answer");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Exam_Results");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CourseRegistrations");

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Questions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Exams",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ExamRegistrations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Enrollments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CourseRegistrations",
                type: "bit",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Student_Answer_UserId",
                table: "Student_Answer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Results_UserId",
                table: "Exam_Results",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_UserId",
                table: "CourseRegistrations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_AppUsers_UserId",
                table: "CourseRegistrations",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_AppUsers_UserId",
                table: "Enrollments",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Results_AppUsers_UserId",
                table: "Exam_Results",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Answer_AppUsers_UserId",
                table: "Student_Answer",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegistrations_AppUsers_UserId",
                table: "CourseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_AppUsers_UserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Results_AppUsers_UserId",
                table: "Exam_Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Answer_AppUsers_UserId",
                table: "Student_Answer");

            migrationBuilder.DropIndex(
                name: "IX_Student_Answer_UserId",
                table: "Student_Answer");

            migrationBuilder.DropIndex(
                name: "IX_Exam_Results_UserId",
                table: "Exam_Results");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegistrations_UserId",
                table: "CourseRegistrations");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ExamRegistrations");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CourseRegistrations");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Student_Answer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Exam_Results",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Enrollments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "CourseRegistrations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "3436425e-44b7-44f9-b974-df50ae877fbf");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09fb914a-bae9-4559-99ba-e96a2f52d237", "AQAAAAEAACcQAAAAEOsS2jkjm8XmCtAI8Jk8/BnARzvxm4R2/IlZXTh2s1aou/umpj9H87ByPKKXd+HC0A==" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Answer_AppUserId",
                table: "Student_Answer",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Results_AppUserId",
                table: "Exam_Results",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_AppUserId",
                table: "Enrollments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_AppUserId",
                table: "CourseRegistrations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegistrations_AppUsers_AppUserId",
                table: "CourseRegistrations",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_AppUsers_AppUserId",
                table: "Enrollments",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Results_AppUsers_AppUserId",
                table: "Exam_Results",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Answer_AppUsers_AppUserId",
                table: "Student_Answer",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
