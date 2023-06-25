using BookStore.ViewModels.Abstract;
using BookStore.ViewModels.Review;
using BookStore.Views.Review;
using BookStore.Views.User;
using BookStoreApi;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BookStore.ViewModels.User
{
    public class DetailsUserViewModel : AItemDetailsViewModel<UserForView>
    {
        #region Fields
        private int id;
        private string name;
        private string surname;
        private string address;
        private string email;
        private string phoneNumber;
        private string nickname;
        private string role;
        private List<OrderForView> orders;
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

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public string Nickname
        {
            get => nickname;
            set => SetProperty(ref nickname, value);
        }

        public string Role
        {
            get => role;
            set => SetProperty(ref role, value);
        }

        public List<OrderForView> Orders
        {
            get => orders;
            set => SetProperty(ref orders, value);
        }

        public Command GetReviewCommand { get; }
        #endregion

        public DetailsUserViewModel()
            : base()
        {
            GetReviewCommand = new Command(Review);
        }

        public async override void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditUserPage)}?{nameof(EditUserViewModel.ItemId)}={Id}");
        }

        public async void Review()
        {
            await Shell.Current.GoToAsync($"{nameof(UserReviewPage)}?{nameof(UserReviewViewModel.ItemId)}={Id}");
        }

        public override void LoadProperties(UserForView item)
        {
            Id = item.Id;
            Name = item.Name;
            Surname = item.Surname;
            Address = item.Address;
            Email = item.Email;
            PhoneNumber = item.PhoneNumber;
            Nickname = item.Nickname;
            Role = item.Role;
            Orders = item.Orders.ToList();
        }
    }
}
