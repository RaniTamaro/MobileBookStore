using BookStore.ViewModels.Abstract;
using BookStore.ViewModels.Book;
using BookStore.Views.Book;
using BookStore.Views.Order;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore.ViewModels.Order
{
    public class DetailsOrderViewModel : AItemDetailsViewModel<OrderForView>
    {
        #region Fields
        private int id;
        private string number;
        private DateTime orderDate;
        private double amount;
        private string address;
        private string status;
        private string trackingNumber;
        private string userFullName;
        private List<BookForView> books;
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

        public string UserFullName
        {
            get => userFullName;
            set => SetProperty(ref userFullName, value);
        }

        public ObservableCollection<BookForView> Items
        {
            get;
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        #endregion

        public DetailsOrderViewModel()
            : base()
        {
            Items = new ObservableCollection<BookForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(NewBookForView);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = books;
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

        public async void NewBookForView()
        {
            await Shell.Current.GoToAsync($"{nameof(NewBookPage)}?{nameof(NewBookViewModel.ItemId)}={Id}");
        }

        public override async void LoadProperties(OrderForView item)
        {
            Number = item.Number;
            OrderDate = item.OrderDate.DateTime;
            Amount = item.Amount;
            Address = item.Address;
            Status = item.Status ?? "";
            TrackingNumber = item.Number ?? "";
            UserFullName = item.UserFullName;
            books = item.OrderBook.ToList();
            await ExecuteLoadItemsCommand();
        }

        public async override void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditOrderPage)}?{nameof(EditOrderViewModel.ItemId)}={Id}");
        }
    }
}
