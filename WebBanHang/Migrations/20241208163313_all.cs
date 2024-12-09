using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_id = table.Column<int>(type: "int", nullable: false),
                    Full_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Account_id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__8CB382B17A7ACEF6", x => x.Customer_id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Payment_method_id = table.Column<int>(type: "int", nullable: false),
                    Payment_method_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Thumb = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentM__7BB1893189B907B3", x => x.Payment_method_id);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Promotion_id = table.Column<int>(type: "int", nullable: false),
                    Promotion_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Promotion_discounts = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Thumb = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Start_day = table.Column<DateOnly>(type: "date", nullable: false),
                    End_day = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promotio__DAF28E93FAB1361C", x => x.Promotion_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Role_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__D80BB0936EF7B4C3", x => x.Role_id);
                });

            migrationBuilder.CreateTable(
                name: "SignUpVM",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpVM", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Store_id = table.Column<int>(type: "int", nullable: false),
                    Store_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Store_address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Thumb = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stores__A0F06719F7B7A63D", x => x.Store_id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Product",
                columns: table => new
                {
                    Type_id = table.Column<int>(type: "int", nullable: false),
                    Type_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Type_Pro__FE91E1E6E9F69A32", x => x.Type_id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    Customer_id = table.Column<int>(type: "int", nullable: false),
                    Total_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Order_status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Payment_method_id = table.Column<int>(type: "int", nullable: false),
                    Order_date = table.Column<DateOnly>(type: "date", nullable: false),
                    ShippingAddresses = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Ship = table.Column<bool>(type: "bit", nullable: false),
                    Store_id = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__F1FF8453DB41E1DD", x => x.Order_id);
                    table.ForeignKey(
                        name: "customers_orders_fk",
                        column: x => x.Customer_id,
                        principalTable: "Customers",
                        principalColumn: "Customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_id = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Acccount_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accounts__B19D418180E11429", x => x.Account_id);
                    table.ForeignKey(
                        name: "role_accounts_fk",
                        column: x => x.Role_id,
                        principalTable: "Role",
                        principalColumn: "Role_id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Unit_In_Stock = table.Column<int>(type: "int", nullable: false),
                    Thumb = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Videos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Type_id = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Special_status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Brand = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Model_year = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Price_discounts = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cover = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Product_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Product_status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__9833FF92F2B33347", x => x.Product_id);
                    table.ForeignKey(
                        name: "type_product_products_fk",
                        column: x => x.Type_id,
                        principalTable: "Type_Product",
                        principalColumn: "Type_id");
                });

            migrationBuilder.CreateTable(
                name: "Ship",
                columns: table => new
                {
                    Ship_id = table.Column<int>(type: "int", nullable: false),
                    Shipper_id = table.Column<int>(type: "int", nullable: false),
                    Ship_status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Order_date = table.Column<DateOnly>(type: "date", nullable: false),
                    ShippingAddresses = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ExpectedDeliveryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ship__58D18D03B13AB971", x => x.Ship_id);
                    table.ForeignKey(
                        name: "orders_ship_fk",
                        column: x => x.Shipper_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id");
                });

            migrationBuilder.CreateTable(
                name: "Order_items",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    List_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_it__B72C07D7377BC9DF", x => new { x.Product_id, x.Order_id });
                    table.ForeignKey(
                        name: "orders_order_items_fk",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id");
                    table.ForeignKey(
                        name: "products_order_items_fk",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id");
                });

            migrationBuilder.CreateTable(
                name: "Promotion_detail",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Promotion_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promotio__B59CD77B20ED1BBC", x => new { x.Product_id, x.Promotion_id });
                    table.ForeignKey(
                        name: "products_promotion_detail_fk",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id");
                    table.ForeignKey(
                        name: "promotion_promotion_detail_fk",
                        column: x => x.Promotion_id,
                        principalTable: "Promotion",
                        principalColumn: "Promotion_id");
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Store_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stocks__9833FF9283BB5277", x => x.Product_id);
                    table.ForeignKey(
                        name: "products_stocks_fk",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id");
                    table.ForeignKey(
                        name: "stores_stocks_fk",
                        column: x => x.Store_id,
                        principalTable: "Stores",
                        principalColumn: "Store_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Role_id",
                table: "Accounts",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_items_Order_id",
                table: "Order_items",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Customer_id",
                table: "Orders",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Type_id",
                table: "Products",
                column: "Type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_detail_Promotion_id",
                table: "Promotion_detail",
                column: "Promotion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ship_Shipper_id",
                table: "Ship",
                column: "Shipper_id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Store_id",
                table: "Stocks",
                column: "Store_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Order_items");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Promotion_detail");

            migrationBuilder.DropTable(
                name: "Ship");

            migrationBuilder.DropTable(
                name: "SignUpVM");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Type_Product");
        }
    }
}
