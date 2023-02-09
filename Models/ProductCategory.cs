using System.ComponentModel.DataAnnotations;

public class ProductCategory {
  [Key]
  public int ProductCategoryId {get;set;}//pk label="Product_category"
  public String CategoryName {get;set;}//label="Category_name"

}//ec

