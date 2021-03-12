using CosmosMVC.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosMVC.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(Item item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await _container.DeleteItemAsync<Item>(id, new PartitionKey(id));
        }

        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Item> response = await _container.ReadItemAsync<Item>(id, new PartitionKey(id));
                return response;
            } catch(CosmosException ex) when(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string query)
        {
            var q = _container.GetItemQueryIterator<Item>(new QueryDefinition(query));
            List <Item> results = new List<Item>();
            while(q.HasMoreResults)
            {
                var response = await q.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, Item item)
        {
            await _container.UpsertItemAsync<Item>(item, new PartitionKey(id));
        }
    }
}
