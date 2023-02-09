
create table `Role` (
 RoleId int(11) not null,
 RoleName varchar(255)  default null,
 primary key (RoleId)    
) engine=InnoDB default charset=utf8mb4;


create table `Employee` (
 EmployeeId int(11) not null,
 FirstName varchar(255)  default null,
 LastName varchar(255)  default null,
 RoleId int(11) not null,
 Joined datetime not null,
 primary key (EmployeeId),
 KEY IX_Employee_RoleId (RoleId),
 CONSTRAINT FK_Employee_Role_RoleId FOREIGN KEY (RoleId) REFERENCES `Role` (RoleId) ON DELETE CASCADE    
) engine=InnoDB default charset=utf8mb4;


create table `Address` (
 AddressId int(11) not null,
 Street varchar(255)  default null,
 City varchar(255)  default null,
 Zip int(11) not null,
 CustomerId int(11) not null,
 primary key (AddressId),
 KEY IX_Address_CustomerId (CustomerId),
 CONSTRAINT FK_Address_Customer_CustomerId FOREIGN KEY (CustomerId) REFERENCES `Customer` (CustomerId) ON DELETE CASCADE    
) engine=InnoDB default charset=utf8mb4;


create table `Customer` (
 CustomerId int(11) not null,
 FirstName varchar(255)  default null,
 LastName varchar(255)  default null,
 Email varchar(255)  default null,
 Phone varchar(255) not null,
 primary key (CustomerId)    
) engine=InnoDB default charset=utf8mb4;


create table `Size` (
 SizeId int(11) not null,
 SizeName varchar(255)  default null,
 primary key (SizeId)    
) engine=InnoDB default charset=utf8mb4;


create table `Color` (
 ColorId int(11) not null,
 ColorName varchar(255)  default null,
 primary key (ColorId)    
) engine=InnoDB default charset=utf8mb4;


create table `ProductCategory` (
 ProductCategoryId int(11) not null,
 CategoryName varchar(255)  default null,
 primary key (ProductCategoryId)    
) engine=InnoDB default charset=utf8mb4;


create table `Product` (
 ProductId int(11) not null,
 ProductName varchar(255)  default null,
 ProductCost double not null,
 ProductCategoryId int(11) not null,
 primary key (ProductId),
 KEY IX_Product_ProductCategoryId (ProductCategoryId),
 CONSTRAINT FK_Product_ProductCategory_ProductCategoryId FOREIGN KEY (ProductCategoryId) REFERENCES `ProductCategory` (ProductCategoryId) ON DELETE CASCADE    
) engine=InnoDB default charset=utf8mb4;


create table `Sku` (
 SkuId int(11) not null,
 SkuNumber int(11) not null,
 SizeId int(11) not null,
 ColorId int(11) not null,
 QuantityInStock int(11) not null,
 Price double not null,
 Image varchar(255)  default null,
 ProductId int(11) not null,
 primary key (SkuId),
 KEY IX_Sku_SizeId (SizeId),
 KEY IX_Sku_ColorId (ColorId),
 KEY IX_Sku_ProductId (ProductId),
 CONSTRAINT FK_Sku_Size_SizeId FOREIGN KEY (SizeId) REFERENCES `Size` (SizeId) ON DELETE CASCADE,
 CONSTRAINT FK_Sku_Color_ColorId FOREIGN KEY (ColorId) REFERENCES `Color` (ColorId) ON DELETE CASCADE,
 CONSTRAINT FK_Sku_Product_ProductId FOREIGN KEY (ProductId) REFERENCES `Product` (ProductId) ON DELETE CASCADE    
) engine=InnoDB default charset=utf8mb4;


create table `OrderItem` (
 OrderItemId int(11) not null,
 Qty int(11) not null,
 SkuId int(11) not null,
 OrderId int(11) not null,
 primary key (OrderItemId),
 KEY IX_OrderItem_SkuId (SkuId),
 KEY IX_OrderItem_OrderId (OrderId),
 CONSTRAINT FK_OrderItem_Sku_SkuId FOREIGN KEY (SkuId) REFERENCES `Sku` (SkuId) ON DELETE CASCADE,
 CONSTRAINT FK_OrderItem_Order_OrderId FOREIGN KEY (OrderId) REFERENCES `Order` (OrderId) ON DELETE CASCADE    
) engine=InnoDB default charset=utf8mb4;


create table `Order` (
 OrderId int(11) not null,
 OrderDate datetime not null,
 PaymentMethod varchar(255)  default null,
 EmployeeId int(11) not null,
 CustomerId int(11) not null,
 primary key (OrderId),
 KEY IX_Order_EmployeeId (EmployeeId),
 KEY IX_Order_CustomerId (CustomerId),
 CONSTRAINT FK_Order_Employee_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES `Employee` (EmployeeId) ON DELETE CASCADE,
 CONSTRAINT FK_Order_Customer_CustomerId FOREIGN KEY (CustomerId) REFERENCES `Customer` (CustomerId) ON DELETE CASCADE    
) engine=InnoDB default charset=utf8mb4;

