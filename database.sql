CREATE TABLE Products (
        Product_id INT NOT NULL,
		Type nvarchar(50) NOT NULL,
		Unit_in_stock INT NOT NULL,
		--Ảnh sản phẩm
		Thumb VARBINARY(MAX),  
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
		PRIMARY KEY (Product_id),

CONSTRAINT FK_ProductDetails_Product FOREIGN KEY (Product_id)
REFERENCES Products (Product_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

);



--Tồn kho
CREATE TABLE Stocks (
		Product_id INT NOT NULL,
		Store_id INT NOT NULL,
        Quantity INT NOT NULL,
        PRIMARY KEY (Product_id)
);


CREATE TABLE Customers (
		Customer_id INT NOT NULL IDENTITY(1,1),
		Full_name VARCHAR(50) NOT NULL,
		Birthday DATETIME,
		Avatar VARCHAR(255),
		Address VARCHAR(200) NULL, 
		Email VARCHAR(100) NOT NULL,
        Phone VARCHAR(15) NOT NULL, 
		CreateDate DATETIME,
		Password NVARCHAR(50) NOT NULL,
		Salt nchar(8),
		LastLogin DATETIME,
		Active BIT NOT NULL,
        PRIMARY KEY (Customer_id)
);


CREATE TABLE Orders (
    Order_id INT IDENTITY(1,1) NOT NULL ,
    Customer_id INT NOT NULL,
    Total_price DECIMAL(10, 2) NOT NULL,
    Order_status VARCHAR(20) NOT NULL,
    Payment_method_name VARCHAR(50) NOT NULL,
    Order_date DATE NOT NULL,
    Received_date DATE,
    Ship BIT NOT NULL,
    Store_id INT NOT NULL,
    Note VARCHAR(200),
    PRIMARY KEY (Order_id)
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


ALTER TABLE Ship ADD CONSTRAINT orders_ship_fk
FOREIGN KEY (Shipper_id)
REFERENCES Orders (Order_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION;


INSERT INTO Products (Product_id, Type, Unit_in_stock, Thumb, Product_name, Special_status, Price, Price_discounts)
VALUES
(1, 'Clothing', 100, NULL, 'T-shirt', 'new', 19.99, 15.99),
(2, 'Clothing', 150, NULL, 'Jeans', 'discount', 49.99, 39.99),
(3, 'Clothing', 200, NULL, 'Jacket', 'hot', 79.99, 69.99),
(4, 'Clothing', 250, NULL, 'Sneakers', NULL, 89.99, 79.99),
(5, 'Clothing', 300, NULL, 'Hat', 'big seller', 24.99, 19.99),
(6, 'Electronics', 120, NULL, 'Smartphone', 'new', 299.99, 279.99),
(7, 'Electronics', 80, NULL, 'Laptop', 'discount', 999.99, 899.99),
(8, 'Electronics', 110, NULL, 'Tablet', 'hot', 199.99, 179.99),
(9, 'Electronics', 130, NULL, 'Camera', NULL, 499.99, 449.99),
(10, 'Electronics', 140, NULL, 'Headphones', 'big seller', 149.99, 129.99),
(11, 'Furniture', 90, NULL, 'Sofa', 'new', 599.99, 549.99),
(12, 'Furniture', 70, NULL, 'Dining Table', 'discount', 399.99, 349.99),
(13, 'Furniture', 60, NULL, 'Bed', 'hot', 499.99, 449.99),
(14, 'Furniture', 50, NULL, 'Wardrobe', NULL, 299.99, 259.99),
(15, 'Furniture', 40, NULL, 'Chair', 'big seller', 149.99, 129.99),
(16, 'Home', 200, NULL, 'Blender', 'new', 49.99, 39.99),
(17, 'Home', 220, NULL, 'Microwave', 'discount', 89.99, 79.99),
(18, 'Home', 240, NULL, 'Toaster', 'hot', 39.99, 34.99),
(19, 'Home', 260, NULL, 'Coffee Maker', NULL, 59.99, 49.99),
(20, 'Home', 280, NULL, 'Vacuum Cleaner', 'big seller', 129.99, 109.99),
(21, 'Clothing', 150, NULL, 'Dress', 'new', 69.99, 59.99),
(22, 'Clothing', 180, NULL, 'Skirt', 'discount', 39.99, 34.99),
(23, 'Clothing', 200, NULL, 'Sweater', 'hot', 49.99, 44.99),
(24, 'Clothing', 220, NULL, 'Socks', NULL, 9.99, 7.99),
(25, 'Clothing', 250, NULL, 'Belt', 'big seller', 19.99, 14.99),
(26, 'Electronics', 95, NULL, 'Smartwatch', 'new', 199.99, 179.99),
(27, 'Electronics', 85, NULL, 'Monitor', 'discount', 249.99, 229.99),
(28, 'Electronics', 105, NULL, 'Keyboard', 'hot', 29.99, 24.99),
(29, 'Electronics', 125, NULL, 'Mouse', NULL, 19.99, 14.99),
(30, 'Electronics', 140, NULL, 'Charger', 'big seller', 29.99, 24.99);

INSERT INTO Product_details (Product_id, Videos, Color, Brand, Model, Model_year, Description)
VALUES
(1, 'video1.mp4', 'Black', 'BrandA', 'ModelA1', '2022-01-01', 'Description of Smartphone A1'),
(2, 'video2.mp4', 'Silver', 'BrandB', 'ModelB2', '2021-01-01', 'Description of Laptop B2'),
(3, 'video3.mp4', 'White', 'BrandC', 'ModelC3', '2020-01-01', 'Description of Microwave C3'),
(4, 'video4.mp4', 'Red', 'BrandD', 'ModelD4', '2022-06-01', 'Description of T-shirt D4'),
(5, 'video5.mp4', 'Blue', 'BrandE', 'ModelE5', '2019-05-01', 'Description of Jeans E5'),
(6, 'video6.mp4', 'Green', 'BrandF', 'ModelF6', '2021-02-01', 'Description of Toy Car F6'),
(7, 'video7.mp4', 'Yellow', 'BrandG', 'ModelG7', '2023-03-01', 'Description of Tablet G7'),
(8, 'video8.mp4', 'Pink', 'BrandH', 'ModelH8', '2018-04-01', 'Description of Blender H8'),
(9, 'video9.mp4', 'Orange', 'BrandI', 'ModelI9', '2022-07-01', 'Description of Jacket I9'),
(10, 'video10.mp4', 'Purple', 'BrandJ', 'ModelJ10', '2020-08-01', 'Description of Doll J10'),
(11, 'video11.mp4', 'Gray', 'BrandK', 'ModelK11', '2021-09-01', 'Description of Smartwatch K11'),
(12, 'video12.mp4', 'Black', 'BrandL', 'ModelL12', '2022-10-01', 'Description of Vacuum Cleaner L12'),
(13, 'video13.mp4', 'Silver', 'BrandM', 'ModelM13', '2020-11-01', 'Description of Sneakers M13'),
(14, 'video14.mp4', 'White', 'BrandN', 'ModelN14', '2019-12-01', 'Description of Puzzle N14'),
(15, 'video15.mp4', 'Red', 'BrandO', 'ModelO15', '2023-01-01', 'Description of Camera O15'),
(16, 'video16.mp4', 'Blue', 'BrandP', 'ModelP16', '2021-02-01', 'Description of Coffee Maker P16'),
(17, 'video17.mp4', 'Green', 'BrandQ', 'ModelQ17', '2022-03-01', 'Description of Hat Q17'),
(18, 'video18.mp4', 'Yellow', 'BrandR', 'ModelR18', '2020-04-01', 'Description of Board Game R18'),
(19, 'video19.mp4', 'Pink', 'BrandS', 'ModelS19', '2021-05-01', 'Description of Headphones S19'),
(20, 'video20.mp4', 'Orange', 'BrandT', 'ModelT20', '2022-06-01', 'Description of Toaster T20'),
(21, 'video21.mp4', 'Purple', 'BrandU', 'ModelU21', '2020-07-01', 'Description of Dress U21'),
(22, 'video22.mp4', 'Gray', 'BrandV', 'ModelV22', '2019-08-01', 'Description of Action Figure V22'),
(23, 'video23.mp4', 'Black', 'BrandW', 'ModelW23', '2021-09-01', 'Description of Monitor W23'),
(24, 'video24.mp4', 'Silver', 'BrandX', 'ModelX24', '2022-10-01', 'Description of Air Fryer X24'),
(25, 'video25.mp4', 'White', 'BrandY', 'ModelY25', '2020-11-01', 'Description of Sweater Y25'),
(26, 'video26.mp4', 'Red', 'BrandZ', 'ModelZ26', '2019-12-01', 'Description of Stuffed Animal Z26'),
(27, 'video27.mp4', 'Blue', 'BrandA', 'ModelA27', '2021-01-01', 'Description of Keyboard A27'),
(28, 'video28.mp4', 'Green', 'BrandB', 'ModelB28', '2022-02-01', 'Description of Electric Kettle B28'),
(29, 'video29.mp4', 'Yellow', 'BrandC', 'ModelC29', '2020-03-01', 'Description of Skirt C29'),
(30, 'video30.mp4', 'Pink', 'BrandD', 'ModelD30', '2021-04-01', 'Description of Lego Set D30');



INSERT INTO Customers (Full_name, Birthday, Avatar, Address, Email, Phone, CreateDate, Password, Salt, LastLogin, Active)
VALUES
('John Doe', '1990-01-01', 'avatar1.png', '123 Main St', 'john.doe1@example.com', '1234567890', '2022-01-01', 'password1', 'salt1234', '2022-01-02', 1),
('Jane Smith', '1985-05-15', 'avatar2.png', '456 Elm St', 'jane.smith2@example.com', '0987654321', '2022-01-01', 'password2', 'salt5678', '2022-01-02', 1),
('Alice Brown', '2000-12-12', 'avatar3.png', '789 Maple St', 'alice.brown3@example.com', '2345678901', '2022-01-01', 'password3', 'salt9876', '2022-01-02', 1),
('Chris Green', '1992-07-07', 'avatar4.png', '321 Oak St', 'chris.green4@example.com', '3456789012', '2022-01-01', 'password4', 'salt4321', '2022-01-02', 1),
('Emily White', '1988-03-22', 'avatar5.png', '654 Pine St', 'emily.white5@example.com', '4567890123', '2022-01-01', 'password5', 'salt8765', '2022-01-02', 1),
('Michael Black', '1975-09-30', 'avatar6.png', '987 Cedar St', 'michael.black6@example.com', '5678901234', '2022-01-01', 'password6', 'salt5674', '2022-01-02', 1),
('Laura Blue', '1993-11-14', 'avatar7.png', '159 Spruce St', 'laura.blue7@example.com', '6789012345', '2022-01-01', 'password7', 'salt3456', '2022-01-02', 1),
('David Brown', '1982-08-09', 'avatar8.png', '753 Fir St', 'david.brown8@example.com', '7890123456', '2022-01-01', 'password8', 'salt2345', '2022-01-02', 1),
('Sophia Grey', '1996-06-03', 'avatar9.png', '456 Birch St', 'sophia.grey9@example.com', '8901234567', '2022-01-01', 'password9', 'salt6543', '2022-01-02', 1),
('Jack White', '1980-02-27', 'avatar10.png', '123 Willow St', 'jack.white10@example.com', '9012345678', '2022-01-01', 'password10', 'salt7654', '2022-01-02', 1),
('Zoe Black', '1987-10-18', 'avatar11.png', '654 Aspen St', 'zoe.black11@example.com', '0123456789', '2022-01-01', 'password11', 'salt8765', '2022-01-02', 1),
('Tom Green', '1999-12-24', 'avatar12.png', '321 Redwood St', 'tom.green12@example.com', '1234567801', '2022-01-01', 'password12', 'salt4321', '2022-01-02', 1),
('Lily Brown', '1974-04-06', 'avatar13.png', '987 Poplar St', 'lily.brown13@example.com', '2345678902', '2022-01-01', 'password13', 'salt5678', '2022-01-02', 1),
('Jake Blue', '1989-05-17', 'avatar14.png', '654 Chestnut St', 'jake.blue14@example.com', '3456789013', '2022-01-01', 'password14', 'salt6789', '2022-01-02', 1),
('Olivia White', '1991-07-28', 'avatar15.png', '321 Palm St', 'olivia.white15@example.com', '4567890124', '2022-01-01', 'password15', 'salt1234', '2022-01-02', 1),
('Noah Black', '1986-09-09', 'avatar16.png', '987 Pine St', 'noah.black16@example.com', '5678901235', '2022-01-01', 'password16', 'salt2345', '2022-01-02', 1),
('Emma Grey', '1998-12-21', 'avatar17.png', '654 Oak St', 'emma.grey17@example.com', '6789012346', '2022-01-01', 'password17', 'salt3456', '2022-01-02', 1),
('Lucas Green', '1978-03-13', 'avatar18.png', '321 Cedar St', 'lucas.green18@example.com', '7890123457', '2022-01-01', 'password18', 'salt4567', '2022-01-02', 1),
('Mia Brown', '1981-11-05', 'avatar19.png', '987 Birch St', 'mia.brown19@example.com', '8901234568', '2022-01-01', 'password19', 'salt5678', '2022-01-02', 1),
('James White', '1984-01-15', 'avatar20.png', '654 Spruce St', 'james.white20@example.com', '9012345679', '2022-01-01', 'password20', 'salt6789', '2022-01-02', 1),
('Grace Black', '1972-06-09', 'avatar21.png', '321 Fir St', 'grace.black21@example.com', '0123456780', '2022-01-01', 'password21', 'salt1234', '2022-01-02', 1),
('Liam Green', '1994-02-22', 'avatar22.png', '987 Maple St', 'liam.green22@example.com', '1234567802', '2022-01-01', 'password22', 'salt2345', '2022-01-02', 1),
('Ella Brown', '1979-08-03', 'avatar23.png', '654 Poplar St', 'ella.brown23@example.com', '2345678903', '2022-01-01', 'password23', 'salt3456', '2022-01-02', 1),
('Aiden Blue', '1983-09-24', 'avatar24.png', '321 Chestnut St', 'aiden.blue24@example.com', '3456789014', '2022-01-01', 'password24', 'salt4567', '2022-01-02', 1),
('Natalie White', '1977-11-14', 'avatar25.png', '987 Palm St', 'natalie.white25@example.com', '4567890125', '2022-01-01', 'password25', 'salt5678', '2022-01-02', 1),
('Owen Black', '1988-05-25', 'avatar26.png', '654 Aspen St', 'owen.black26@example.com', '5678901236', '2022-01-01', 'password26', 'salt6789', '2022-01-02', 1),
('Hannah Grey', '1990-07-07', 'avatar27.png', '321 Redwood St', 'hannah.grey27@example.com', '6789012347', '2022-01-01', 'password27', 'salt1234', '2022-01-02', 1),
('Ryan Brown', '1992-09-18', 'avatar28.png', '987 Willow St', 'ryan.brown28@example.com', '7890123458', '2022-01-01', 'password28', 'salt2345', '2022-01-02', 1),
('Sofia White', '1995-12-10', 'avatar29.png', '654 Birch St', 'sofia.white29@example.com', '8901234569', '2022-01-01', 'password29', 'salt3456', '2022-01-02', 1),
('Ethan Black', '1981-03-21', 'avatar30.png', '321 Oak St', 'ethan.black30@example.com', '9012345670', '2022-01-01', 'password30', 'salt4567', '2022-01-02', 1);

INSERT INTO Orders (Customer_id, Total_price, Order_status, Payment_method_name, Order_date, Received_date, Ship, Store_id, Note)
VALUES
(1, 279.99, 'Completed', 'Credit Card', '2022-01-01', '2022-01-02', 1, 1, 'Delivered on time'),
(2, 899.99, 'Pending', 'PayPal', '2022-01-01', '2022-01-03', 0, 1, 'Please handle with care'),
(3, 49.99, 'Completed', 'Cash', '2022-01-02', '2022-01-04', 1, 2, 'Thank you!'),
(4, 59.99, 'Shipped', 'Credit Card', '2022-01-03', '2022-01-05', 1, 1, 'Fast delivery'),
(5, 89.99, 'Cancelled', 'Bank Transfer', '2022-01-04', '2022-01-06', 0, 2, 'Order cancelled'),
(6, 129.99, 'Completed', 'Credit Card', '2022-01-05', '2022-01-07', 1, 1, 'Delivered on time'),
(7, 199.99, 'Pending', 'PayPal', '2022-01-06', '2022-01-08', 0, 1, 'Please handle with care'),
(8, 349.99, 'Shipped', 'Credit Card', '2022-01-07', '2022-01-09', 1, 2, 'Fast delivery'),
(9, 499.99, 'Completed', 'Cash', '2022-01-08', '2022-01-10', 1, 1, 'Thank you!'),
(10, 599.99, 'Cancelled', 'Bank Transfer', '2022-01-09', '2022-01-11', 0, 2, 'Order cancelled'),
(11, 699.99, 'Completed', 'Credit Card', '2022-01-10', '2022-01-12', 1, 1, 'Delivered on time'),
(12, 799.99, 'Pending', 'PayPal', '2022-01-11', '2022-01-13', 0, 1, 'Please handle with care'),
(13, 899.99, 'Shipped', 'Credit Card', '2022-01-12', '2022-01-14', 1, 2, 'Fast delivery'),
(14, 999.99, 'Completed', 'Cash', '2022-01-13', '2022-01-15', 1, 1, 'Thank you!'),
(15, 1099.99, 'Cancelled', 'Bank Transfer', '2022-01-14', '2022-01-16', 0, 2, 'Order cancelled'),
(16, 1199.99, 'Completed', 'Credit Card', '2022-01-15', '2022-01-17', 1, 1, 'Delivered on time'),
(17, 1299.99, 'Pending', 'PayPal', '2022-01-16', '2022-01-18', 0, 1, 'Please handle with care'),
(18, 1399.99, 'Shipped', 'Credit Card', '2022-01-17', '2022-01-19', 1, 2, 'Fast delivery'),
(19, 1499.99, 'Completed', 'Cash', '2022-01-18', '2022-01-20', 1, 1, 'Thank you!'),
(20, 1599.99, 'Cancelled', 'Bank Transfer', '2022-01-19', '2022-01-21', 0, 2, 'Order cancelled'),
(21, 1699.99, 'Completed', 'Credit Card', '2022-01-20', '2022-01-22', 1, 1, 'Delivered on time'),
(22, 1799.99, 'Pending', 'PayPal', '2022-01-21', '2022-01-23', 0, 1, 'Please handle with care'),
(23, 1899.99, 'Shipped', 'Credit Card', '2022-01-22', '2022-01-24', 1, 2, 'Fast delivery'),
(24, 1999.99, 'Completed', 'Cash', '2022-01-23', '2022-01-25', 1, 1, 'Thank you!'),
(25, 2099.99, 'Cancelled', 'Bank Transfer', '2022-01-24', '2022-01-26', 0, 2, 'Order cancelled'),
(26, 2199.99, 'Completed', 'Credit Card', '2022-01-25', '2022-01-27', 1, 1, 'Delivered on time'),
(27, 2299.99, 'Pending', 'PayPal', '2022-01-26', '2022-01-28', 0, 1, 'Please handle with care'),
(28, 2399.99, 'Shipped', 'Credit Card', '2022-01-27', '2022-01-29', 1, 2, 'Fast delivery'),
(29, 2499.99, 'Completed', 'Cash', '2022-01-28', '2022-01-30', 1, 1, 'Thank you!'),
(30, 2599.99, 'Cancelled', 'Bank Transfer', '2022-01-29', '2022-01-31', 0, 2, 'Order cancelled');

INSERT INTO Stores (Store_id, Store_name, Store_address)
VALUES
(1, 'Main Store', '123 Store St'),
(2, 'Branch Store', '456 Store St'),
(3, 'Outlet Store', '789 Store St'),
(4, 'Pop-up Store', '234 Market St'),
(5, 'Central Store', '567 Market St'),
(6, 'East Store', '890 Market St'),
(7, 'West Store', '123 West St'),
(8, 'North Store', '456 North St'),
(9, 'South Store', '789 South St'),
(10, 'Downtown Store', '234 Downtown St'),
(11, 'Uptown Store', '567 Uptown St'),
(12, 'Suburb Store', '890 Suburb St'),
(13, 'Mall Store', '123 Mall St'),
(14, 'Highway Store', '456 Highway St'),
(15, 'Airport Store', '789 Airport St'),
(16, 'Train Station Store', '234 Train St'),
(17, 'Bus Station Store', '567 Bus St'),
(18, 'Beach Store', '890 Beach St'),
(19, 'Mountain Store', '123 Mountain St'),
(20, 'Valley Store', '456 Valley St'),
(21, 'Lakeside Store', '789 Lakeside St'),
(22, 'Riverside Store', '234 Riverside St'),
(23, 'Forest Store', '567 Forest St'),
(24, 'Desert Store', '890 Desert St'),
(25, 'Island Store', '123 Island St'),
(26, 'Village Store', '456 Village St'),
(27, 'City Center Store', '789 City Center St'),
(28, 'Old Town Store', '234 Old Town St'),
(29, 'New Town Store', '567 New Town St'),
(30, 'Historic Store', '890 Historic St');

INSERT INTO Ship (Order_id, Ship_id, Shipper_id, ShippingAddresses, Expected_delivery_date, Ship_status)
VALUES
(1, 1, 1, '123 Customer St', '2022-01-02', 'Delivered'),
(2, 2, 2, '456 Customer St', '2022-01-03', 'Pending'),
(3, 3, 3, '789 Customer St', '2022-01-04', 'Shipped'),
(4, 4, 4, '1010 Customer St', '2022-01-05', 'In Transit'),
(5, 5, 5, '1111 Customer St', '2022-01-06', 'Delivered'),
(6, 6, 6, '1212 Customer St', '2022-01-07', 'Pending'),
(7, 7, 7, '1313 Customer St', '2022-01-08', 'Shipped'),
(8, 8, 8, '1414 Customer St', '2022-01-09', 'In Transit'),
(9, 9, 9, '1515 Customer St', '2022-01-10', 'Delivered'),
(10, 10, 10, '1616 Customer St', '2022-01-11', 'Pending'),
(11, 11, 11, '1717 Customer St', '2022-01-12', 'Shipped'),
(12, 12, 12, '1818 Customer St', '2022-01-13', 'In Transit'),
(13, 13, 13, '1919 Customer St', '2022-01-14', 'Delivered'),
(14, 14, 14, '2020 Customer St', '2022-01-15', 'Pending'),
(15, 15, 15, '2121 Customer St', '2022-01-16', 'Shipped'),
(16, 16, 16, '2222 Customer St', '2022-01-17', 'In Transit'),
(17, 17, 17, '2323 Customer St', '2022-01-18', 'Delivered'),
(18, 18, 18, '2424 Customer St', '2022-01-19', 'Pending'),
(19, 19, 19, '2525 Customer St', '2022-01-20', 'Shipped'),
(20, 20, 20, '2626 Customer St', '2022-01-21', 'In Transit'),
(21, 21, 21, '2727 Customer St', '2022-01-22', 'Delivered'),
(22, 22, 22, '2828 Customer St', '2022-01-23', 'Pending'),
(23, 23, 23, '2929 Customer St', '2022-01-24', 'Shipped'),
(24, 24, 24, '3030 Customer St', '2022-01-25', 'In Transit'),
(25, 25, 25, '3131 Customer St', '2022-01-26', 'Delivered'),
(26, 26, 26, '3232 Customer St', '2022-01-27', 'Pending'),
(27, 27, 27, '3333 Customer St', '2022-01-28', 'Shipped'),
(28, 28, 28, '3434 Customer St', '2022-01-29', 'In Transit'),
(29, 29, 29, '3535 Customer St', '2022-01-30', 'Delivered'),
(30, 30, 30, '3636 Customer St', '2022-01-31', 'Pending');

INSERT INTO Order_items (Product_id, Order_id, Quantity, List_price)
VALUES
(1, 1, 1, 279.99),
(2, 2, 1, 899.99),
(3, 3, 2, 49.99),
(4, 4, 1, 59.99),
(5, 5, 3, 89.99),
(6, 6, 2, 129.99),
(7, 7, 1, 199.99),
(8, 8, 3, 349.99),
(9, 9, 1, 499.99),
(10, 10, 2, 599.99),
(11, 11, 1, 699.99),
(12, 12, 3, 799.99),
(13, 13, 2, 899.99),
(14, 14, 1, 999.99),
(15, 15, 3, 1099.99),
(16, 16, 2, 1199.99),
(17, 17, 1, 1299.99),
(18, 18, 2, 1399.99),
(19, 19, 3, 1499.99),
(20, 20, 1, 1599.99),
(21, 21, 2, 1699.99),
(22, 22, 1, 1799.99),
(23, 23, 3, 1899.99),
(24, 24, 2, 1999.99),
(25, 25, 1, 2099.99),
(26, 26, 3, 2199.99),
(27, 27, 2, 2299.99),
(28, 28, 1, 2399.99),
(29, 29, 2, 2499.99),
(30, 30, 1, 2599.99);

INSERT INTO Stocks (Product_id, Store_id, Quantity)
VALUES
(1, 1, 50),
(2, 1, 75),
(3, 1, 100),
(4, 1, 125),
(5, 1, 150),
(6, 1, 175),
(7, 1, 200),
(8, 1, 225),
(9, 1, 250),
(10, 1, 275),
(11, 1, 300),
(12, 1, 325),
(13, 1, 350),
(14, 1, 375),
(15, 1, 400),
(16, 1, 425),
(17, 1, 450),
(18, 1, 475),
(19, 1, 500),
(20, 1, 525),
(21, 1, 550),
(22, 1, 575),
(23, 1, 600),
(24, 1, 625),
(25, 1, 650),
(26, 1, 675),
(27, 1, 700),
(28, 1, 725),
(29, 1, 750),
(30, 1, 775);
