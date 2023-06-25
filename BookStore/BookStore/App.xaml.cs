using BookStore.Services;
using BookStore.Views;
using Xamarin.Forms;

namespace BookStore
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<AuthorDataStore>();
            DependencyService.Register<BookDataStore>();
            DependencyService.Register<CategoryDataStore>();
            DependencyService.Register<UserDataStore>();
            DependencyService.Register<GenreDataStore>();
            DependencyService.Register<OrderDataStore>();
            DependencyService.Register<ReviewDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
