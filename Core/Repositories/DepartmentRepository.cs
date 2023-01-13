using System.Data;
using MySql.Data.MySqlClient;
using Core.Models;
using Core.Repositories.Interfaces;
using System.Reflection.Metadata;

namespace Core.Repositories;
public class DepartmentRepository : IDepartmentRepository
{

    public static string connectionString=string.Empty;
    static DepartmentRepository(){
        connectionString="server=localhost;port=3306;user=root;password=password;database=transflower";
    }
    public bool DeleteDepartment(int id)
    {
        throw new NotImplementedException();
    }

    public List<Department> GetAllDepartments()
    {
        List<Department> departments=new List<Department>();
        MySqlConnection connection=new MySqlConnection();
        connection.ConnectionString=connectionString;
        try{
            MySqlCommand command=new MySqlCommand();
            command.CommandText="SELECT * FROM departments";
            command.Connection=connection;
            connection.Open();
            MySqlDataReader reader= command.ExecuteReader();
            while(reader.Read())
            {
                int id=Int32.Parse(reader["id"].ToString());
                string deptName=reader["name"].ToString();
                string location=reader["location"].ToString();

                Department department=new Department(){
                    Id=id,
                    Name=deptName,
                    Location=location
                };

                departments.Add(department);
            }
            reader.Close();

        }
        catch(Exception e){
          throw e;
        }
        finally{
            connection.Close();
        }
        return departments;
    }

    public Department GetDepartmentById(int id)
    {
        throw new NotImplementedException();
    }

    public bool InsertDepartment(Department department)
    {
        throw new NotImplementedException();
    }

    public bool UpdateDepartment(Department department)
    {
        throw new NotImplementedException();
    }
}
