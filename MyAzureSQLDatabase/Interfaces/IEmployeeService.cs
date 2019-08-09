using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAzureSQLDatabase.Interfaces
{
    interface IEmployeeService
    {
        Task InsertOpAsync(string firstname, string lastname);
    }
}
