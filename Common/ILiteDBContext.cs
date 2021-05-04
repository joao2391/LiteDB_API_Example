using System.Threading.Tasks;
using System.Collections.Generic;
using LiteDB_Example.Models;
using LiteDB;

namespace LiteDB_Example.Common
{
    public interface ILiteDBContext
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        BsonValue InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomerById(int customerId);
    }
    
}