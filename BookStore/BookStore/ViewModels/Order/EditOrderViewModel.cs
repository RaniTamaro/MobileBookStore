using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.ViewModels.Order
{
    public class EditOrderViewModel : AEditItemViewModel<OrderForView>
    {
        public EditOrderViewModel()
            : base()
        {
            bookDataStore = new BookDataStore();
            userDataStore = new UserDataStore();
            bookDataStore.RefreshListFromService();
            userDataStore.RefreshListFromService();
            books = bookDataStore.items;
            users = userDataStore.items;

            OrderDate = DateTime.Today;
        }

        #region Fields
        private int id;
        private readonly BookDataStore bookDataStore;
        private readonly UserDataStore userDataStore;
        private string number = "";
        private DateTime orderDate = new DateTime();
        private double amount = 0;
        private string address = "";
        private string status = "";
        private string trackingNumber = "";
        private UserForView selectedUser;
        private List<UserForView> users;
        private BookForView selectedBook;
        private List<BookForView> books;
        private DateTime creationDate;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

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

        public UserForView SelectedUser
        {
            get => selectedUser;
            set => SetProperty(ref selectedUser, value);
        }

        public List<UserForView> Users
        {
            get => users;
            set => SetProperty(ref users, value);
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

        public DateTime CreationDate
        {
            get => creationDate;
            set => SetProperty(ref creationDate, value);
        }
        #endregion

        public override void LoadProperties(OrderForView item)
        {
            Id = item.Id;
            Number = item.Number;
            OrderDate = item.OrderDate.DateTime;
            Amount = item.Amount;
            Address = item.Address;
            Status = item.Status ?? "";
            TrackingNumber = item.Number ?? "";
            SelectedUser = userDataStore.items.Where(x => x.Id == item.IdUser).First();
            SelectedBook = bookDataStore.items.Where(x => x.Id == item.OrderBook.Select(y => y.Id).First()).First();
            books = item.OrderBook.ToList();
            CreationDate = DateTime.Parse(item.CretionDate.ToString());
        }

        public override OrderForView SetItem()
        {
            return new OrderForView
            {
                CretionDate = CreationDate == new DateTime() ? DateTime.Now : CreationDate,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Id = Id,
                Number = Number,
                OrderDate = OrderDate,
                Amount = Amount,
                Address = Address,
                Status = Status,
                TrackingNumber = TrackingNumber,
                IdUser = selectedUser.Id,
                UserFullName = $"{selectedUser.Name} {selectedUser.Surname}",
                OrderBook = new List<BookForView>() { SelectedBook }
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
