using CSharpEgitimKampi601.MongoDB.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi601.MongoDB.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var collection = connection.GetCustomersCollection();

            var document = new BsonDocument
            {
                {"CustomerName",customer.CustomerName},
                {"CustomerSurname",customer.CustomerSurname},
                {"CustomerCity",customer.CustomerCity},
                {"CustomerBalance",customer.CustomerBalance},
                {"CustomerShoppingCount",customer.CustomerShoppingCount}

            };

            collection.InsertOne(document);
        }
    
        public List<Customer> GetAllCustomers()
        {
            var connection = new MongoDbConnection();
            var collection = connection.GetCustomersCollection();
            var documents = collection.Find(new BsonDocument()).ToList();
            List<Customer> customers = new List<Customer>();
            foreach (var c in documents)
            {
                customers.Add(new Customer
                {
                    CustomerID = c.GetValue("_id").ToString(),
                    CustomerName = c.GetValue("CustomerName").AsString,
                    CustomerSurname = c.GetValue("CustomerSurname").AsString,
                    CustomerCity = c.GetValue("CustomerCity").AsString,
                    CustomerBalance = c.GetValue("CustomerBalance").AsInt32,
                    CustomerShoppingCount = c.GetValue("CustomerShoppingCount").AsInt32
                });
            }
            return customers;
        }
    
        public void DeleteCustomer(string id)
        {
            var connection = new MongoDbConnection();
            var collection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            collection.DeleteOne(filter);
        }

        public void UpdateCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var collection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.CustomerID));
            var updatedValue = Builders<BsonDocument>.Update
                .Set("CustomerName", customer.CustomerName)
                .Set("CustomerSurname", customer.CustomerSurname)
                .Set("CustomerCity", customer.CustomerCity)
                .Set("CustomerBalance", customer.CustomerBalance)
                .Set("CustomerShoppingCount", customer.CustomerShoppingCount);
            collection.UpdateOne(filter, updatedValue);
        }

        public Customer GetCustomerById(string id)
        {
            var connection = new MongoDbConnection();
            var collection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var document = collection.Find(filter).FirstOrDefault();
            return new Customer
            {
                CustomerID = document.GetValue("_id").ToString(),
                CustomerName = document.GetValue("CustomerName").AsString,
                CustomerSurname = document.GetValue("CustomerSurname").AsString,
                CustomerCity = document.GetValue("CustomerCity").AsString,
                CustomerBalance = document.GetValue("CustomerBalance").AsInt32,
                CustomerShoppingCount = document.GetValue("CustomerShoppingCount").AsInt32
            };
        }
    }
}
