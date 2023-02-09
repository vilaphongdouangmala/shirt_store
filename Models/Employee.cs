using System.ComponentModel.DataAnnotations;

public class Employee {
  [Key]
  public int EmployeeId {get;set;}//pk label="Employee"
  public String FirstName {get;set;}//label="First_name"
  public String LastName {get;set;}//label="Last_name"
  public int RoleId {get;set;}//fk="Role"
  public Role Role {get;set;} //np
  public DateTime Joined {get;set;}//label="Joined"

}//ec

