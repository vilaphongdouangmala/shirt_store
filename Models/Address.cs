using System.ComponentModel.DataAnnotations;

public class Address {
  [Key]
  public int AddressId {get;set;}//pk label="Address"
  public String Street {get;set;}//label="Street"
  public String City {get;set;}//label="City"
  public int Zip {get;set;}//label="Zip"
  public int CustomerId {get;set;}//fk="Customer"
  public Customer Customer {get;set;} //np

}//ec

