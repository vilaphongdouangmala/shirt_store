using System.ComponentModel.DataAnnotations;

public class OrderItem {
  [Key]
  public int OrderItemId {get;set;}//pk label="Order_items"
  public int Qty {get;set;}//label="Qty"
  public int SkuId {get;set;}//fk="Sku"
  public Sku Sku {get;set;} //np
  public int OrderId {get;set;}//fk="Order"
  public Order Order {get;set;} //np

}//ec

