using System.ComponentModel.DataAnnotations;

public class Product {
  [Key]
  public int ProductId {get;set;}//pk label="Product"
  public String ProductName {get;set;}//label="Product_name"
  public double ProductCost {get;set;}//label="Product_cost"
  public int ProductCategoryId {get;set;}//fk="ProductCategory"
  public ProductCategory ProductCategory {get;set;} //np

}//ec

