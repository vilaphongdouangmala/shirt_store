using System.ComponentModel.DataAnnotations;

public class Color {
  [Key]
  public int ColorId {get;set;}//pk label="Color"
  public String ColorName {get;set;}//label="Color_name"

}//ec

