using Core.Models;
using Core.Repositories.Interfaces;
using Core.Services.Interfaces;
namespace Core.Services;
public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentrepo;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        this._departmentrepo = departmentRepository;
    }
    public List<Department> GetAllDepartments() => _departmentrepo.GetAllDepartments();
    public Department GetDepartmentById(int id) => _departmentrepo.GetDepartmentById(id);
    public bool InsertDepartment(Department department) => _departmentrepo.InsertDepartment(department);
    public bool UpdateDepartment(Department department) => _departmentrepo.UpdateDepartment(department);
}