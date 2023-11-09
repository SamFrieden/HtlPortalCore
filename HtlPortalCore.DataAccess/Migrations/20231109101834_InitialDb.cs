using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HtlPortalCore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Portal");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Portal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Portal",
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "EmailConfirmed", "IsActive", "ModifiedOn", "Name", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { "cdfb7c4e-9774-47e9-8089-90c76a0c8bd6", new DateTime(2023, 11, 9, 11, 18, 34, 29, DateTimeKind.Local).AddTicks(230), "admin@abc.at", true, false, null, "Administrator", "4d1537ac-75ff-cf4b-60cc-f3da555da312", "12345", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "Portal",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                schema: "Portal",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "Portal",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "Portal");
        }
    }
}
