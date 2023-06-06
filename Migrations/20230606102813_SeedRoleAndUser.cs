using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore_tutorial.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("12345");

            migrationBuilder.Sql("INSERT INTO Roles (Name) VALUES ('User')");
            migrationBuilder.Sql("INSERT INTO Roles (Name) VALUES ('Admin')");

            migrationBuilder.Sql($"INSERT INTO Users (Username, Email, PasswordHash, RoleId) VALUES ('bungdanar', 'bungdanar@gmail.com', '{passwordHash}', (SELECT Id FROM Roles WHERE Name = 'Admin'))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Roles WHERE Name IN ('User', 'Admin')");
        }
    }
}
