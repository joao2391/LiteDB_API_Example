using System.Collections.Generic;
using LiteDB_Example.Common;
using LiteDB_Example.Models;
using LiteDB;

namespace LiteDB_Example.Services
{
    public class LiteDBServices : ILiteDBServices
    {
        private readonly ILiteDBContext _context;

        public LiteDBServices(ILiteDBContext context)
        {
             _context = context;
        }

        public BsonValue InsertCustomer(Customer customer)
        {
             var bsonValue = _context.InsertCustomer(customer);

             return bsonValue;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _context.GetAllCustomers();

            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _context.GetCustomerById(customerId);

            return customer;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var hasUpdated = _context.UpdateCustomer(customer);

            return hasUpdated;
        }

        public bool DeleteCustomerById(int customerId)
        {
            var hasDeleted = _context.DeleteCustomerById(customerId);

            return hasDeleted;
        }
    }
    
}