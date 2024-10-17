using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiUpdatePattern.WinForm.DAL
{
    public class CustomerDAO : ICustomerDAO
    {
        private static List<Customer> _customers = new List<Customer>() {
    new Customer(1, "Anna Anderson"),
    new Customer(2, "Bob Bunderson"),
    new Customer(3, "Charlotte Cinderson"),
    new Customer(4, "Derek Dobberson"),
    new Customer(5, "Elisa Enderson"),
    new Customer(6, "Fiona Frederson"),
    new Customer(7, "George Gibberson"),
    new Customer(8, "Hannah Hobberson"),
    new Customer(9, "Ian Ibberson"),
    new Customer(10, "Julia Jenderson"),
    new Customer(11, "Kyle Kobberson"),
    new Customer(12, "Lara Lenderson"),
    new Customer(13, "Mason Mibberson"),
    new Customer(14, "Nina Nenderson"),
    new Customer(15, "Oliver Oobberson"),
    new Customer(16, "Paula Pinderson"),
    new Customer(17, "Quinn Quenderson"),
    new Customer(18, "Rachel Ribberson"),
    new Customer(19, "Sammy Sobberson"),
    new Customer(20, "Tina Tinderson"),
    new Customer(21, "Uma Ubberson"),
    new Customer(22, "Victor Voberson"),
    new Customer(23, "Wendy Wenderson"),
    new Customer(24, "Xander Xobberson"),
    new Customer(25, "Yara Yenderson")
};

        private int _lastCustomerIndex = 0;
        public int Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            _lastCustomerIndex++;
            Thread.Sleep(1000 + 350 * _lastCustomerIndex);
            return _customers.Where (customer => customer.Id <= _lastCustomerIndex);
        }

        public bool Updater(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
