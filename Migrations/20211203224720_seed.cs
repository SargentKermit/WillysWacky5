using Microsoft.EntityFrameworkCore.Migrations;

namespace WillysWacky5.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Products_Distributors_DistributorId",
                table: "Distributors_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Products_Products_ProductId",
                table: "Distributors_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distributors_Products",
                table: "Distributors_Products");

            migrationBuilder.RenameTable(
                name: "Distributors_Products",
                newName: "Distributor_Products");

            migrationBuilder.RenameIndex(
                name: "IX_Distributors_Products_ProductId",
                table: "Distributor_Products",
                newName: "IX_Distributor_Products_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distributor_Products",
                table: "Distributor_Products",
                columns: new[] { "DistributorId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Distributor_Products_Distributors_DistributorId",
                table: "Distributor_Products",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributor_Products_Products_ProductId",
                table: "Distributor_Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributor_Products_Distributors_DistributorId",
                table: "Distributor_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributor_Products_Products_ProductId",
                table: "Distributor_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Distributor_Products",
                table: "Distributor_Products");

            migrationBuilder.RenameTable(
                name: "Distributor_Products",
                newName: "Distributors_Products");

            migrationBuilder.RenameIndex(
                name: "IX_Distributor_Products_ProductId",
                table: "Distributors_Products",
                newName: "IX_Distributors_Products_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Distributors_Products",
                table: "Distributors_Products",
                columns: new[] { "DistributorId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_Products_Distributors_DistributorId",
                table: "Distributors_Products",
                column: "DistributorId",
                principalTable: "Distributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_Products_Products_ProductId",
                table: "Distributors_Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
