using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStore.ViewModels.Book;
using BookStore.Views.Book;
using BookStore.Views.Category;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore.ViewModels.Category
{
    //TODO: Klaudia - tu możliwe, że będzie zmiania book, bo w api przyjmuje coś innego!
    public class DetailsCategoryViewModel : AItemDetailsViewModel<CategoryForView>
    {
        #region Fields
        private int id;
        private string name;
        private string description;
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

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public ObservableCollection<BookForView> Items
        {
            get;
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        #endregion

        public DetailsCategoryViewModel()
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

        public override async void LoadProperties(CategoryForView item)
        {
            var bookDataStore = new BookDataStore();
            var bookToSet = new List<BookForView>();

            foreach (var book in item.Books)
            {
                bookToSet.Add(bookDataStore.items.Where(x => x.Id == int.Parse(book.Value)).First());
            }

            Name = item.Name;
            Description = item.Description;
            books = bookToSet;
            await ExecuteLoadItemsCommand();
        }
    }
}
