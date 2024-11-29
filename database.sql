--Khuyến mãi
CREATE TABLE Promotion (
                Promotion_id INT NOT NULL,
                Promotion_name VARCHAR(100) NOT NULL,
		Promotion_discounts DECIMAL(10, 2) NOT NULL,
		--Ảnh bìa (nếu có)
		Thumb VARCHAR(255),
                Start_day DATE NOT NULL,
                End_day DATE NOT NULL,
                Description VARCHAR(100),
                PRIMARY KEY (Promotion_id)
);
--Những sản phẩm được áp dụng trong khuyến mãi
CREATE TABLE Promotion_detail (
                Product_id INT NOT NULL,
                Promotion_id INT NOT NULL,
                PRIMARY KEY (Product_id, Promotion_id)
);


CREATE TABLE Type_Product (
                Type_id INT NOT NULL,
                Type_name VARCHAR(30) NOT NULL,
                PRIMARY KEY (Type_id)
);


CREATE TABLE Products (
                Product_id INT NOT NULL,
		Type_id INT NOT NULL,
		Unit_in_stock INT NOT NULL,
		--Ảnh sản phẩm
		Thumb VARCHAR(255),  
		Product_name VARCHAR(100) NOT NULL,
		--Hot, new, big seller, discounts
		Special_status VARCHAR(20),
		Price DECIMAL(10,2) NOT NULL,
		--Giá sản phẩm sau khi giảm, khuyến mãi
		Price_discounts DECIMAL(10,2),
		PRIMARY KEY (Product_id)
);

CREATE TABLE Product_details (
                Product_id INT NOT NULL,
		--Video sản phẩm
		Videos VARCHAR(255),
		Color VARCHAR(50),
		Brand VARCHAR(100),
		Model VARCHAR(100),
                Model_year DATE,
		Description VARCHAR(MAX),
		PRIMARY KEY (Product_id)
);



--Tồn kho
CREATE TABLE Stocks (
                Product_id INT NOT NULL,
		Store_id INT NOT NULL,
                Quantity INT NOT NULL,
                PRIMARY KEY (Product_id)
);


CREATE TABLE Customers (
		Customer_id INT NOT NULL,
		Full_name VARCHAR(50),
		Birthday DATETIME,
		Avatar VARCHAR(255),
		Address VARCHAR(200) NOT NULL, 
		Email VARCHAR(100) NOT NULL,
                Phone VARCHAR(15) NOT NULL, 
                LocationID INT,
		District INT,
		Ward INT,
		CreateDate DATETIME,
		Password NVARCHAR(50),
		Salt nchar(8),
		LastLogin DATETIME,
		Active BIT,
                PRIMARY KEY (Customer_id)
);

CREATE TABLE Accounts (
                Account_id INT NOT NULL,
		Role_id INT NOT NULL,
		Acccount_name VARCHAR(100) NOT NULL,	
		Phone VARCHAR(20) NOT NULL,
		Email VARCHAR(70) NOT NULL,         
		Password VARCHAR(50) NOT NULL,
		--Chuỗi mật khẩu mã hóa
		Salt nchar(6),
		Avatar VARCHAR(255),
		Active BIT,		
                PRIMARY KEY (Account_id)
);

CREATE TABLE Role (
		Role_id INT NOT NULL,
		Role_name VARCHAR(50) NOT NULL,
                PRIMARY KEY (Role_id)
);


CREATE TABLE Orders (
                Order_id INT NOT NULL,
                Customer_id INT NOT NULL,
		Total_price DECIMAL(10, 2) NOT NULL,
		--Đã thanh toán, chưa thanh toán
                Order_status VARCHAR(20) NOT NULL,
		Payment_method_id INT NOT NULL,
                Order_date DATE NOT NULL,
		Received_date DATE,
		--Khách hàng có thể chọn ship hoặc đến cửa hàng lấy
		Ship BIT NOT NULL,
		Store_id INT NOT NULL,
		--Khách hàng note ngày giờ muốn nhận hàng/tự lấy hàng nếu muốn
		Note VARCHAR(200), 
                PRIMARY KEY (Order_id)
);

--Phương thức thanh toán: tiền mặt, chuyển khoản, thẻ tín dụng
CREATE TABLE PaymentMethods ( 
		Payment_method_id INT NOT NULL,						
		Payment_method_name VARCHAR(100) NOT NULL,
		PRIMARY KEY (Payment_method_id)
 );

CREATE TABLE Stores (
		Store_id INT NOT NULL,							
		Store_name VARCHAR(100) NOT NULL,
		Store_address VARCHAR(100) NOT NULL,
		PRIMARY KEY (Store_id)
 );

CREATE TABLE Ship (
		Order_id INT NOT NULL,
		Ship_id INT NOT NULL,
                Shipper_id INT NOT NULL,
		ShippingAddresses VARCHAR(200) NOT NULL,
		--Ngày giao hàng dự kiến
		Expected_delivery_date DATE NOT NULL, 
		--Đã giao, đã hủy, chưa giao
                Ship_status VARCHAR(20) NOT NULL,
                PRIMARY KEY (Ship_id)
);


CREATE TABLE Order_items (
                Product_id INT NOT NULL,
                Order_id INT NOT NULL,
                Quantity INT NOT NULL,
                List_price DECIMAL(10,2) NOT NULL,
                PRIMARY KEY (Product_id, Order_id)
);


ALTER TABLE Products ADD CONSTRAINT type_product_products_fk
FOREIGN KEY (Type_id)
REFERENCES Type_Product (Type_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Products ADD CONSTRAINT products_details_fk
FOREIGN KEY (Product_id)
REFERENCES Product_details (Product_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Promotion_detail ADD CONSTRAINT products_promotion_detail_fk
FOREIGN KEY (Product_id)
REFERENCES Products (Product_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Promotion_detail ADD CONSTRAINT promotion_promotion_detail_fk
FOREIGN KEY (Promotion_id)
REFERENCES Promotion (Promotion_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Order_items ADD CONSTRAINT products_order_items_fk
FOREIGN KEY (Product_id)
REFERENCES Products (Product_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Order_items ADD CONSTRAINT orders_order_items_fk
FOREIGN KEY (Order_id)
REFERENCES Orders (Order_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Stocks ADD CONSTRAINT products_stocks_fk
FOREIGN KEY (Product_id)
REFERENCES Products (Product_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Stocks ADD CONSTRAINT stores_stocks_fk
FOREIGN KEY (Store_id)
REFERENCES Stores (Store_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Orders ADD CONSTRAINT customers_orders_fk
FOREIGN KEY (Customer_id)
REFERENCES Customers (Customer_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Orders ADD CONSTRAINT order_payment_method_fk
FOREIGN KEY (Payment_method_id)
REFERENCES PaymentMethods (Payment_method_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Ship ADD CONSTRAINT orders_ship_fk
FOREIGN KEY (Shipper_id)
REFERENCES Orders (Order_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;

ALTER TABLE Accounts ADD CONSTRAINT role_fk
FOREIGN KEY (Role_id)
REFERENCES Role (Role_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;
