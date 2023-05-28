﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore_tutorial.Migrations
{
    /// <inheritdoc />
    public partial class SeedFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Feature1')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Feature2')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Feature3')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Name IN ('Feature1', 'Feature2', 'Feature3')");
        }
    }
}
