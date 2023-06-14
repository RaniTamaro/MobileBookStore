using BookStore.ViewModels.Abstract;
using BookStore.Views.Review;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Review
{
    public class ReviewViewModel : AListViewModel<ReviewForView>
    {
        public ReviewViewModel()
           : base("Recenzje")
        {
        }

        public async override void OnItemSelected(ReviewForView item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsReviewPage)}?{nameof(DetailsReviewViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewReviewPage));
        }
    }
}
