//FileName: ShirtstoreDbContext.cs
using Microsoft.EntityFrameworkCore;


public class ShirtstoreDbContext : DbContext {
    //constructor

    public ShirtstoreDbContext(DbContextOptions opts): base(opts) {}

    //Table Members
    public DbSet<Address> Address {get;set;}
    public DbSet<Color> Color {get;set;}
    public DbSet<Customer> Customer {get;set;}
    public DbSet<Employee> Employee {get;set;}
    public DbSet<Order> Order {get;set;}
    public DbSet<OrderItem> OrderItem {get;set;}
    public DbSet<Product> Product {get;set;}
    public DbSet<ProductCategory> ProductCategory {get;set;}
    public DbSet<Role> Role {get;set;}
    public DbSet<Size> Size {get;set;}
    public DbSet<Sku> Sku {get;set;}
    //end Table Members
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        SnakeCaseIdentityTableNames(modelBuilder);
    }//ef
    private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder){
        //#slot4#
    }//ef

}//ec

 
