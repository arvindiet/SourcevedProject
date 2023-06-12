namespace BLL;
using BOL;
using DAL;
public class EmployeeManager
{

   public List<Employee> ShowAll(){
    EmployeeConnection ec = new EmployeeConnection();
    var emp = from em in ec.Employee select em;
    return emp.ToList();
   }
   
   
   public List<EmployeeFurtherDetails> ShowAllDetails(){
    EmployeeConnection ec = new EmployeeConnection();
    var emp = from em in ec.EmployeeFurtherDetails select em;
    return emp.ToList();
   }
   public bool RemoveEmpDetails(int id){
     EmployeeConnection ec = new EmployeeConnection();
     bool status = false;
    var emp = ec.EmployeeFurtherDetails.FirstOrDefault(ex=>ex.Id==id);
     ec.EmployeeFurtherDetails.Remove(emp);
     ec.SaveChanges();
     status=true;

     return status;

   }
   public bool RemoveAll(int id){
    EmployeeConnection ec = new EmployeeConnection();
     bool status = false;
    var emp = ec.Employee.FirstOrDefault(ex=>ex.Id==id);
     bool status1 = RemoveEmpDetails(id);
     ec.Employee.Remove(emp);
     ec.SaveChanges();
     status=true;

     return status;


   }  

   public bool  EditFurtherDetails(int id,string jdate, string edate,int salary){
      EmployeeConnection ec = new EmployeeConnection();
       bool status = false;
       var empl = ec.EmployeeFurtherDetails.FirstOrDefault(ex=>ex.Id==id);       
       empl.Joining_Date=jdate;
       empl.Ending_Date=edate;
       empl.Salary=salary;
       ec.EmployeeFurtherDetails.Update(empl);
       ec.SaveChanges();
       status = true;

       return status;

   }

   public bool EditEmployeDetails(int id,string fname, string lname, string dob,char gender,string jdate,string edate,int salary){
      EmployeeConnection ec = new EmployeeConnection();
       bool status = false;
       var emp = ec.Employee.FirstOrDefault(ex=>ex.Id==id);       
       emp.First_Name=fname;
       emp.Last_Name=lname;
       emp.DOB=dob;
       emp.Gender=gender;
       bool status1 = EditFurtherDetails(id,jdate,edate,salary);
       ec.Employee.Update(emp);
       ec.SaveChanges();
       status = true;

       return status;

   }
   public bool  RegisDetail(int id,string jdate,string edate,int salary){
      EmployeeConnection ec = new EmployeeConnection();
       bool status = false;
       ec.EmployeeFurtherDetails.Add(new EmployeeFurtherDetails{Id=id,Joining_Date=jdate,Ending_Date=edate,Salary=salary});
       ec.SaveChanges();
       status=true;
       return status;
   }

  public bool RegisterEmpl(int id,string fname, string lname, string dob,char gender,string jdate,string edate,int salary){
      EmployeeConnection ec = new EmployeeConnection();
       bool status = false;
       ec.Employee.Add(new Employee{Id=id,First_Name=fname,Last_Name=lname,DOB=dob});
       bool status1 = RegisDetail(id,jdate,edate,salary);
       ec.SaveChanges();
       status=true;
       return status;
  }




}
