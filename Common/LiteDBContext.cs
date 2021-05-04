using LiteDB_Example.Models;
using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace LiteDB_Example.Common
{
    public class LiteDBContext : ILiteDBContext
    {
        private readonly LiteDatabase _context;
        private static ILiteCollection<Customer> collection;
        private const string nameOfCollection = Constants.NAME_OF_COLLECTION;

        public LiteDBContext(IOptions<Configs> configs)
        {
            try
            {
                if (_context == null)
                {
                    _context = new LiteDatabase(configs.Value.PathToDB);
                    collection = _context.GetCollection<Customer>(nameOfCollection);
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public BsonValue InsertCustomer(Customer customer)
        {
            collection = _context.GetCollection<Customer>(nameOfCollection);            

            var bsonValue = collection.Insert(customer);

            return bsonValue;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = collection.FindAll();

            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            var bs = new BsonValue(customerId);

            var customer = collection.FindById(bs);

            return customer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var hasUpdated = collection.Update(customer);

            return hasUpdated;
        }

        public bool DeleteCustomerById(int customerId)
        {
            var bs = new BsonValue(customerId);

            var hasDeleted = collection.Delete(bs);

            return hasDeleted;
        }
    }
}