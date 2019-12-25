using System;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Index = Microsoft.Azure.Search.Models.Index;

namespace AzureSearch
{
    class Program
    {

        private static readonly string searchServiceName = "XXXXXXX"; //Name Azure Search 

        private static readonly string adminApiKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"; //admin key
        static void Main(string[] args)
        {
            var serviceClient = CreateSearchServiceClient();
            CreateIndex(serviceClient);


        }

        private static void CreateIndex(SearchServiceClient serviceClient)
        {
            var definition = new Index()
            {
                Name = "hotels",
                Fields = FieldBuilder.BuildForType<Hotel>()
             };
            serviceClient.Indexes.Create(definition);
                
        }

        private static SearchServiceClient CreateSearchServiceClient()
        {
            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }
    }
}
