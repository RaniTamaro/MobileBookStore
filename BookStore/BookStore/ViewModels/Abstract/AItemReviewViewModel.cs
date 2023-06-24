﻿using BookStore.Services.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStore.ViewModels.Abstract
{
    public abstract class AItemReviewViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        private T _selectedItem;
        private int itemId;
        public int ItemId
        {
            get => itemId;
            set => itemId = value;
        }
        public ObservableCollection<T> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<T> ItemTapped { get; }
        public Command ReviewItemsCommand { get; set; }

        public abstract void LoadProperties(T item);

        public AItemReviewViewModel(string title)
        {
            Title = title;
            Items = new ObservableCollection<T>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
        }

        public async virtual Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default;
        }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        public async virtual void OnItemSelected(T item)
        {
            if (item == null)
                return;
        }
    }
}
