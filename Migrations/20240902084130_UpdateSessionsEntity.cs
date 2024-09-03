using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEPI_E_Learning.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSessionsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseId",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Modules",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_CourseId",
                table: "Modules",
                newName: "IX_Modules_SessionId");

            migrationBuilder.AddColumn<int>(
                name: "CourseModelCourseId",
                table: "Modules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SessionModel",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionModel", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_SessionModel_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseModelCourseId",
                table: "Modules",
                column: "CourseModelCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionModel_CourseId",
                table: "SessionModel",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseModelCourseId",
                table: "Modules",
                column: "CourseModelCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_SessionModel_SessionId",
                table: "Modules",
                column: "SessionId",
                principalTable: "SessionModel",
                principalColumn: "SessionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseModelCourseId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_SessionModel_SessionId",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "SessionModel");

            migrationBuilder.DropIndex(
                name: "IX_Modules_CourseModelCourseId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "CourseModelCourseId",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Modules",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_SessionId",
                table: "Modules",
                newName: "IX_Modules_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseId",
                table: "Modules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
