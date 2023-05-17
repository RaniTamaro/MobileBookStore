using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookStore.ViewModels
{
    public class BookViewModel : AListViewModel<Book>
    {
        public BookViewModel() 
            : base("Książki")
        {
        }

        public async override void OnItemSelected(Book item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrana książka", $"{item.Title}", "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewBookPage));
        }
    }
}
