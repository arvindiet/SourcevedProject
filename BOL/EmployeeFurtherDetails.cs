namespace BOL;
using System.ComponentModel.DataAnnotations;

public class EmployeeFurtherDetails{

    [Key]
    public int Id{get;set;}

    public string? Joining_Date{get;set;}
    public string? Ending_Date{get;set;}
    public  int Salary{get;set;}
}