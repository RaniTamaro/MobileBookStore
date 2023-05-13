using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class EmployeeDataStore : AListDataStore<Employee>
    {
        public override Task<Employee> AddItemToService(Employee item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(Employee item)
        {
            throw new NotImplementedException();
        }

        public override Task<Employee> Find(Employee item)
        {
            throw new NotImplementedException();
        }

        public override Task<Employee> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
