using LiteDB;
using System.Collections.Generic;
using LiteDB_Example.Models;

namespace LiteDB_Example.Services
{
    public interface ILiteDBServices
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        BsonValue InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomerById(int customerId);
    }
    
}