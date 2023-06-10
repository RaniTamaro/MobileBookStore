using BookStore.ViewModels.Abstract;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Order
{
    public class OrderViewModel : AListViewModel<OrderForView>
    {
        public OrderViewModel()
            : base("Zamówienia")
        {
        }

        public async override void OnItemSelected(OrderForView item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrane zamówienie", item.Number, "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewOrderPage));
        }
    }
}
