using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Models
{
    public class EmployeeDAL
    {
        public string ConncetionString = "Data Source=DESKTOP-3OSV42E\\SQLEXPRESS; Initial Catalog=LearningDB; Persist Security Info=False; User ID=sa;password=Tiog*1991Mitmog*1991";
        
        // Get all employees
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> EmpList = new List<Employee>();
            using (SqlConnection con = new SqlConnection(ConncetionString))
            {
                SqlCommand cmd = new SqlCommand("PS_GetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dr["EmployeeId"].ToString());
                    emp.Nom = dr["Nom"].ToString();
                    emp.Prenom = dr["Prenom"].ToString();
                    emp.Sexe = dr["Sexe"].ToString();
                    emp.Departement = dr["Departement"].ToString();
                    emp.Adresse = dr["Adresse"].ToString();
                    emp.Fonction = dr["Fonction"].ToString();
                    emp.CIN = dr["CIN"].ToString();
                    emp.Salaire = Convert.ToDecimal(dr["Salaire"].ToString());
                    emp.Tele = Convert.ToInt32(dr["Tele"].ToString());
                    EmpList.Add(emp);
                }
                con.Close();
            }
            return EmpList;
        }

        // Insert employee
        public void AddEmployee (Employee emp)
        {
            using (SqlConnection con = new SqlConnection(ConncetionString))
            {
                SqlCommand cmd = new SqlCommand("PS_InsertEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                
                cmd.Parameters.AddWithValue("@Nom", emp.Nom);
                cmd.Parameters.AddWithValue("@Prenom", emp.Prenom);
                cmd.Parameters.AddWithValue("@CIN", emp.CIN);
                cmd.Parameters.AddWithValue("@Sexe", emp.Sexe);
                cmd.Parameters.AddWithValue("@Departement", emp.Departement);
                cmd.Parameters.AddWithValue("@Salaire", emp.Salaire);
                cmd.Parameters.AddWithValue("@Adresse", emp.Adresse);
                cmd.Parameters.AddWithValue("@Tele", emp.Tele);
                cmd.Parameters.AddWithValue("@Fonction", emp.Fonction);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // to update employee
        public void UpdateEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(ConncetionString))
            {
                SqlCommand cmd = new SqlCommand("PS_UpdateEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Nom", emp.Nom);
                cmd.Parameters.AddWithValue("@Prenom", emp.Prenom);
                cmd.Parameters.AddWithValue("@Sexe", emp.Sexe);
                cmd.Parameters.AddWithValue("@Departement", emp.Departement);
                cmd.Parameters.AddWithValue("@Adresse", emp.Adresse);
                cmd.Parameters.AddWithValue("@Fonction", emp.Fonction);
                cmd.Parameters.AddWithValue("@CIN", emp.CIN);
                cmd.Parameters.AddWithValue("@Salaire", emp.Salaire);
                cmd.Parameters.AddWithValue("@Tele", emp.Tele);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // to delete employee
        public void DeleteEmployee(int? empId)
        {
            using (SqlConnection con = new SqlConnection(ConncetionString))
            {
                SqlCommand cmd = new SqlCommand("PS_DeleteEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", empId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Get employee by ID
        public Employee GetEmployeeById(int? id)
        {
            Employee Emp = new Employee();
            using (SqlConnection con = new SqlConnection(ConncetionString))
            {  
                SqlCommand cmd = new SqlCommand("PS_GetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Emp.EmployeeId = Convert.ToInt32(dr["EmployeeId"].ToString());
                    Emp.Nom = dr["Nom"].ToString();
                    Emp.Prenom = dr["Prenom"].ToString();
                    Emp.Sexe = dr["Sexe"].ToString();
                    Emp.Departement = dr["Departement"].ToString();
                    Emp.Adresse = dr["Adresse"].ToString();
                    Emp.Fonction = dr["Fonction"].ToString();
                    Emp.CIN = dr["CIN"].ToString();
                    Emp.Salaire = Convert.ToDecimal(dr["Salaire"].ToString());
                    Emp.Tele = Convert.ToInt32(dr["Tele"].ToString());
                    
                }
                con.Close();
            }
            return Emp;
        }
    }
}
