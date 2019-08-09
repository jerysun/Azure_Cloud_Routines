using MyAzureSQLDatabase.Infrastructures;
using MyAzureSQLDatabase.Interfaces;
using MyAzureSQLDatabase.Models;
using MyAzureSQLDatabase.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAzureSQLDatabase
{
    public class Program
    {
        static void InsertEmployee()
        {
            SqlDbLite sqlDbLite = new SqlDbLite("ConnString");
            IEmployeeService employeeService = new EmployeeService(sqlDbLite);

            employeeService.InsertOpAsync("jone", "doe").GetAwaiter().GetResult();
        }
        static void Main(string[] args)
        {
            InsertEmployee();
        }
    }
}
