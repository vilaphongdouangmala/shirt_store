using System.ComponentModel.DataAnnotations;

public class Size {
  [Key]
  public int SizeId {get;set;}//pk label="Size"
  public String SizeName {get;set;}//label="Size_name"

}//ec

