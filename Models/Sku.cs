using System.ComponentModel.DataAnnotations;

public class Sku {
  [Key]
  public int SkuId {get;set;}//pk label="S K U"
  public int SkuNumber {get;set;}//label="S K U_number"
  public int SizeId {get;set;}//fk="Size"
  public Size Size {get;set;} //np
  public int ColorId {get;set;}//fk="Color"
  public Color Color {get;set;} //np
  public int QuantityInStock {get;set;}//label="Quantity_in_stock"
  public double Price {get;set;}//label="Price"
  public String Image {get;set;}//label="Image"
  public int ProductId {get;set;}//fk="Product"
  public Product Product {get;set;} //np

}//ec

