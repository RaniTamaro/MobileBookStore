using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.ViewModels.Review
{
    public class NewReviewPage : ANewViewModel<ReviewForView>
    {
        public NewReviewPage()
            : base()
        {
            var bookDataStore = new BookDataStore();
            var customerDataStore = new CustomerDataStore();
            bookDataStore.RefreshListFromService();
            customerDataStore.RefreshListFromService();
            books = bookDataStore.items;
            customers = customerDataStore.items;
            selectedBook = bookDataStore.items.FirstOrDefault() ?? new BookForView();
            selectedCustomer = customerDataStore.items.FirstOrDefault() ?? new CustomerForView();
        }

        #region Fields
        private double rating;
        private string title;
        private string text;
        private CustomerForView selectedCustomer;
        private List<CustomerForView> customers;
        private BookForView selectedBook;
        private List<BookForView> books;
        #endregion

        #region Properties
        public double Rating
        {
            get => rating;
            set => SetProperty(ref rating, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public CustomerForView SelectedCustomer
        {
            get => selectedCustomer;
            set => SetProperty(ref selectedCustomer, value);
        }

        public List<CustomerForView> Customers
        {
            get => customers;
            set => SetProperty(ref customers, value);
        }

        public BookForView SelectedBook
        {
            get => selectedBook;
            set => SetProperty(ref selectedBook, value);
        }

        public List<BookForView> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }
        #endregion

        public override ReviewForView SetItem()
        {
            return new ReviewForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Rating = this.Rating,
                Title = this.Title,
                Text = this.Text,
                IdCustomer = selectedCustomer.Id,
                CustomerName = $"{selectedCustomer.Name} {selectedCustomer.Surname}",
                IdBook = selectedBook.Id,
                BookTitle = selectedBook.Title
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(title)
                && rating > 0
                && selectedBook.Id > 0
                && selectedCustomer.Id > 0;
        }
    }
}
