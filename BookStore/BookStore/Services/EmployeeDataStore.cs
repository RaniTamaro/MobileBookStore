using BookStore.Helpers;
using BookStore.Models;
using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class EmployeeDataStore : AListDataStore<Employee>
    {
        public override async Task<Employee> AddItemToService(Employee item)
        {
            return await _service.EmployeePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Employee item)
        {
            return await _service.EmployeeDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Employee> Find(Employee item)
        {
            return await _service.EmployeeGETAsync(item.Id);
        }

        public override async Task<Employee> Find(int id)
        {
            return await _service.EmployeeGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.EmployeeAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Employee item)
        {
            return await _service.EmployeePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
