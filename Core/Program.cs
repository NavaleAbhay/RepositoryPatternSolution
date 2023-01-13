using Core.Models;
using Core.Repositories;
DepartmentRepository dept= new DepartmentRepository();
  List<Department> departments=dept.GetAllDepartments();

  foreach(var department in departments){
    Console.WriteLine(department.Id+ "--"+department.Name+ "--"+department.Location);
  }
