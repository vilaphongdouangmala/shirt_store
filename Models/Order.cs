using System.ComponentModel.DataAnnotations;

public class Order {
  [Key]
  public int OrderId {get;set;}//pk label="Order"
  public DateTime OrderDate {get;set;}//label="Order_date"
  public String PaymentMethod {get;set;}//label="Payment_method"
  public int EmployeeId {get;set;}//fk="Employee"
  public Employee Employee {get;set;} //np
  public int CustomerId {get;set;}//fk="Customer"
  public Customer Customer {get;set;} //np
  public List<OrderItem> OrderItems {get;set;}
//label="Order_items"

}//ec

