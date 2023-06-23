using BookStore.ViewModels.Abstract;
using BookStore.ViewModels.Book;
using BookStore.Views.Author;
using BookStore.Views.Book;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore.ViewModels.Author
{
    public class DetailsAuthorViewModel : AItemDetailsViewModel<AuthorForView>
    {
        #region Fields
        private int id;
        private string name;
        private string surname;
        private string nickname;
        private List<BookForView> books;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public string Nickname
        {
            get => nickname;
            set => SetProperty(ref nickname, value);
        }

        public ObservableCollection<BookForView> Items
        {
            get;
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        #endregion

        public DetailsAuthorViewModel()
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
                foreach(var item in items)
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

        public override async void LoadProperties(AuthorForView item)
        {
            Id = item.Id;
            Name = item.Name;
            Surname = item.Surname;
            Nickname = item.Nickname;
            books = item.Books.ToList();
            await ExecuteLoadItemsCommand();
        }

        public async override void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditAuthorPage)}?{nameof(EditAuthorViewModel.ItemId)}={Id}");
        }
    }
}
