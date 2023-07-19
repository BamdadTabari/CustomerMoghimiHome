using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddUserOrderForAdminEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductTotalPrice",
                schema: "dbo",
                table: "UserBasketEntity",
                type: "decimal(24,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(24,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                schema: "dbo",
                table: "UserBasketEntity",
                type: "decimal(24,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(24,4)");

            migrationBuilder.AddColumn<long>(
                name: "UserOrderForAdminEntityId",
                schema: "dbo",
                table: "UserBasketEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "UserOrderForAdminEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderForAdminEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBasketEntity_UserOrderForAdminEntityId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "UserOrderForAdminEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBasketEntity_UserOrderForAdminEntity_UserOrderForAdminEntityId",
                schema: "dbo",
                table: "UserBasketEntity",
                column: "UserOrderForAdminEntityId",
                principalSchema: "dbo",
                principalTable: "UserOrderForAdminEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBasketEntity_UserOrderForAdminEntity_UserOrderForAdminEntityId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.DropTable(
                name: "UserOrderForAdminEntity",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_UserBasketEntity_UserOrderForAdminEntityId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.DropColumn(
                name: "UserOrderForAdminEntityId",
                schema: "dbo",
                table: "UserBasketEntity");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductTotalPrice",
                schema: "dbo",
                table: "UserBasketEntity",
                type: "decimal(24,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(24,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                schema: "dbo",
                table: "UserBasketEntity",
                type: "decimal(24,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(24,0)");
        }
    }
}
