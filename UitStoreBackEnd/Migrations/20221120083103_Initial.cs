using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UitStoreBackEnd.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DetailOrders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    size = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total = table.Column<double>(type: "float", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salePrice = table.Column<double>(type: "float", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discount = table.Column<double>(type: "float", nullable: true),
                    rating = table.Column<double>(type: "float", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loyalPoint = table.Column<int>(type: "int", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DetailOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
