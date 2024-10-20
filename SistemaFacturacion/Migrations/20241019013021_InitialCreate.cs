using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFacturacion.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DTE_type",
                columns: table => new
                {
                    DTE_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTE_type_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTE_type", x => x.DTE_type_id);
                });

            migrationBuilder.CreateTable(
                name: "DTE",
                columns: table => new
                {
                    DTE_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DTE_type_id = table.Column<int>(type: "int", nullable: false),
                    Issuer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issuer_nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addres_service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authorization_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DTE_serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DTE_number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DTE_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTE", x => x.DTE_Id);
                    table.ForeignKey(
                        name: "FK_DTE_DTE_type_DTE_type_id",
                        column: x => x.DTE_type_id,
                        principalTable: "DTE_type",
                        principalColumn: "DTE_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DTE_detail",
                columns: table => new
                {
                    DTE_datail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DTE_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Item_number = table.Column<int>(type: "int", nullable: false),
                    Item_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item_quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Item_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_item_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTE_detail", x => x.DTE_datail_id);
                    table.ForeignKey(
                        name: "FK_DTE_detail_DTE_DTE_id",
                        column: x => x.DTE_id,
                        principalTable: "DTE",
                        principalColumn: "DTE_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DTE_DTE_number",
                table: "DTE",
                column: "DTE_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTE_DTE_type_id",
                table: "DTE",
                column: "DTE_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_DTE_detail_DTE_id",
                table: "DTE_detail",
                column: "DTE_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTE_detail");

            migrationBuilder.DropTable(
                name: "DTE");

            migrationBuilder.DropTable(
                name: "DTE_type");
        }
    }
}
