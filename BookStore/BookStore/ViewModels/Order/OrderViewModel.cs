using BookStore.ViewModels.Abstract;
using BookStore.Views.Order;
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
            await Shell.Current.GoToAsync($"{nameof(DetailsOrderPage)}?{nameof(DetailsOrderViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewOrderPage));
        }
    }
}
