using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Core.Services.Interfaces;
using Core.Models;

namespace WebApp.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentservice;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentservice=departmentService;
    }

    public IActionResult Index()
    {
        return View();
    }


[HttpGet]
    public IActionResult ShowAll()
    {
        ViewData["allDepartments"]=_departmentservice.GetAllDepartments();
        return View();
    }
[HttpGet]
    public IActionResult Search()
    {
        return View();
    }
[HttpPost]
     public IActionResult Search(int Id)
    {
         Department department=_departmentservice.GetDepartmentById(Id);
        return View("ShowById",department);
    }

[HttpGet]
     public IActionResult ShowById()
    {
       
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
