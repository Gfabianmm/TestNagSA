using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIVentas.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UsuarioIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.IdFactura);
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    IdFormaPago = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UsuarioIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.IdFormaPago);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ValorVenta = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UsuarioIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "FacturaFormaPago",
                columns: table => new
                {
                    IdFacturaFormaPago = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFormaPago = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UsuarioIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaFormaPago", x => x.IdFacturaFormaPago);
                    table.ForeignKey(
                        name: "FK_FacturaFormaPago_Factura_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "Factura",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturaFormaPago_FormaPago_IdFormaPago",
                        column: x => x.IdFormaPago,
                        principalTable: "FormaPago",
                        principalColumn: "IdFormaPago",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalle",
                columns: table => new
                {
                    IdFacturaDetalle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    UsuarioIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalle", x => x.IdFacturaDetalle);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Factura_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "Factura",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FormaPago",
                columns: new[] { "IdFormaPago", "Descripcion", "Estado", "FechaIngreso", "FechaModificacion", "UsuarioIngreso", "UsuarioModificacion" },
                values: new object[,]
                {
                    { new Guid("a9e7534d-a9be-4042-89a6-2472864e5737"), "Cheque", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7393), null, "sistema", null },
                    { new Guid("c06a66a6-fac0-4d8a-9269-5c5369abe314"), "Tarjeta de Crédito", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7395), null, "sistema", null },
                    { new Guid("ca36f95f-778b-4466-ae52-17ef31f8adf8"), "Efectivo", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7383), null, "sistema", null }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Descripcion", "Estado", "FechaIngreso", "FechaModificacion", "Stock", "UsuarioIngreso", "UsuarioModificacion", "ValorVenta" },
                values: new object[,]
                {
                    { "PV001", "Producto 1", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7529), null, 120, "sistema", null, 3.25m },
                    { "PV002", "Producto 2", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7572), null, 50, "sistema", null, 10.25m },
                    { "PV003", "Producto 3", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7573), null, 220, "sistema", null, 1.15m },
                    { "PV004", "Producto 4", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7574), null, 615, "sistema", null, 0.54m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_IdFactura",
                table: "FacturaDetalle",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_IdProducto",
                table: "FacturaDetalle",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaFormaPago_IdFactura",
                table: "FacturaFormaPago",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaFormaPago_IdFormaPago",
                table: "FacturaFormaPago",
                column: "IdFormaPago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaDetalle");

            migrationBuilder.DropTable(
                name: "FacturaFormaPago");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "FormaPago");
        }
    }
}
