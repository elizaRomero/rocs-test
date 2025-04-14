using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rocs.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RestHours = table.Column<int>(type: "int", nullable: false),
                    LimitWorkers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityType",
                        column: x => x.TypeID,
                        principalTable: "ActivityType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityWorker",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityWorker", x => new { x.ActivityId, x.WorkerId });
                    table.ForeignKey(
                        name: "FK_ActivityWorker_Activity",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityWorker_Worker",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ActivityType",
                columns: new[] { "Id", "LimitWorkers", "Name", "RestHours" },
                values: new object[,]
                {
                    { 1, 1, "Build Component", 2 },
                    { 2, 999, "Build Machine", 4 }
                });

            migrationBuilder.InsertData(
                table: "Worker",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" },
                    { 6, "F" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "EndDate", "Name", "StartDate", "TypeID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), "Build component 1", new DateTime(2025, 4, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), "Build component 2", new DateTime(2025, 4, 13, 19, 1, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Build machine 1", new DateTime(2025, 4, 14, 6, 10, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), "Build machine 2", new DateTime(2025, 4, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 4, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), "Build machine 3", new DateTime(2025, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), "Build component 3", new DateTime(2025, 4, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 4, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), "Build component 4", new DateTime(2025, 4, 19, 19, 10, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 21, 23, 30, 0, 0, DateTimeKind.Unspecified), "Build machine 4", new DateTime(2025, 4, 21, 11, 30, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "ActivityWorker",
                columns: new[] { "ActivityId", "WorkerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 8, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_TypeID",
                table: "Activity",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityWorker_WorkerId",
                table: "ActivityWorker",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityWorker");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "ActivityType");
        }
    }
}
