namespace BOL;
using System.ComponentModel.DataAnnotations;
public class Employee
{
    [Key]
    public int Id{get;set;}
    public  string? First_Name{get;set;} 
    public  string? Last_Name{get;set;}
    public  string? DOB{get;set;}

    public  char? Gender{get;set;}  
}
