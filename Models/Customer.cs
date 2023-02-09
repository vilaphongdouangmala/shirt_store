using System.ComponentModel.DataAnnotations;

public class Customer {
  [Key]
  public int CustomerId {get;set;}//pk label="Customer"
  public String FirstName {get;set;}//label="First_name"
  public String LastName {get;set;}//label="Last_name"
  public String Email {get;set;}//label="Email"
  public String Phone {get;set;}//label="Phone"
  public List<Address> Addresses {get;set;}
//label="Address"

}//ec

