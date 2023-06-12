namespace DAL;
using BOL;
using Microsoft.EntityFrameworkCore;
public class EmployeeConnection : DbContext 
{
    public DbSet<Employee> Employee {get;set;}
    public DbSet<EmployeeFurtherDetails> EmployeeFurtherDetails{get;set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       string url =@"server=localhost;user=root;password=arvind12345;database=EmployeeManage";
       optionsBuilder.UseMySQL(url);
    }
}
