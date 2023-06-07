using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
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
            await Shell.Current.DisplayAlert("Wybrana recenzja", $"{item.Title}", "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewReviewPage));
        }
    }
}
