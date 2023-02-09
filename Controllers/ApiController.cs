using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[action]")]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;
    private ShirtstoreDbContext _db;

    //dependencies injection, automatically referenced to the global object from global service
    //1. when we create dbcontext in Program.cs, dbconext will be created in the memory
    //2. to use the dbcontext service, we can directly inject this global db context object to the constructor
    public ApiController(ILogger<ApiController> logger, ShirtstoreDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    #region ACTIONS

    [HttpGet]
    public IActionResult SeedData() 
    {
        #region Size, Color, Category
        _db.Size.AddRange(new List<Size> {
            new Size{
                SizeId = 1,
                SizeName = "small"
            },
            new Size{
                SizeId = 2,
                SizeName = "medium"
            },
            new Size{
                SizeId = 3,
                SizeName = "large"
            }
        });

        _db.Color.AddRange(new List<Color> {
            new Color {
                ColorId = 1,
                ColorName = "white"
            },
            new Color {
                ColorId = 2,
                ColorName = "black"
            },
            new Color {
                ColorId = 3,
                ColorName = "pink"
            },
        });

        _db.ProductCategory.AddRange(new List<ProductCategory> {
            new ProductCategory {
                ProductCategoryId = 1,
                CategoryName = "shirt"
            },
            new ProductCategory {
                ProductCategoryId = 2,
                CategoryName = "trousers"
            },
            new ProductCategory {
                ProductCategoryId = 3,
                CategoryName = "hoodie"
            },
        });

        _db.SaveChanges();
        #endregion

        #region Customer

        Customer c1 = new Customer {
            CustomerId = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john222@gmail.com",
            Phone = "0123456789",
            Addresses = new List<Address> {
                new Address {
                    AddressId = 1,
                    Street = "west street",
                    City = "Bangkok",
                    Zip = 10520
                },
                new Address {
                    AddressId = 2,
                    Street = "east street",
                    City = "Phuket",
                    Zip = 11780
                },
            }
        };
        Customer c2 = new Customer {
            CustomerId = 2,
            FirstName = "Jane",
            LastName = "Dee",
            Email = "jane555@gmail.com",
            Phone = "25236526",
            Addresses = new List<Address> {
                new Address {
                    AddressId = 3,
                    Street = "west street",
                    City = "Chiang Mai",
                    Zip = 10210
                },
                new Address {
                    AddressId = 4,
                    Street = "east street",
                    City = "Cha-am",
                    Zip = 17700
                },
            }
        };
        _db.Customer.AddRange(new List<Customer> { c1, c2 });

        #endregion
        

        #region Employee
        Employee em1 = new Employee {
            EmployeeId = 1,
            FirstName = "James",
            LastName = "Harden",
            Role = new Role {
                RoleId = 1,
                RoleName = "manager"
            },
            Joined = DateTime.Now
        };
        Employee em2 = new Employee {
            EmployeeId = 2,
            FirstName = "Damian",
            LastName = "Lillard",
            Role = new Role {
                RoleId = 2,
                RoleName = "staff"
            },
            Joined = DateTime.Now
        };

        _db.Employee.AddRange(new List<Employee> { em1, em2 });
        #endregion

        #region Product
        Product p1 = new Product {
            ProductId = 1,
            ProductName = "product1",
            ProductCost = 80,
            ProductCategoryId = 1
        };

        Product p2 = new Product {
            ProductId = 2,
            ProductName = "product2",
            ProductCost = 180,
            ProductCategoryId = 3
        };

        Product p3 = new Product {
            ProductId = 3,
            ProductName = "product3",
            ProductCost = 200,
            ProductCategoryId = 2
        };

        _db.Product.AddRange(new List<Product> {p1, p2, p3});
        _db.SaveChanges();

        #endregion

        #region SKU
        Sku sku1 = new Sku {
            SkuNumber = 1235678,
            SizeId = 1,
            ColorId = 2,
            QuantityInStock = 50,
            Price = 100.50,
            Image = "pic1",
            ProductId = 1,
        };

        Sku sku2 = new Sku {
            SkuNumber = 5791242,
            SizeId = 3,
            ColorId = 1,
            QuantityInStock = 50,
            Price = 350.00,
            Image = "pic2",
            ProductId = 2,
        };

        Sku sku3 = new Sku {
            SkuNumber = 3724824,
            SizeId = 2,
            ColorId = 1,
            QuantityInStock = 40,
            Price = 200.50,
            Image = "pic3",
            ProductId = 2,
        };

        Sku sku4 = new Sku {
            SkuNumber = 6757525,
            SizeId = 1,
            ColorId = 3,
            QuantityInStock = 20,
            Price = 140.50,
            Image = "pic4",
            ProductId = 3,
        };

        //save changes before going to seeding order 
        _db.Sku.AddRange(new List<Sku> {sku1, sku2, sku3, sku4});
        _db.SaveChanges();

        #endregion

        Order order1 = new Order {
            OrderDate = DateTime.Now,
            //payment method is still static, not convered to db format yet
            PaymentMethod = "cash",
            EmployeeId = 1,
            CustomerId = 1,
            OrderItems = new List<OrderItem> {
                new OrderItem {
                    OrderItemId = 1,
                    Qty = 3,
                    SkuId = 1
                },
                new OrderItem {
                    OrderItemId = 2,
                    Qty = 2,
                    SkuId = 2
                },
                new OrderItem {
                    OrderItemId = 3,
                    Qty = 4,
                    SkuId = 3
                },
            }
        };

        Order order2 = new Order {
            OrderDate = DateTime.Now,
            //payment method is still static, not convered to db format yet
            PaymentMethod = "bank transfer",
            EmployeeId = 1,
            CustomerId = 2,
            OrderItems = new List<OrderItem> {
                new OrderItem {
                    OrderItemId = 4,
                    Qty = 5,
                    SkuId = 4
                },
                new OrderItem {
                    OrderItemId = 5,
                    Qty = 2,
                    SkuId = 1
                },
                new OrderItem {
                    OrderItemId = 6,
                    Qty = 3,
                    SkuId = 3
                },
            }
        };

        Order order3 = new Order {
            OrderDate = DateTime.Now,
            //payment method is still static, not convered to db format yet
            PaymentMethod = "cash",
            EmployeeId = 1,
            CustomerId = 2,
            OrderItems = new List<OrderItem> {
                new OrderItem {
                    OrderItemId = 7,
                    Qty = 8,
                    SkuId = 2
                },
                new OrderItem {
                    OrderItemId = 8,
                    Qty = 3,
                    SkuId = 1
                },
                new OrderItem {
                    OrderItemId = 9,
                    Qty = 5,
                    SkuId = 3
                },
            }
        };

        _db.Order.AddRange(new List<Order> {order1, order2, order3});
        _db.SaveChanges();
        
        return Ok("success");
    }//ef

    #region Products
    [HttpGet]
    public IActionResult GetAllProducts() {
        var result = _db.Product
                        .Include(x => x.ProductCategory)
                        .ToList();
        return Ok(result);
    }//ef

    [HttpGet]
    public IActionResult GetProductSelections() {
        //this function is used to be called when getting selection information for adding products
        var products = _db.Product.ToList();
        var sizes = _db.Size.ToList();
        var colors = _db.Color.ToList();
        var categories = _db.ProductCategory.ToList();
        return Ok(new {
            sizes = sizes,
            colors = colors,
            categories = categories,
            products = products
        });
    }//ef
    
    [HttpPost]
    public IActionResult AddProduct(Product product) {
        _db.Product.Add(product);
        _db.SaveChanges();
        return Ok(new {
            result = product,
            msg = "success",
        });
    }//ef

    [HttpPost]
    public IActionResult EditProduct(Product product) {
       _db.Product.Update(product);
       _db.SaveChanges();
       return Ok(product);
    }//ef

    [HttpPost]
    public IActionResult DeleteProduct(Product product) {
        _db.Product.Remove(product);
        _db.SaveChanges();
        return Ok(product);
    }//ef

    #endregion

    #region SKU

    [HttpGet]
    public IActionResult GetAllSkus() {
        var result = _db.Sku
            .Include(x => x.Color)
            .Include(x => x.Size)
            .Include(x => x.Product)
            .ThenInclude(x => x.ProductCategory)
            .ToList();
        return Ok(result);
    }//ef
    
    [HttpGet] 
    public IActionResult GetOrderDisplaySkus() {
        var result = _db.Sku
            .Select(x => new {
                skuId = x.SkuId,
                price = x.Price,
                product = x.Product,
                productCategory = x.Product.ProductCategory,
                size = x.Size,
                color = x.Color,
            }).ToList();
        return Ok(result);
    }//ef

    [HttpPost]
    public IActionResult AddSku(Sku sku) {
        _db.Sku.Add(sku);
        _db.SaveChanges();
        return Ok(new {
            sku = sku,
            msg = "added"
        });
    }//ef


    [HttpPost]
    public IActionResult EditSku(Sku sku) {
        _db.Update(sku);
        _db.SaveChanges();
        return Ok(sku);
    }//ef

    [HttpPost]
    public IActionResult DeleteSku(Sku sku) {
        _db.Remove(sku);
        _db.SaveChanges();
        return Ok(sku);
    }//ef

    #endregion

    #region Order

    [HttpGet] 
    public IActionResult GetAllOrders() {
        //there are two query methods for the demonstration purpose only

        //get all order information including corresponding tables
        var result = _db.Order
                        .Include(x => x.Customer)
                        .Include(x => x.Employee)
                        .Include(x => x.OrderItems).ThenInclude(x => x.Sku)
                        .Include(x => x.OrderItems).ThenInclude(x => x.Sku.Color)
                        .Include(x => x.OrderItems).ThenInclude(x => x.Sku.Size)
                        .Include(x => x.OrderItems).ThenInclude(x => x.Sku.Product)
                        .ToList();

        //get order information with only selected attributes using Select in LINQ
        var result2 = _db.Order.Select(x => new {
            orderDate = x.OrderDate,
            paymentMethod = x.PaymentMethod,    
            customerName = $"{x.Customer.FirstName} {x.Customer.LastName}",
            employeeName = $"{x.Employee.FirstName} {x.Employee.LastName}",
            orderItems = x.OrderItems.Select(x => new {
                productName = x.Sku.Product.ProductName,
                qty = x.Qty,
                price = x.Sku.Price,
                color = x.Sku.Color.ColorName,
                size = x.Sku.Size.SizeName,
                productCategory = x.Sku.Product.ProductCategory.CategoryName
            })
        }).ToList();
        
        //get the order stats
        double max = _db.Order.Max(x => x.OrderItems.Sum(x => x.Qty * x.Sku.Price));
        double avg = _db.Order.Average(x => x.OrderItems.Sum(x => x.Qty * x.Sku.Price));
        double min = _db.Order.Min(x => x.OrderItems.Sum(x => x.Qty * x.Sku.Price));
        
        return Ok(new {
            orders = result,
            orders2 = result2,
            max,
            avg,
            min
        });
    }//ef
    
    [HttpPost]
    public IActionResult AddOrder(Order order) {
        //assign order date
        order.OrderDate = DateTime.Now;
        
        _db.Order.Add(order);
        _db.SaveChanges();
        return Ok(new {
            msg = "success",
            order
        });
    }//ef

    #endregion

    #region Color
    [HttpPost]
    public IActionResult AddColor(Color color) {
        _db.Add(color);
        _db.SaveChanges();
        return Ok(color);
    }//ef
    #endregion

    #region Size
    [HttpPost]
    public IActionResult AddSize(Size size) {
        _db.Size.Add(size);
        _db.SaveChanges();
        return Ok(size);
    }//ef
    #endregion

    #region ProductCategory
    [HttpPost]
    public IActionResult AddProductCategory(ProductCategory productCategory) {
        _db.ProductCategory.Add(productCategory);
        _db.SaveChanges();
        return Ok(productCategory);
    }//ef

    [HttpGet]
    public IActionResult GetAllProductCategories() {
        var result = _db.ProductCategory.ToList();
        return Ok(result);
    }//ef
    #endregion

    #region Role
    [HttpPost]
    public IActionResult AddRole(Role role) {
        _db.Role.Add(role);
        _db.SaveChanges();
        return Ok(role);
    }//ef
    #endregion

    #region Employee
    
    [HttpPost]
    public IActionResult AddEmployee(Employee employee) {
        _db.Employee.Add(employee);
        _db.SaveChanges();
        return Ok(employee);
    }//ef

    #endregion

    #region Customer

    [HttpGet]
    public IActionResult GetAllCustomers() {
        var result = _db.Customer.Include(x => x.Addresses).ToList();
        return Ok(result);
    }//ef

    [HttpPost]
    public IActionResult AddCustomer(Customer customer) {
        _db.Customer.Add(customer);
        _db.SaveChanges();
        return Ok(customer);
    }//ef

    #endregion

    #endregion

}//ec
