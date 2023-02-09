using System.ComponentModel.DataAnnotations;

public class Role {
  [Key]
  public int RoleId {get;set;}//pk label="Role"
  public String RoleName {get;set;}//label="Role_name"

}//ec

