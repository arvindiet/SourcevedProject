using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeSErvice.Models;
using BOL;
using BLL;
namespace EmployeeSErvice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Index()
    { 
        EmployeeManager em = new EmployeeManager();
        List<Employee> elist = em.ShowAll();
        List<EmployeeFurtherDetails>elist1 = em.ShowAllDetails();
        if(elist!=null && elist1!=null){
            ViewData["elist"] = elist;
            ViewData["elist1"] = elist1;
        }

        return View();
    }
    [HttpGet]
     public IActionResult RemoveEmployee(int id){
        EmployeeManager em = new EmployeeManager();
        bool status = em.RemoveAll(id);
        if(status){
            TempData["message"]="Removed Successfully";
            return RedirectToAction("index","home");
        }
        
        return View();
     }
     [HttpGet]
     public IActionResult EditEmployee(int id){
        EmployeeManager em = new EmployeeManager();
        List<Employee> elist = em.ShowAll();
        foreach(Employee e in elist){
            if(e.Id==id){
                ViewData["id"]=id;
            }
        }
        return View();
     }

     [HttpPost]
     public IActionResult EditEmployee(int id,string fname, string lname, string dob,char gender,string jdate,string edate,int salary){
       
       EmployeeManager em = new EmployeeManager();
       Console.WriteLine(id+ fname+lname+dob+gender+jdate+edate+salary);
       bool status = em.EditEmployeDetails( id,fname, lname, dob,gender,jdate,edate,salary);
       if(status){
        TempData["message"]="Successfully Updated";
        return RedirectToAction("index","home");
       }
        return View();
     }
    [HttpGet]
    public IActionResult RegisterEmp(){
        return View();
    }
    
     [HttpPost]

     public IActionResult RegisterEmp(string fname, string lname, string dob,char gender,string jdate,string edate,int salary){
        EmployeeManager em = new EmployeeManager();
        List<Employee> elist = em.ShowAll();
        int id = 0;
        foreach(Employee e in elist){
           if(id<e.Id){
              id=e.Id;
           }
        }  
        id = id+1;
        bool status = em.RegisterEmpl(id, fname,  lname, dob, gender,jdate, edate, salary);
        if(status){
            TempData["message"]="Successfully Added";
            return RedirectToAction("index","home");
        }

        return View();
     }


    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
