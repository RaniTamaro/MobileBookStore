using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookStore.ViewModels
{
    public class EmployeeViewModel : AListViewModel<Employee>
    {
        public EmployeeViewModel() 
           : base("Pracownicy")
        {
        }

        public async override void OnItemSelected(Employee item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrany pracownik", $"{item.Name}", "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewEmployeePage));
        }
    }
}
