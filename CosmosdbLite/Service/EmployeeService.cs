using CosmosdbLite.Interface;
using CosmosdbLite.Model;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosdbLite.Service
{
    public class EmployeeService : IEmployeeService
    {
        private CosmosdbLite serviceCosmos;

        public EmployeeService(CosmosdbLite ServiceCosmos)
        {
            serviceCosmos = ServiceCosmos;
        }

        public async Task<bool> InsertOp(string firstname, string lastname)
        {
            EmployeeEntity employee1 = new EmployeeEntity();
            employee1.FirstName = firstname;
            employee1.LastName = lastname;

            if (serviceCosmos.DClient == null)
            {
                return false;
            }

            try
            {
                var result = await serviceCosmos.DClient.CreateDocumentAsync( //http POST action
                    UriFactory.CreateDocumentCollectionUri(serviceCosmos.DatabaseName, serviceCosmos.ContainerName),
                    employee1
                    );

                return true;
            }
            catch (DocumentClientException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IOrderedQueryable<EmployeeEntity>> QueryOp()
        {
            var queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true };

            IOrderedQueryable<EmployeeEntity> query = null;

            try
            {
                await Task.Run(() =>
                {
                   query = serviceCosmos.DClient?.CreateDocumentQuery<EmployeeEntity>(//http GET action
                       UriFactory.CreateDocumentCollectionUri(serviceCosmos.DatabaseName, serviceCosmos.ContainerName),
                       queryOptions
                       ).Where(e => e.LastName == "soprano") as IOrderedQueryable<EmployeeEntity>;
                });

                return query;
            }
            catch (DocumentClientException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
