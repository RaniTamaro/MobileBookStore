using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookStore.ViewModels.Author
{
    public class AuthorViewModel : AListViewModel<AuthorForView>
    {
        public AuthorViewModel()
            : base("Autorzy")
        {
        }

        public async override void OnItemSelected(AuthorForView item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrany autor", $"{item.Name} {item.Surname}", "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewAuthorPage));
        }
    }
}
