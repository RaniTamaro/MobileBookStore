﻿using BookStore.ViewModels.Order;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Order
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        public BookStoreApi.OrderForView Item { get; set; }
        public NewOrderPage()
        {
            InitializeComponent();
            BindingContext = new NewOrderViewModel();
        }
    }
}