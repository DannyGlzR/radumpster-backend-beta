using Microsoft.EntityFrameworkCore.Migrations;

namespace RaDumpsterAPI.Migrations
{
    public partial class TableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DumpsterCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DumpsterCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DumpsterStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DumpsterStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DumpsterPriceDistance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DistanceStart = table.Column<int>(type: "int", nullable: false),
                    DistanceEnd = table.Column<int>(type: "int", nullable: false),
                    DumpsterCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DumpsterPriceDistance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DumpsterPriceDistance_DumpsterCategory_DumpsterCategoryId",
                        column: x => x.DumpsterCategoryId,
                        principalTable: "DumpsterCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dumpster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DumpsterCategoryId = table.Column<int>(type: "int", nullable: false),
                    DumpsterStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dumpster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dumpster_DumpsterCategory_DumpsterCategoryId",
                        column: x => x.DumpsterCategoryId,
                        principalTable: "DumpsterCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dumpster_DumpsterStatus_DumpsterStatusId",
                        column: x => x.DumpsterStatusId,
                        principalTable: "DumpsterStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dumpster_DumpsterCategoryId",
                table: "Dumpster",
                column: "DumpsterCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dumpster_DumpsterStatusId",
                table: "Dumpster",
                column: "DumpsterStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DumpsterPriceDistance_DumpsterCategoryId",
                table: "DumpsterPriceDistance",
                column: "DumpsterCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dumpster");

            migrationBuilder.DropTable(
                name: "DumpsterPriceDistance");

            migrationBuilder.DropTable(
                name: "DumpsterStatus");

            migrationBuilder.DropTable(
                name: "DumpsterCategory");
        }
    }
}
