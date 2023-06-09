﻿using BookStore.ViewModels.Abstract;
using BookStore.ViewModels.Genre;
using BookStore.ViewModels.Review;
using BookStore.Views.Book;
using BookStore.Views.Genre;
using BookStore.Views.Review;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore.ViewModels.Book
{
    public class DetailsBookViewModel : AItemDetailsViewModel<BookForView>
    {
        #region Fields
        private int id;
        private string title;
        private string description;
        private string publishingHouse;
        private double price;
		//private List<BookStoreApi.Genre> genres;
		private List<BookStoreApi.Genre> bookGenres;
		private string authorName;
        private string categoryName;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string PublishingHouse
        {
            get => publishingHouse;
            set => SetProperty(ref publishingHouse, value);
        }

        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string AuthorName
        {
            get => authorName;
            set => SetProperty(ref authorName, value);
        }

        public string CategoryName
        {
            get => categoryName;
            set => SetProperty(ref categoryName, value);
        }
		public List<BookStoreApi.Genre> BookGenres
		{
			get => bookGenres;
			set => SetProperty(ref bookGenres, value);
		}

		public ObservableCollection<BookStoreApi.Genre> Items
        {
            get;
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command GetReviewCommand { get; }
        #endregion

        public DetailsBookViewModel()
            : base()
        {
            Items = new ObservableCollection<BookStoreApi.Genre>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(NewGenre);
            GetReviewCommand = new Command(Review);
        }

		async Task ExecuteLoadItemsCommand()
		{
			IsBusy = true;
			try
			{
				Items.Clear();
				var items = bookGenres; // Zmieniono z genres na bookGenres
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


		public async void NewGenre()
        {
            await Shell.Current.GoToAsync($"{nameof(NewGenrePage)}?{nameof(NewGenreViewModel)}");
        }

        public async override void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditBookPage)}?{nameof(EditBookViewModel.ItemId)}={Id}");
        }

        public async void Review()
        {
            await Shell.Current.GoToAsync($"{nameof(BookReviewPage)}?{nameof(BookReviewViewModel.ItemId)}={Id}");
        }

        //public override async void LoadProperties(BookForView item)
        //{
        //    Id = item.Id;
        //    Title = item.Title;
        //    Description = item.Description;
        //    PublishingHouse = item.PublishingHouse;
        //    Price = item.Price;
        //    CategoryName = item.CategoryName;
        //    AuthorName = item.AuthorName;
        //    genres = item?.BookGenres.ToList();
        //    await ExecuteLoadItemsCommand();

        //}
		public override async void LoadProperties(BookForView item)
		{
			Id = item.Id;
			Title = item.Title;
			Description = item.Description;
			PublishingHouse = item.PublishingHouse;
			Price = item.Price;
			CategoryName = item.CategoryName;
			AuthorName = item.AuthorName;
            BookGenres = item?.BookGenres?.ToList(); // Przypisz bezpośrednio do BookGenres
			await ExecuteLoadItemsCommand();
		}

	}
}
