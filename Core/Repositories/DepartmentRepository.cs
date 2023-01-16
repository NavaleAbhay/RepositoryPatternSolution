using System.Data;
using MySql.Data.MySqlClient;
using Core.Models;
using Core.Repositories.Interfaces;

namespace Core.Repositories;
public class DepartmentRepository : IDepartmentRepository
{

    public static string connectionString = string.Empty;
    static DepartmentRepository()
    {
        connectionString = "server=localhost;port=3306;user=root;password=password;database=transflower";
    }
    public bool DeleteDepartment(int id)
    {
        throw new NotImplementedException();
    }

    public List<Department> GetAllDepartments()
    {
        List<Department> departments = new List<Department>();
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = connectionString;
        try
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM departments";
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Int32.Parse(reader["id"].ToString());
                string deptName = reader["name"].ToString();
                string location = reader["location"].ToString();

                Department department = new Department()
                {
                    Id = id,
                    Name = deptName,
                    Location = location
                };

                departments.Add(department);
            }
            reader.Close();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
        return departments;
    }


    public Department GetDepartmentById(int id)
    {
        Department foundDepartment = null;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = connectionString;
        try
        {
            string query = "SELECT * FROM departments WHERE id=@Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id",id);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = Int32.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string location = reader["location"].ToString();
                foundDepartment = new Department()
                {
                    Id = id,
                    Name = name,
                    Location = location,
                };

            }
            reader.Close();
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();

        }
        return foundDepartment;
    }

    public bool InsertDepartment(Department department)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = connectionString;
        try
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO departments(name,location)" +
                            "VALUES('" + department.Name + "','" + department.Location + "')";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            status = true;

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
        return status;
    }

    public bool UpdateDepartment(Department department)
    {
        bool status = false;
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = connectionString;
        try
        {
            string query = "UPDATE departments SET location='" + department.Location + "', name='" + department.Name + "' WHERE id=" + department.Id;
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            throw e;

        }
        finally
        {
            connection.Close();
        }
        return status;
    }
}
