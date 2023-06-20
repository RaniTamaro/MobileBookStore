﻿using BookStore.Services.Abstract;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Xamarin.Forms;

namespace BookStore.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class AItemDetailsViewModel<T> : BaseViewModel
    {
        protected AItemDetailsViewModel()
        {
            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
            UpdateCommand = new Command(OnUpdate);
        }

        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();

        public Command DeleteCommand { get; }
        public Command CancelCommand { get; }
        public Command UpdateCommand { get; }

        public abstract void LoadProperties(T item);
        private async void OnDelete()
        {
            await DataStore.DeleteItemAsync(itemId);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnUpdate()
        {
            var item = await DataStore.GetItemAsync(itemId);
            await DataStore.UpdateItemAsync(item);
            await Shell.Current.GoToAsync("..");
        }

        private int itemId;
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                LoadProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
