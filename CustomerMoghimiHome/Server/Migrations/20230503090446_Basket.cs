using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMoghimiHome.Server.Migrations
{
    /// <inheritdoc />
    public partial class Basket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketProductEntity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProductEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketProductEntity_BasketEntity_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "BasketEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProductEntity_ProductEntity_BasketId",
                        column: x => x.BasketId,
                        principalSchema: "dbo",
                        principalTable: "ProductEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProductEntity_BasketId",
                schema: "dbo",
                table: "BasketProductEntity",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketProductEntity_ProductId",
                schema: "dbo",
                table: "BasketProductEntity",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProductEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BasketEntity",
                schema: "dbo");
        }
    }
}
