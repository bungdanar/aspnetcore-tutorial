using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore_tutorial.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact_ContactPhone",
                table: "Vehicles",
                newName: "Contact_Phone");

            migrationBuilder.RenameColumn(
                name: "Contact_ContactName",
                table: "Vehicles",
                newName: "Contact_Name");

            migrationBuilder.RenameColumn(
                name: "Contact_ContactEmail",
                table: "Vehicles",
                newName: "Contact_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact_Phone",
                table: "Vehicles",
                newName: "Contact_ContactPhone");

            migrationBuilder.RenameColumn(
                name: "Contact_Name",
                table: "Vehicles",
                newName: "Contact_ContactName");

            migrationBuilder.RenameColumn(
                name: "Contact_Email",
                table: "Vehicles",
                newName: "Contact_ContactEmail");
        }
    }
}
