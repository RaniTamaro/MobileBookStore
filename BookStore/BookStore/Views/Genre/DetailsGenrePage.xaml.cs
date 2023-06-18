﻿using BookStore.ViewModels.Genre;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Genre
{
    //TODO: Zrobić front + podpiąć model
    //TODO: Front - Id nie może być wyświetlane! Przekazuje je dla dodawania książek!
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsGenrePage : ContentPage
    {
        public DetailsGenrePage()
        {
            InitializeComponent();
            BindingContext = new DetailsGenreViewModel();
        }
    }
}