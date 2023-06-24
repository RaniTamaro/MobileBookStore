using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStore.Views.Review;
using BookStoreApi;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore.ViewModels.Review
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class UserReviewViewModel : AItemReviewViewModel<ReviewForView>
    {
        public UserReviewViewModel() 
            : base("Recenzje użytkownika")
        {
            ReviewItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public async override void LoadProperties(ReviewForView item)
        {
            ItemId = item.IdUser;
            await ExecuteLoadItemsCommand();
        }

        public async override void OnItemSelected(ReviewForView item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsReviewPage)}?{nameof(DetailsReviewViewModel.ItemId)}={item.Id}");
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                var dataStore = new ReviewDataStore();
                dataStore.GetReviewForUser(ItemId);
                var items = dataStore.items.ToList();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
