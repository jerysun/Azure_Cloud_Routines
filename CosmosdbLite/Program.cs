using System;
using System.Linq;
using CosmosdbLite.Interface;
using CosmosdbLite.Model;
using CosmosdbLite.Service;

namespace CosmosdbLite
{
    public class Program
    {
        private static string DatabaseeName = "maindb";
        private static string ContainerName = "employee";
        private static string FieldFilter = "soprano";

        static void Main(string[] args)
        {
            DoEmployeeService();
        }

        static void DoEmployeeService()
        {
            CosmosdbLite cosmos = CosmosdbLite.Create(DatabaseeName, ContainerName);
            IEmployeeService employeeService = new EmployeeService(cosmos);

            employeeService.InsertOp("john", "doe").GetAwaiter().GetResult();
            employeeService.InsertOp("tony", "soprano").GetAwaiter().GetResult();
            employeeService.InsertOp("richard", "smith").GetAwaiter().GetResult();

            var query = employeeService.QueryOp(FieldFilter).GetAwaiter().GetResult();

            if (query != null)
            {
                PrintQureyResult(query);
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        static void PrintQureyResult(IOrderedQueryable<EmployeeEntity> query)
        {
            if (query == null)
            {
                return;
            }

            Console.WriteLine("Names of all the staff:");
            Console.WriteLine("=======================");

            foreach (EmployeeEntity employee in query)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
