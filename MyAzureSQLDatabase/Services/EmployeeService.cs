using MyAzureSQLDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAzureSQLDatabase.Infrastructures;
using MyAzureSQLDatabase.Interfaces;

namespace MyAzureSQLDatabase.Services
{
    public class EmployeeService : IEmployeeService
    {
        private SqlDbLite sqlDbLite;
        public EmployeeService(SqlDbLite sqlDbLite)
        {
            this.sqlDbLite = sqlDbLite;
        }

        public async Task InsertOpAsync(string firstname, string lastname)
        {
            EmployeeEntity employee = new EmployeeEntity
            {
                FirstName = firstname,
                LastName = lastname
            };

            var conn = new SqlConnection(sqlDbLite.ConnString);

            var cmd = new SqlCommand("INSERT Employee(FirstName, LastName) VALUES(@FirstName, @LastName)", conn);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);

            await sqlDbLite.DoTransactionNonQueryAsync(cmd, conn);
        }

        //TODO: UPDATE
        //TODO: SELECT
    }
}
