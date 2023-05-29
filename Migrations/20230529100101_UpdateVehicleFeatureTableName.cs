using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore_tutorial.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVehicleFeatureTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures");

            migrationBuilder.RenameTable(
                name: "VehicleFeatures",
                newName: "VehiclesFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleFeatures_VehicleId",
                table: "VehiclesFeatures",
                newName: "IX_VehiclesFeatures_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclesFeatures",
                table: "VehiclesFeatures",
                columns: new[] { "FeatureId", "VehicleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesFeatures_Features_FeatureId",
                table: "VehiclesFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesFeatures_Vehicles_VehicleId",
                table: "VehiclesFeatures",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesFeatures_Features_FeatureId",
                table: "VehiclesFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesFeatures_Vehicles_VehicleId",
                table: "VehiclesFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclesFeatures",
                table: "VehiclesFeatures");

            migrationBuilder.RenameTable(
                name: "VehiclesFeatures",
                newName: "VehicleFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_VehiclesFeatures_VehicleId",
                table: "VehicleFeatures",
                newName: "IX_VehicleFeatures_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures",
                columns: new[] { "FeatureId", "VehicleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
