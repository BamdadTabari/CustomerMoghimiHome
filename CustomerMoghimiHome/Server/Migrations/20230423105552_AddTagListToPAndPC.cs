using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTagListToPAndPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryPictureAddress",
                schema: "dbo",
                table: "ProductCategoryEntity",
                newName: "StringTagList");

            migrationBuilder.AddColumn<string>(
                name: "StringTagList",
                schema: "dbo",
                table: "ProductEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StringTagList",
                schema: "dbo",
                table: "ProductEntity");

            migrationBuilder.RenameColumn(
                name: "StringTagList",
                schema: "dbo",
                table: "ProductCategoryEntity",
                newName: "CategoryPictureAddress");
        }
    }
}
