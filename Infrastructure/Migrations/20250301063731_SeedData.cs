using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfosecLearningSystem_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Crypto related modules", "Crypto" },
                    { 2, "Pwn related modules", "Pwn" },
                    { 3, "Rev related modules", "Rev" },
                    { 4, "Web related modules", "Web" }
                });

            migrationBuilder.InsertData(
                table: "lesson_types",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Video lesson", "Video" },
                    { 2, "Markdown lesson", "Markdown" },
                    { 3, "Quiz lesson", "Quiz" }
                });

            migrationBuilder.InsertData(
                table: "lifecycle_states",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Module is being created", "Creating" },
                    { 2, "Module is being updated", "Updating" },
                    { 3, "Module is published", "Published" }
                });

            migrationBuilder.InsertData(
                table: "progress_states",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Module is not started", "Locked" },
                    { 2, "Module is being learned", "Learning" },
                    { 3, "Module is completed", "Completed" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "Collaborator" },
                    { 3, null, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "lesson_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "lesson_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "lesson_types",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "lifecycle_states",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "lifecycle_states",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "lifecycle_states",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "progress_states",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "progress_states",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "progress_states",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
