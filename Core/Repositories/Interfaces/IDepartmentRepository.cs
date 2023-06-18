using Core.Models;
namespace Core.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        bool InsertDepartment(Department department);
        bool UpdateDepartment(Department department);
        // bool DeleteDepartment(int id);
    }
}