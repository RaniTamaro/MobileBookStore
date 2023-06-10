using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.ViewModels.Order
{
    public class NewOrderPage : ANewViewModel<OrderForView>
    {
        //TODO: Przyjmować Id Klienta, który będzie tworzyć to zamówienie, coś ala koszyk z webówki to będzie!
        public NewOrderPage()
            : base()
        {
            bookDataStore = new BookDataStore();
            customerDataStore = new CustomerDataStore();
            bookDataStore.RefreshListFromService();
            customerDataStore.RefreshListFromService();
            books = bookDataStore.items;
            customers = customerDataStore.items;

        }

        #region Fields
        private readonly BookDataStore bookDataStore;
        private readonly CustomerDataStore customerDataStore;
        private string number = "";
        private DateTime orderDate = new DateTime();
        private double amount = 0;
        private string address = "";
        private string status = "";
        private string trackingNumber = "";
        private CustomerForView selectedCustomer;
        private List<CustomerForView> customers;
        private List<BookForView> selectedBooks = new List<BookForView>();
        private List<BookForView> books;
        #endregion

        #region Properties
        public string Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }

        public DateTime OrderDate
        {
            get => orderDate;
            set => SetProperty(ref orderDate, value);
        }

        public double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        public string TrackingNumber
        {
            get => trackingNumber;
            set => SetProperty(ref trackingNumber, value);
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

        public List<BookForView> SelectedBooks
        {
            get => selectedBooks;
            set => SetProperty(ref selectedBooks, value);
        }

        public List<BookForView> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }
        #endregion

        public override OrderForView SetItem()
        {
            //List<BookForView> booksToSet = new List<SelectListItem>();

            //foreach (var book in selectedBooks)
            //{
            //    if (bookDataStore.items.Contains(book))
            //    {
            //        var findBook = bookDataStore.items.FirstOrDefault(x => x.Id == book.Id);
            //        booksToSet.Add();
            //    }
            //}

            return new OrderForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Number = Number,
                OrderDate = OrderDate,
                Amount = Amount,
                Address = Address,
                Status = Status,
                TrackingNumber = TrackingNumber,
                IdCustomer = selectedCustomer.Id,
                CustomerFullName = $"{selectedCustomer.Name} {selectedCustomer.Surname}",
                OrderBook = selectedBooks
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(number)
                && !string.IsNullOrEmpty(address)
                && orderDate > new DateTime()
                && amount > 0;
        }
    }
}
