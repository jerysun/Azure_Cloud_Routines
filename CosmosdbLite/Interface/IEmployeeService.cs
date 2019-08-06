using CosmosdbLite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosdbLite.Interface
{
    public interface IEmployeeService
    {
        Task<bool> InsertOp(string firstname, string lastname);
        Task<IOrderedQueryable<EmployeeEntity>> QueryOp(string fieldFilter);
    }
}
