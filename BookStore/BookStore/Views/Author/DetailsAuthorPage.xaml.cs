﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookStore.ViewModels.Author;

namespace BookStore.Views.Author
{
    //TODO: Zrobić front
    //TODO: Front - Id nie może być wyświetlane! Przekazuje je dla dodawania książek!
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsAuthorPage : ContentPage
    {
        public DetailsAuthorPage()
        {
            InitializeComponent();
            BindingContext = new DetailsAuthorViewModel();
        }
    }
}