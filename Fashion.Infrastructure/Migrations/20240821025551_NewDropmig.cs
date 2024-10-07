using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDropmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewDrops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClothesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClotheName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sizes = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantitys = table.Column<int>(type: "int", nullable: false),
                    ClotheImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewDrops_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewDrops_Clothes_ClothesID",
                        column: x => x.ClothesID,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewDrops_BrandId",
                table: "NewDrops",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDrops_ClothesID",
                table: "NewDrops",
                column: "ClothesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewDrops");
        }
    }
}
