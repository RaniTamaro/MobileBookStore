using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Category
{
    //TODO: Zrobić front + podpiąć model
    //TODO: Front - Id nie może być wyświetlane! Przekazuje je dla dodawania książek!
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsCategoryPage : ContentPage
    {
        public DetailsCategoryPage()
        {
            InitializeComponent();
        }
    }
}