using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Migrations
{
    /// <inheritdoc />
    public partial class Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "type_product_products_fk",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SignUpVM");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Type_Pro__FE91E1E6E9F69A32",
                table: "Type_Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stores__A0F06719F7B7A63D",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stocks__9833FF9283BB5277",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Ship__58D18D03B13AB971",
                table: "Ship");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Promotio__B59CD77B20ED1BBC",
                table: "Promotion_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Promotio__DAF28E93FAB1361C",
                table: "Promotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__9833FF92F2B33347",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentM__7BB1893189B907B3",
                table: "PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Orders__F1FF8453DB41E1DD",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Order_it__B72C07D7377BC9DF",
                table: "Order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Customer__8CB382B17A7ACEF6",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Thumb",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Ship");

            migrationBuilder.DropColumn(
                name: "Order_date",
                table: "Ship");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Model_year",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Product_status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Videos",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Thumb",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ShippingAddresses",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Account_id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ExpectedDeliveryDate",
                table: "Ship",
                newName: "Expected_delivery_date");

            migrationBuilder.RenameColumn(
                name: "Unit_In_Stock",
                table: "Products",
                newName: "Unit_in_stock");

            migrationBuilder.RenameColumn(
                name: "Type_id",
                table: "Products",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Type_id",
                table: "Products",
                newName: "IX_Products_TypeId");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Customers",
                newName: "Active");

            migrationBuilder.AddColumn<int>(
                name: "Order_id",
                table: "Ship",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_discounts",
                table: "Products",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Received_date",
                table: "Orders",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Customers",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Full_name",
                table: "Customers",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Customer_id",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Customers",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Customers",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Customers",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Type_Pro__FE91E1E6C7D31D21",
                table: "Type_Product",
                column: "Type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stores__A0F06719070A2752",
                table: "Stores",
                column: "Store_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stocks__9833FF923237F1D7",
                table: "Stocks",
                column: "Product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Ship__58D18D03691BCDCA",
                table: "Ship",
                column: "Ship_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Promotio__B59CD77BE3E5EE49",
                table: "Promotion_detail",
                columns: new[] { "Product_id", "Promotion_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Promotio__DAF28E93B072FDE1",
                table: "Promotion",
                column: "Promotion_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__9833FF92B1CB03C8",
                table: "Products",
                column: "Product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentM__7BB189318354E594",
                table: "PaymentMethods",
                column: "Payment_method_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Orders__F1FF8453368B34ED",
                table: "Orders",
                column: "Order_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Order_it__B72C07D75113A243",
                table: "Order_items",
                columns: new[] { "Product_id", "Order_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Customer__8CB382B1ADC8B3D0",
                table: "Customers",
                column: "Customer_id");

            migrationBuilder.CreateTable(
                name: "Product_details",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Videos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Brand = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Model_year = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___9833FF92EEDD5774", x => x.Product_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Payment_method_id",
                table: "Orders",
                column: "Payment_method_id");

            migrationBuilder.AddForeignKey(
                name: "order_payment_method_fk",
                table: "Orders",
                column: "Payment_method_id",
                principalTable: "PaymentMethods",
                principalColumn: "Payment_method_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Type_Product_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Type_Product",
                principalColumn: "Type_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "products_details_fk",
                table: "Products",
                column: "Product_id",
                principalTable: "Product_details",
                principalColumn: "Product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "order_payment_method_fk",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Type_Product_TypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "products_details_fk",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Product_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Type_Pro__FE91E1E6C7D31D21",
                table: "Type_Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stores__A0F06719070A2752",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stocks__9833FF923237F1D7",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Ship__58D18D03691BCDCA",
                table: "Ship");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Promotio__B59CD77BE3E5EE49",
                table: "Promotion_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Promotio__DAF28E93B072FDE1",
                table: "Promotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Products__9833FF92B1CB03C8",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK__PaymentM__7BB189318354E594",
                table: "PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Orders__F1FF8453368B34ED",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Payment_method_id",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Order_it__B72C07D75113A243",
                table: "Order_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Customer__8CB382B1ADC8B3D0",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Order_id",
                table: "Ship");

            migrationBuilder.DropColumn(
                name: "Received_date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Expected_delivery_date",
                table: "Ship",
                newName: "ExpectedDeliveryDate");

            migrationBuilder.RenameColumn(
                name: "Unit_in_stock",
                table: "Products",
                newName: "Unit_In_Stock");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "Type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                newName: "IX_Products_Type_id");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Customers",
                newName: "IsActive");

            migrationBuilder.AddColumn<string>(
                name: "Thumb",
                table: "Stores",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Ship",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Order_date",
                table: "Ship",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_discounts",
                table: "Products",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Products",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Products",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Model_year",
                table: "Products",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Product_status",
                table: "Products",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Products",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Videos",
                table: "Products",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumb",
                table: "PaymentMethods",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddresses",
                table: "Orders",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(8)",
                oldFixedLength: true,
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Full_name",
                table: "Customers",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Customer_id",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Account_id",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Customers",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Type_Pro__FE91E1E6E9F69A32",
                table: "Type_Product",
                column: "Type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stores__A0F06719F7B7A63D",
                table: "Stores",
                column: "Store_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stocks__9833FF9283BB5277",
                table: "Stocks",
                column: "Product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Ship__58D18D03B13AB971",
                table: "Ship",
                column: "Ship_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Promotio__B59CD77B20ED1BBC",
                table: "Promotion_detail",
                columns: new[] { "Product_id", "Promotion_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Promotio__DAF28E93FAB1361C",
                table: "Promotion",
                column: "Promotion_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Products__9833FF92F2B33347",
                table: "Products",
                column: "Product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__PaymentM__7BB1893189B907B3",
                table: "PaymentMethods",
                column: "Payment_method_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Orders__F1FF8453DB41E1DD",
                table: "Orders",
                column: "Order_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Order_it__B72C07D7377BC9DF",
                table: "Order_items",
                columns: new[] { "Product_id", "Order_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Customer__8CB382B17A7ACEF6",
                table: "Customers",
                column: "Customer_id");

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
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpVM", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_id = table.Column<int>(type: "int", nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Acccount_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Role_id",
                table: "Accounts",
                column: "Role_id");

            migrationBuilder.AddForeignKey(
                name: "type_product_products_fk",
                table: "Products",
                column: "Type_id",
                principalTable: "Type_Product",
                principalColumn: "Type_id");
        }
    }
}
