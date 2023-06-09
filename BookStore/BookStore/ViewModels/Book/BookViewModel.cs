﻿using BookStore.ViewModels.Abstract;
using BookStore.Views.Book;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Book
{
    public class BookViewModel : AListViewModel<BookForView>
    {
        public BookViewModel()
            : base("Books")
        {
        }

        public async override void OnItemSelected(BookForView item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsBookPage)}?{nameof(DetailsBookViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewBookPage));
        }
    }
}
