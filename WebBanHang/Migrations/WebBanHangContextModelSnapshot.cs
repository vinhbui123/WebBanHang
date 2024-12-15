﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebBanHang.Model;

#nullable disable

namespace WebBanHang.Migrations
{
    [DbContext(typeof(WebBanHangContext))]
    partial class WebBanHangContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PromotionDetail", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_id");

                    b.Property<int>("PromotionId")
                        .HasColumnType("int")
                        .HasColumnName("Promotion_id");

                    b.HasKey("ProductId", "PromotionId")
                        .HasName("PK__Promotio__B59CD77BE3E5EE49");

                    b.HasIndex("PromotionId");

                    b.ToTable("Promotion_detail", (string)null);
                });

            modelBuilder.Entity("WebBanHang.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Full_name");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Salt")
                        .HasMaxLength(8)
                        .HasColumnType("nchar(8)")
                        .IsFixedLength();

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__8CB382B1ADC8B3D0");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebBanHang.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_id");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("Customer_id");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("Order_date");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Order_status");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int")
                        .HasColumnName("Payment_method_id");

                    b.Property<DateOnly?>("ReceivedDate")
                        .HasColumnType("date")
                        .HasColumnName("Received_date");

                    b.Property<bool>("Ship")
                        .HasColumnType("bit");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("Store_id");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Total_price");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__F1FF8453368B34ED");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebBanHang.Model.OrderItem", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_id");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("List_price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId")
                        .HasName("PK__Order_it__B72C07D75113A243");

                    b.HasIndex("OrderId");

                    b.ToTable("Order_items", (string)null);
                });

            modelBuilder.Entity("WebBanHang.Model.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int")
                        .HasColumnName("Payment_method_id");

                    b.Property<string>("PaymentMethodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Payment_method_name");

                    b.HasKey("PaymentMethodId")
                        .HasName("PK__PaymentM__7BB189318354E594");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("WebBanHang.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("PriceDiscounts")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Price_discounts");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Product_name");

                    b.Property<string>("SpecialStatus")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Special_status");

                    b.Property<string>("Thumb")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UnitInStock")
                        .HasColumnType("int")
                        .HasColumnName("Unit_in_stock");

                    b.HasKey("ProductId")
                        .HasName("PK__Products__9833FF92B1CB03C8");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebBanHang.Model.ProductDetail", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_id");

                    b.Property<string>("Brand")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Model")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly?>("ModelYear")
                        .HasColumnType("date")
                        .HasColumnName("Model_year");

                    b.Property<string>("Videos")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProductId")
                        .HasName("PK__Product___9833FF92EEDD5774");

                    b.ToTable("Product_details", (string)null);
                });

            modelBuilder.Entity("WebBanHang.Model.Promotion", b =>
                {
                    b.Property<int>("PromotionId")
                        .HasColumnType("int")
                        .HasColumnName("Promotion_id");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateOnly>("EndDay")
                        .HasColumnType("date")
                        .HasColumnName("End_day");

                    b.Property<decimal>("PromotionDiscounts")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("Promotion_discounts");

                    b.Property<string>("PromotionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Promotion_name");

                    b.Property<DateOnly>("StartDay")
                        .HasColumnType("date")
                        .HasColumnName("Start_day");

                    b.Property<string>("Thumb")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("PromotionId")
                        .HasName("PK__Promotio__DAF28E93B072FDE1");

                    b.ToTable("Promotion", (string)null);
                });

            modelBuilder.Entity("WebBanHang.Model.Ship", b =>
                {
                    b.Property<int>("ShipId")
                        .HasColumnType("int")
                        .HasColumnName("Ship_id");

                    b.Property<DateOnly>("ExpectedDeliveryDate")
                        .HasColumnType("date")
                        .HasColumnName("Expected_delivery_date");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_id");

                    b.Property<string>("ShipStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Ship_status");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int")
                        .HasColumnName("Shipper_id");

                    b.Property<string>("ShippingAddresses")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("ShipId")
                        .HasName("PK__Ship__58D18D03691BCDCA");

                    b.HasIndex("ShipperId");

                    b.ToTable("Ship", (string)null);
                });

            modelBuilder.Entity("WebBanHang.Model.Stock", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("Store_id");

                    b.HasKey("ProductId")
                        .HasName("PK__Stocks__9833FF923237F1D7");

                    b.HasIndex("StoreId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("WebBanHang.Model.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("Store_id");

                    b.Property<string>("StoreAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Store_address");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Store_name");

                    b.HasKey("StoreId")
                        .HasName("PK__Stores__A0F06719070A2752");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("PromotionDetail", b =>
                {
                    b.HasOne("WebBanHang.Model.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("products_promotion_detail_fk");

                    b.HasOne("WebBanHang.Model.Promotion", null)
                        .WithMany()
                        .HasForeignKey("PromotionId")
                        .IsRequired()
                        .HasConstraintName("promotion_promotion_detail_fk");
                });

            modelBuilder.Entity("WebBanHang.Model.Order", b =>
                {
                    b.HasOne("WebBanHang.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("customers_orders_fk");

                    b.HasOne("WebBanHang.Model.PaymentMethod", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodId")
                        .IsRequired()
                        .HasConstraintName("order_payment_method_fk");

                    b.Navigation("Customer");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("WebBanHang.Model.OrderItem", b =>
                {
                    b.HasOne("WebBanHang.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("orders_order_items_fk");

                    b.HasOne("WebBanHang.Model.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("products_order_items_fk");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebBanHang.Model.Product", b =>
                {
                    b.HasOne("WebBanHang.Model.ProductDetail", "ProductNavigation")
                        .WithOne("Product")
                        .HasForeignKey("WebBanHang.Model.Product", "ProductId")
                        .IsRequired()
                        .HasConstraintName("products_details_fk");

                    b.Navigation("ProductNavigation");
                });

            modelBuilder.Entity("WebBanHang.Model.Ship", b =>
                {
                    b.HasOne("WebBanHang.Model.Order", "Shipper")
                        .WithMany("Ships")
                        .HasForeignKey("ShipperId")
                        .IsRequired()
                        .HasConstraintName("orders_ship_fk");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("WebBanHang.Model.Stock", b =>
                {
                    b.HasOne("WebBanHang.Model.Product", "Product")
                        .WithOne("Stock")
                        .HasForeignKey("WebBanHang.Model.Stock", "ProductId")
                        .IsRequired()
                        .HasConstraintName("products_stocks_fk");

                    b.HasOne("WebBanHang.Model.Store", "Store")
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .IsRequired()
                        .HasConstraintName("stores_stocks_fk");

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("WebBanHang.Model.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebBanHang.Model.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Ships");
                });

            modelBuilder.Entity("WebBanHang.Model.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebBanHang.Model.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("WebBanHang.Model.ProductDetail", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebBanHang.Model.Store", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
