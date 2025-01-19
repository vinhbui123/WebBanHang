using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Model;

public partial class WebBanHangContext : DbContext
{
    public WebBanHangContext()
    {
    }

    public WebBanHangContext(DbContextOptions<WebBanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WIN-HKD4CBRTN95\\SQLEXPRESS;Initial Catalog=WebBanHang;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB382B1102D7198");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Full_name");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1FF8453C27BB4C8");

            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Order_status");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_method_name");
            entity.Property(e => e.ReceivedDate).HasColumnName("Received_date");
            entity.Property(e => e.StoreId).HasColumnName("Store_id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_price");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customers_orders_fk");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__Order_it__41E0DCE649204ADF");

            entity.ToTable("Order_items");

            entity.Property(e => e.OrderItemId).HasColumnName("Order_item_id");
            entity.Property(e => e.ListPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("List_price");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_ite__Order__45F365D3");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__9833FF92A0E55C29");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("Product_id");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceDiscounts)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Price_discounts");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Product_name");
            entity.Property(e => e.SpecialStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Special_status");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UnitInStock).HasColumnName("Unit_in_stock");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product___9833FF928152B78A");

            entity.ToTable("Product_details");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("Product_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModelYear).HasColumnName("Model_year");
            entity.Property(e => e.Videos)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Product).WithOne(p => p.ProductDetail)
                .HasForeignKey<ProductDetail>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductDetails_Product");
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.ShipId).HasName("PK__Ship__58D18D0307D609C7");

            entity.ToTable("Ship");

            entity.Property(e => e.ShipId)
                .ValueGeneratedNever()
                .HasColumnName("Ship_id");
            entity.Property(e => e.ExpectedDeliveryDate).HasColumnName("Expected_delivery_date");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.ShipStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ship_status");
            entity.Property(e => e.ShipperId).HasColumnName("Shipper_id");
            entity.Property(e => e.ShippingAddresses)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Shipper).WithMany(p => p.Ships)
                .HasForeignKey(d => d.ShipperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ship_fk");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Stocks__9833FF925447E57B");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("Product_id");
            entity.Property(e => e.StoreId).HasColumnName("Store_id");

            entity.HasOne(d => d.Product).WithOne(p => p.Stock)
                .HasForeignKey<Stock>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_stocks_fk");

            entity.HasOne(d => d.Store).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stores_stocks_fk");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__A0F067191F22C66B");

            entity.Property(e => e.StoreId)
                .ValueGeneratedNever()
                .HasColumnName("Store_id");
            entity.Property(e => e.StoreAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Store_address");
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Store_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
