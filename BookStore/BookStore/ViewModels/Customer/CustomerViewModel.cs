using BookStore.ViewModels.Abstract;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Customer
{
    public class CustomerViewModel : AListViewModel<CustomerForView>
    {
        public CustomerViewModel()
            : base("Użytkownicy")
        {
        }

        public async override void OnItemSelected(CustomerForView item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrany użytkownik", $"{item.Name} {item.Surname}", "Anuluj");
        }

        public override void GoToAddPage()
        {
            //Shell.Current.GoToAsync(nameof(NewCustomerPage));
        }
    }
}
