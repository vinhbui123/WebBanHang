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

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<TypeProduct> TypeProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WIN-HKD4CBRTN95\\SQLEXPRESS;Initial Catalog=WebBanHang;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__B19D4181CA5A03BA");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("Account_id");
            entity.Property(e => e.AcccountName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Acccount_name");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
            entity.Property(e => e.Salt)
                .HasMaxLength(6)
                .IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_fk");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__8CB382B1CD65A25C");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("Customer_id");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false);
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
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1FF845362913848");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("Order_id");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Order_status");
            entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_method_id");
            entity.Property(e => e.ReceivedDate).HasColumnName("Received_date");
            entity.Property(e => e.StoreId).HasColumnName("Store_id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_price");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customers_orders_fk");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_payment_method_fk");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.OrderId }).HasName("PK__Order_it__B72C07D7D4D7DAE7");

            entity.ToTable("Order_items");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.ListPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("List_price");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_order_items_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_order_items_fk");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__7BB1893190C36AB9");

            entity.Property(e => e.PaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnName("Payment_method_id");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Payment_method_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__9833FF92FA418855");

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
            entity.Property(e => e.Thumb)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TypeId).HasColumnName("Type_id");
            entity.Property(e => e.UnitInStock).HasColumnName("Unit_in_stock");

            entity.HasOne(d => d.ProductNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_details_fk");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("type_product_products_fk");

            entity.HasMany(d => d.Promotions).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "PromotionDetail",
                    r => r.HasOne<Promotion>().WithMany()
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("promotion_promotion_detail_fk"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("products_promotion_detail_fk"),
                    j =>
                    {
                        j.HasKey("ProductId", "PromotionId").HasName("PK__Promotio__B59CD77B509A0E3D");
                        j.ToTable("Promotion_detail");
                        j.IndexerProperty<int>("ProductId").HasColumnName("Product_id");
                        j.IndexerProperty<int>("PromotionId").HasColumnName("Promotion_id");
                    });
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product___9833FF92A7AEA72A");

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
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__DAF28E9335D595D5");

            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId)
                .ValueGeneratedNever()
                .HasColumnName("Promotion_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDay).HasColumnName("End_day");
            entity.Property(e => e.PromotionDiscounts)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Promotion_discounts");
            entity.Property(e => e.PromotionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Promotion_name");
            entity.Property(e => e.StartDay).HasColumnName("Start_day");
            entity.Property(e => e.Thumb)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80BB093CFAA516C");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("Role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Role_name");
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.ShipId).HasName("PK__Ship__58D18D03459A8281");

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
            entity.HasKey(e => e.ProductId).HasName("PK__Stocks__9833FF9259EA7524");

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
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__A0F06719949D08D9");

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

        modelBuilder.Entity<TypeProduct>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Type_Pro__FE91E1E6F31AC204");

            entity.ToTable("Type_Product");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("Type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
