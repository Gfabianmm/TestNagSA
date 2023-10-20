using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIVentas.Migrations
{
    /// <inheritdoc />
    public partial class fix_facturaFormaPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormaPago",
                keyColumn: "IdFormaPago",
                keyValue: new Guid("a9e7534d-a9be-4042-89a6-2472864e5737"));

            migrationBuilder.DeleteData(
                table: "FormaPago",
                keyColumn: "IdFormaPago",
                keyValue: new Guid("c06a66a6-fac0-4d8a-9269-5c5369abe314"));

            migrationBuilder.DeleteData(
                table: "FormaPago",
                keyColumn: "IdFormaPago",
                keyValue: new Guid("ca36f95f-778b-4466-ae52-17ef31f8adf8"));

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "FacturaFormaPago",
                type: "decimal(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "FormaPago",
                columns: new[] { "IdFormaPago", "Descripcion", "Estado", "FechaIngreso", "FechaModificacion", "UsuarioIngreso", "UsuarioModificacion" },
                values: new object[,]
                {
                    { new Guid("726b3431-f8b8-4a70-b811-7062d86bb2d1"), "Cheque", "A", new DateTime(2023, 10, 20, 2, 21, 36, 808, DateTimeKind.Local).AddTicks(7272), null, "sistema", null },
                    { new Guid("9f85ed75-b09a-49d6-b04e-4ca5b99f0d9b"), "Tarjeta de Crédito", "A", new DateTime(2023, 10, 20, 2, 21, 36, 808, DateTimeKind.Local).AddTicks(7274), null, "sistema", null },
                    { new Guid("dd62fa09-f71e-4120-874b-c066cdc3add9"), "Efectivo", "A", new DateTime(2023, 10, 20, 2, 21, 36, 808, DateTimeKind.Local).AddTicks(7262), null, "sistema", null }
                });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV001",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 2, 21, 36, 808, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV002",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 2, 21, 36, 808, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV003",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 2, 21, 36, 808, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV004",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 2, 21, 36, 808, DateTimeKind.Local).AddTicks(7404));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormaPago",
                keyColumn: "IdFormaPago",
                keyValue: new Guid("726b3431-f8b8-4a70-b811-7062d86bb2d1"));

            migrationBuilder.DeleteData(
                table: "FormaPago",
                keyColumn: "IdFormaPago",
                keyValue: new Guid("9f85ed75-b09a-49d6-b04e-4ca5b99f0d9b"));

            migrationBuilder.DeleteData(
                table: "FormaPago",
                keyColumn: "IdFormaPago",
                keyValue: new Guid("dd62fa09-f71e-4120-874b-c066cdc3add9"));

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "FacturaFormaPago");

            migrationBuilder.InsertData(
                table: "FormaPago",
                columns: new[] { "IdFormaPago", "Descripcion", "Estado", "FechaIngreso", "FechaModificacion", "UsuarioIngreso", "UsuarioModificacion" },
                values: new object[,]
                {
                    { new Guid("a9e7534d-a9be-4042-89a6-2472864e5737"), "Cheque", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7393), null, "sistema", null },
                    { new Guid("c06a66a6-fac0-4d8a-9269-5c5369abe314"), "Tarjeta de Crédito", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7395), null, "sistema", null },
                    { new Guid("ca36f95f-778b-4466-ae52-17ef31f8adf8"), "Efectivo", "A", new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7383), null, "sistema", null }
                });

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV001",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV002",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV003",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: "PV004",
                column: "FechaIngreso",
                value: new DateTime(2023, 10, 20, 1, 23, 54, 224, DateTimeKind.Local).AddTicks(7574));
        }
    }
}
