﻿using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System.Collections.Generic;

namespace BookStore.ViewModels.User
{
    public class DetailsUserViewModel : AItemDetailsViewModel<UserForView>
    {
        #region Fields
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
        #endregion

        public DetailsUserViewModel()
            : base()
        {
        }

        public override void LoadProperties(UserForView item)
        {
            Name = Name;
            Surname = Surname;
            Address = Address;
            Email = Email;
            PhoneNumber = PhoneNumber;
            Nickname = Nickname;
            Role = Role;
            Orders = Orders;
        }
    }
}
