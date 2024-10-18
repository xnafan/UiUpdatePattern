using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiUpdatePattern.WinForm.DAL
{
    public interface ICustomerDAO
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        bool Update(Customer customer);
        bool Delete(Customer customer);
        int Add(Customer customer);
    }
}
