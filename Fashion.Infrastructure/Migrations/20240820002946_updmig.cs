using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fashion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Brand",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "BrandLogo",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandLogo",
                table: "Brand");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brand",
                newName: "ID");
        }
    }
}
